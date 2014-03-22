namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：QueueServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：提供菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 15:21
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class QueueServices : IQueueServices
    {
        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/25/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段deskTypeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/21/2014 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository;

        /// <summary>
        /// 字段queueDeskTypeLockLogEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/21/2014 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<QueueDeskTypeLockLogEntity> queueDeskTypeLockLogEntityRepository;

        /// <summary>
        /// 字段queueEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/21/2014 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<QueueEntity> queueEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuisineServices" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="deskTypeEntityRepository">The deskTypeEntityRepository</param>
        /// <param name="queueDeskTypeLockLogEntityRepository">The queueDeskTypeLockLogEntityRepository</param>
        /// <param name="queueEntityRepository">The queueEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public QueueServices(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository,
            INHibernateRepository<QueueDeskTypeLockLogEntity> queueDeskTypeLockLogEntityRepository,
            INHibernateRepository<QueueEntity> queueEntityRepository)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.deskTypeEntityRepository = deskTypeEntityRepository;
            this.queueDeskTypeLockLogEntityRepository = queueDeskTypeLockLogEntityRepository;
            this.queueEntityRepository = queueEntityRepository;
        }

        /// <summary>
        /// 获取可排队的台位类型列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回可排队的台位类型列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/21/2014 12:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<QueueDeskModel> GetQueueDeskList(string source, GetQueueDeskListParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<QueueDeskModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new List<QueueDeskModel>()
                };
            }

            var supplierId = parameter.SupplierId;
            /*判断餐厅Id是否存在*/
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<QueueDeskModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<QueueDeskModel>()
                };
            }

            var queueDeskTypeList = (from queueDeskTypeLockLog in this.queueDeskTypeLockLogEntityRepository.EntityQueryable.Where(p => p.IsDel == false && p.IsLock == false && p.SupplierId == supplierId)
                                     from deskType in this.deskTypeEntityRepository.EntityQueryable.Where(p => p.IsDel == false && p.IsLock == false && p.SupplierId == supplierId)
                                     where queueDeskTypeLockLog.DeskType.Id == deskType.Id
                                     select new
                                     {
                                         deskType.Id,
                                         deskType.DeskTypeName,
                                         deskType.RoomType,
                                         deskType.BoxName,
                                         deskType.Description,
                                         deskType.MaxNumber,
                                         deskType.MinNumber,
                                         TableTypeId = deskType.TableType.Id,
                                         deskType.TableType.TblTypeName
                                     }).ToList();

            var tempQueueDate = parameter.QueueDate.ToString("yyyy-MM-dd");
            var startQueueDate = DateTime.Parse(tempQueueDate);
            var endQueueDate = startQueueDate.AddDays(1);
            var deskTypeIdList = queueDeskTypeList.Select(p => (int?)p.Id).ToList();

            var queueList = (from queue in this.queueEntityRepository.EntityQueryable
                             where queue.SupplierId == supplierId && queue.State == 1 && queue.Time >= startQueueDate
                                 && queue.Time < endQueueDate && deskTypeIdList.Contains(queue.DeskTypeId)
                             select new
                             {
                                 queue.DeskTypeId,
                                 queue.Number
                             }).ToList();

            var modelList = queueDeskTypeList.Select(p => new QueueDeskModel
            {
                Id = p.Id,
                BoxName = p.BoxName,
                Description = p.Description,
                DeskTypeName = p.DeskTypeName,
                MaxNumber = p.MaxNumber,
                MinNumber = p.MinNumber,
                RoomType = p.RoomType,
                TblTypeId = p.TableTypeId,
                TblTypeName = p.TblTypeName,
                QueueNumber = queueList.Count(q => q.DeskTypeId == p.Id)
            }).ToList();

            return new ServicesResultList<QueueDeskModel>
            {
                Result = modelList
            };
        }

        /// <summary>
        /// 保存排队信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回排队号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:34 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> SaveQueueDesk(string source, SaveQueueDeskParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = string.Empty
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = string.Empty
                };
            }

            var supplierId = parameter.SupplierId;
            if (!this.queueEntityRepository.EntityQueryable.Any(p => p.DeskTypeId == parameter.DeskTypeId && p.SupplierId == supplierId))
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.NotFondDeskTypeCode,
                    Result = string.Empty
                };
            }

            if (this.queueEntityRepository.EntityQueryable.Any(p => p.DeskTypeId == parameter.DeskTypeId && p.SupplierId == supplierId && p.LoginId == parameter.UserId))
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.AleadyQueueCode,
                    Result = string.Empty
                };
            }

            var supplierEntity = this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId)
                .Select(p => new { p.SupplierId, p.SupplierName })
                .FirstOrDefault();
            /*判断餐厅Id是否存在*/
            if (supplierEntity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = string.Empty
                };
            }

            var queueEntity = new QueueEntity
                {
                    DeskTypeId = parameter.DeskTypeId,
                    UserName = parameter.UserName,
                    Phone = parameter.Telephone,
                    Sex = parameter.Gender,
                    SupplierId = supplierEntity.SupplierId,
                    SupplierName = supplierEntity.SupplierName,
                    SeatNumber = parameter.SeatNumber,
                    LoginId = parameter.UserId,
                    Remark = parameter.Description,
                    Number = ServicesCommon.QueueNumberPrefix + (this.queueEntityRepository.EntityQueryable.Count(p => p.SupplierId == supplierId) + 1).ToString().PadLeft(ServicesCommon.QueueNumberLength, '0')
                };

            this.queueEntityRepository.Save(queueEntity);

            return new ServicesResult<string>
            {
                Result = queueEntity.Number
            };
        }

        /// <summary>
        /// 保存排队信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回排队号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:34 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CheckQueueDeskState(string source, CheckQueueDeskStateParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = false
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            var supplierId = parameter.SupplierId;
            if (!this.queueEntityRepository.EntityQueryable.Any(p => p.DeskTypeId == parameter.DeskTypeId && p.SupplierId == supplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.NotFondDeskTypeCode,
                    Result = false
                };
            }

            var result = this.queueEntityRepository.EntityQueryable.Any(p => p.DeskTypeId == parameter.DeskTypeId && p.SupplierId == supplierId && p.LoginId == parameter.UserId);
            return new ServicesResult<bool>
            {
                Result = result
            };
        }

        /// <summary>
        /// 取得排队详情信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="queueId">排队Id</param>
        /// <returns>
        /// 返回排队详情信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:34 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<QueueModel> GetQueue(string source, int queueId)
        {
            if (!this.queueEntityRepository.EntityQueryable.Any(p => p.QueueId == queueId))
            {
                return new ServicesResult<QueueModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidQueueIdCode,
                    Result = new QueueModel()
                };
            }

            var result = (from queueEntity in this.queueEntityRepository.EntityQueryable.Where(p => p.QueueId == queueId)
                          from deskType in this.deskTypeEntityRepository.EntityQueryable
                          where queueEntity.DeskTypeId == deskType.Id
                          select new QueueModel
                              {
                                  QueueId = queueEntity.QueueId,
                                  BoxName = deskType.BoxName,
                                  DeskTypeDescription = deskType.Description,
                                  DeskTypeId = deskType.Id,
                                  DeskTypeName = deskType.DeskTypeName,
                                  Gender = queueEntity.Sex,
                                  MaxNumber = deskType.MaxNumber,
                                  MinNumber = deskType.MinNumber,
                                  Number = queueEntity.Number,
                                  QueueDescription = queueEntity.Remark,
                                  QueueStateId = queueEntity.State,
                                  RoomType = deskType.RoomType,
                                  SeatNumber = queueEntity.SeatNumber,
                                  SupplierId = queueEntity.SupplierId,
                                  SupplierName = queueEntity.SupplierName,
                                  TblTypeId = deskType.TableType.Id,
                                  TblTypeName = deskType.TableType.TblTypeName,
                                  Telephone = queueEntity.Phone,
                                  UserName = queueEntity.UserName
                              }).FirstOrDefault();

            return new ServicesResult<QueueModel>
            {
                Result = result ?? new QueueModel()
            };
        }
    }
}