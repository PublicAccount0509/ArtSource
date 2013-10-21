namespace Ets.SingleApi.Repository
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// 类名称：ExpressionSpec
    /// 命名空间：Ets.SingleApi.Repository
    /// 类功能：获取一个LINQ表达式
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// 创建者：周超
    /// 创建日期：2013/10/10 10:06
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    internal class ExpressionSpec<TEntity> : Specification<TEntity> where TEntity : class ,new()
    {
        /// <summary>
        /// 字段expression
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly Expression<Func<TEntity, bool>> expression;

        /// <summary>
        /// Gets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override Expression<Func<TEntity, bool>> Expression
        {
            get { return this.expression; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionSpec{TEntity}"/> class.
        /// </summary>
        /// <param name="expression">The expression</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 10:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ExpressionSpec(Expression<Func<TEntity, bool>> expression)
        {
            this.expression = expression;
        }
    }
}
