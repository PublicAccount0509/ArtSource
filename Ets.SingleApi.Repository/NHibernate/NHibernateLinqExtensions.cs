namespace Ets.SingleApi.Repository
{
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq;

    /// <summary>
    /// 类名称：NHibernateLinqExtensions
    /// 命名空间：Ets.SingleApi.Repository
    /// 类功能：创建一个适用于NHibernate的LINQ表达式
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/10 10:07
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public static class NHibernateLinqExtensions
    {
        /// <summary>
        /// 取得一个IQueryable{TEntity}
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="session">The session</param>
        /// <returns>
        /// The IQueryable{TEntity}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static IQueryable<TEntity> Linq<TEntity>(this ISession session)
        {
            return new NhQueryable<TEntity>(session.GetSessionImplementation());
        }

        /// <summary>
        /// 取得一个IQueryable{TEntity} 
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="session">The session</param>
        /// <returns>
        /// The IQueryable{TEntity}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static IQueryable<TEntity> Linq<TEntity>(this IStatelessSession session)
        {
            return new NhQueryable<TEntity>(session.GetSessionImplementation());
        } 
    }
}
