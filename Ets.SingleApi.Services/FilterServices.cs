namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;

    /// <summary>
    /// 类名称：FilterServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：Filter需要的功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/29/2013 5:52 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FilterServices : IFilterServices
    {
        /// <summary>
        /// 字段appEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:38 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<AppEntity> appEntityRepository;

        /// <summary>
        /// 字段tokenEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TokenEntity> tokenEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FilterServices" /> class.
        /// </summary>
        /// <param name="appEntityRepository">The appEntityRepository</param>
        /// <param name="tokenEntityRepository">The tokenEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public FilterServices(
            INHibernateRepository<AppEntity> appEntityRepository,
            INHibernateRepository<TokenEntity> tokenEntityRepository)
        {
            this.appEntityRepository = appEntityRepository;
            this.tokenEntityRepository = tokenEntityRepository;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="accessToken">The accessToken</param>
        /// <returns>
        /// ServicesResult{TokenModel}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<TokenModel> GetToken(string accessToken)
        {
            var tokenModel = this.tokenEntityRepository.EntityQueryable.Where(p => p.AccessToken == accessToken)
                  .Select(p => new TokenModel
                      {
                          AccessToken = p.AccessToken,
                          TokenDateTime = p.CreatedTime,
                          UserId = p.UserId
                      }).FirstOrDefault() ?? new TokenModel();

            return new ServicesResult<TokenModel>
                {
                    Result = tokenModel
                };
        }

        /// <summary>
        /// 验证客户端
        /// </summary>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/30/2013 2:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> ValidateApp(string appKey, string appPassword)
        {
            var appEntity = this.appEntityRepository.EntityQueryable.FirstOrDefault(p => p.AppKey == appKey && p.AppSecret == appPassword);
            return new ServicesResult<bool>
            {
                Result = appEntity != null
            };
        }
    }
}
