using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;

namespace Ets.SingleApi.Services.IRepository
{
    /// <summary>
    /// Interface:INHibernateRepository&lt;TEntity&gt;
    /// Namespace:Ets.SingleApi.Services.IRepository
    /// Interface Funtion:
    /// Provide some methods about database.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// Creator:zhouchao
    /// Creation Date:8/11/2011 3:07 PM
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    public interface INHibernateRepository<TEntity> where TEntity : class ,new()
    {
        /// <summary>
        /// Gets the entity queryable.
        /// </summary>
        /// <value>
        /// The entity queryable.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        IQueryable<TEntity> EntityQueryable { get; }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Create(TEntity entity);

        /// <summary>
        /// 批量写入数据 
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void CreateTransaction(List<TEntity> entityList);

        /// <summary>
        /// 批量写入数据 
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Create(List<TEntity> entityList);

        /// <summary>
        /// 删除数据 
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Remove(TEntity entity);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void RemoveTransaction(List<TEntity> entityList);

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Remove(List<TEntity> entityList);

        /// <summary>
        /// 修改数据 
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:46
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Update(TEntity entity);

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void UpdateTransaction(List<TEntity> entityList);

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Update(List<TEntity> entityList);

        /// <summary>
        /// 新增或修改数据
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Save(TEntity entity);

        /// <summary>
        /// 批量新增或修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void SaveTransaction(List<TEntity> entityList);

        /// <summary>
        /// 批量新增或修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        void Save(List<TEntity> entityList);

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns>
        /// 返回对象集合
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        IList<TEntity> FindAll();

        /// <summary>
        /// 根据主键查询数据
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>
        /// `返回实体对象
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        TEntity FindById(object id);

        /// <summary>
        /// 根据表达式查询数据
        /// </summary>
        /// <param name="expression">The expression</param>
        /// <returns>
        /// 返回对象集合
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        IList<TEntity> FindByExpression(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 根据表达式查询单条数据
        /// </summary>
        /// <param name="expression">The expression</param>
        /// <returns>
        /// `返回实体对象
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:50
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        TEntity FindSingleByExpression(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Finds the i query by SQL.
        /// </summary>
        /// <param name="querystring">The querystring</param>
        /// <returns>
        /// The IQuery
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        IQuery SqlIQuery(string querystring);

        /// <summary>
        /// Hs the SQL i query.
        /// </summary>
        /// <param name="querystring">The querystring</param>
        /// <returns>
        /// IQuery
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 14:16
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        IQuery HSqlIQuery(string querystring);

        /// <summary>
        /// Nameds the query.
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>
        /// IQuery
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/18 17:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        IQuery NamedQuery(string name);
    }
}