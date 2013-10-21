namespace Ets.SingleApi.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// 类名称：Specification
    /// 命名空间：Ets.SingleApi.Repository
    /// 类功能：创建一个LINQ表达式
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// 创建者：周超
    /// 创建日期：2013/10/10 10:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    internal abstract class Specification<TEntity> : ISpecification<TEntity> where TEntity : class ,new()
    {
        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public abstract Expression<Func<TEntity, bool>> Expression { get; }

        /// <summary>
        /// Satisfyings the element from.
        /// </summary>
        /// <param name="queryable">The queryable</param>
        /// <returns>
        /// `实体对象
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public TEntity SatisfyingElementFrom(IQueryable<TEntity> queryable)
        {
            return SatisfyingElementsFrom(queryable).Single();
        }

        /// <summary>
        /// Satisfyings the elements from.
        /// </summary>
        /// <param name="queryable">The queryable</param>
        /// <returns>
        /// IQueryable{TEntity}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IQueryable<TEntity> SatisfyingElementsFrom(IQueryable<TEntity> queryable)
        {
            return queryable.Where(Expression).AsQueryable();
        }
    }
}
