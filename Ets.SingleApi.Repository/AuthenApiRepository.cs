namespace Ets.SingleApi.Repository
{
    using System.Configuration;
    using Castle.Facilities.NHibernateIntegration;

    /// <summary>
    /// 类名称：AuthenApiRepository
    /// 命名空间：Ets.SingleApi.Repository
    /// 类功能：创建一个仓储实例
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// 创建者：周超
    /// 创建日期：2013/10/10 10:01
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AuthenApiRepository<TEntity> : NHibernateRepository<TEntity> where TEntity : class ,new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenApiRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="sessionManager">The sessionManager</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public AuthenApiRepository(ISessionManager sessionManager)
            : base(sessionManager, "AuthenApiFactory")
        {
        }

        /// <summary>
        /// Converts the local time to UTC.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected override void ConvertLocalTimeToUtc(TEntity entity)
        {
            //if (entity == null)
            //{
            //    return;
            //}
            //foreach (var property in entity.GetType().GetProperties().Where(info => info.CanRead && info.CanWrite && info.PropertyType.Name == "DateTime"))
            //{
            //    var value = property.GetValue(entity, null);
            //    property.SetValue(entity, Convert.ToDateTime(value).ToUniversalTime(), null);
            //}
        }

        /// <summary>
        /// Converts the kind to UTC.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected override void ConvertKindToUtc(TEntity entity)
        {
            //if (entity == null)
            //{
            //    return;
            //}
            //foreach (var property in entity.GetType().GetProperties().Where(info => info.CanRead && info.CanWrite && info.PropertyType.Name == "DateTime"))
            //{
            //    var value = property.GetValue(entity, null);
            //    property.SetValue(entity, DateTime.SpecifyKind(Convert.ToDateTime(value), DateTimeKind.Utc), null);
            //}
        }
    }
}
