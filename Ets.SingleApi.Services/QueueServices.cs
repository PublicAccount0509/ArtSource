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
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository,
            INHibernateRepository<QueueDeskTypeLockLogEntity> queueDeskTypeLockLogEntityRepository,
            INHibernateRepository<QueueEntity> queueEntityRepository)
        {
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
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
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
    }
}