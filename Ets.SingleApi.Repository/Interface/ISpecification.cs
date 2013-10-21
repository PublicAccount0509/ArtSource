namespace Ets.SingleApi.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// 接口名称：ISpecification
    /// 命名空间：Ets.SingleApi.Repository
    /// 接口功能：创建一个LINQ表达式
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// 创建者：周超
    /// 创建日期：2013/10/10 10:10
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    internal interface ISpecification<TEntity> where TEntity : class ,new()
    {
        /// <summary>
        /// Satisfyings the element from.
        /// </summary>
        /// <param name="queryable">The queryable</param>
        /// <returns>
        /// 实体对象
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        TEntity SatisfyingElementFrom(IQueryable<TEntity> queryable);

        /// <summary>
        /// Satisfyings the elements from.
        /// </summary>
        /// <param name="queryable">The queryable</param>
        /// <returns>
        /// IQueryable{TEntity}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        IQueryable<TEntity> SatisfyingElementsFrom(IQueryable<TEntity> queryable);

        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Expression<Func<TEntity, bool>> Expression { get; }
    }
}