namespace Ets.SingleApi.Services
{
    using System;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：HtjExtendServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：公用功能信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:29 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HtjExtendServices : IHtjExtendServices
    {
        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/11/2013 11:03 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段wxToEtsEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/11/2013 11:15 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<WxToEtsEntity> wxToEtsEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtjExtendServices" /> class.
        /// </summary>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="wxToEtsEntityRepository">The wxToEtsEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HtjExtendServices(
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<WxToEtsEntity> wxToEtsEntityRepository)
        {
            this.customerEntityRepository = customerEntityRepository;
            this.wxToEtsEntityRepository = wxToEtsEntityRepository;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">参数</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<HtjUserExtendModel> Register(string source, HtjRegisterUserParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<HtjUserExtendModel>
                {
                    Result = new HtjUserExtendModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<HtjUserExtendModel>
                {
                    Result = new HtjUserExtendModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode
                };
            }

            var wxToEtsEntity = this.wxToEtsEntityRepository.FindSingleByExpression(
                                    p => p.WeChatId == parameter.WeChatId && p.LoginId == parameter.UserId);

            if (wxToEtsEntity != null)
            {
                return new ServicesResult<HtjUserExtendModel>
                {
                    Result = new HtjUserExtendModel
                        {
                            WeChatId = wxToEtsEntity.WeChatId,
                            UserId = wxToEtsEntity.LoginId,
                            InsBy = wxToEtsEntity.InsBy,
                            InsDt = wxToEtsEntity.InsDt,
                            Recsts = wxToEtsEntity.Recsts,
                            SourceCd = wxToEtsEntity.SourceCd,
                            UpdBy = wxToEtsEntity.UpdBy,
                            UpdDt = wxToEtsEntity.UpdDt
                        }
                };
            }

            var newWxToEtsEntity = new WxToEtsEntity
                 {
                     WeChatId = parameter.WeChatId,
                     LoginId = parameter.UserId,
                     InsBy = parameter.InsBy,
                     InsDt = DateTime.Now,
                     Recsts = parameter.Recsts,
                     SourceCd = parameter.SourceCd,
                     UpdBy = parameter.UpdBy,
                     UpdDt = DateTime.Now
                 };

            this.wxToEtsEntityRepository.Save(newWxToEtsEntity);

            return new ServicesResult<HtjUserExtendModel>
            {
                Result = new HtjUserExtendModel
                {
                    WeChatId = newWxToEtsEntity.WeChatId,
                    UserId = newWxToEtsEntity.LoginId,
                    InsBy = newWxToEtsEntity.InsBy,
                    InsDt = newWxToEtsEntity.InsDt,
                    Recsts = newWxToEtsEntity.Recsts,
                    SourceCd = newWxToEtsEntity.SourceCd,
                    UpdBy = newWxToEtsEntity.UpdBy,
                    UpdDt = newWxToEtsEntity.UpdDt
                }
            };
        }

        /// <summary>
        /// 用户关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="weChatId">The weChatId</param>
        /// <param name="sourceCd">The sourceCd</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 4:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<HtjUserExtendModel> GetUser(string source, string weChatId, string sourceCd)
        {
            var wxToEtsEntity = this.wxToEtsEntityRepository.FindSingleByExpression(p => p.WeChatId == weChatId && p.SourceCd == sourceCd);
            if (wxToEtsEntity == null)
            {
                return new ServicesResult<HtjUserExtendModel>
                    {
                        Result = new HtjUserExtendModel(),
                        StatusCode = (int)StatusCode.Succeed.Empty
                    };
            }

            return new ServicesResult<HtjUserExtendModel>
            {
                Result = new HtjUserExtendModel
                {
                    WeChatId = wxToEtsEntity.WeChatId,
                    UserId = wxToEtsEntity.LoginId,
                    InsBy = wxToEtsEntity.InsBy,
                    InsDt = wxToEtsEntity.InsDt,
                    Recsts = wxToEtsEntity.Recsts,
                    SourceCd = wxToEtsEntity.SourceCd,
                    UpdBy = wxToEtsEntity.UpdBy,
                    UpdDt = wxToEtsEntity.UpdDt
                }
            };
        }
    }
}