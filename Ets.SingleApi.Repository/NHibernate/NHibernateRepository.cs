namespace Ets.SingleApi.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Castle.Facilities.NHibernateIntegration;

    using Ets.SingleApi.Services.IRepository;

    using NHibernate;

    /// <summary>
    /// 类名称：NHibernateRepository
    /// 命名空间：Ets.SingleApi.Repository
    /// 类功能：实现一个仓储
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// 创建者：周超
    /// 创建日期：2013/10/10 9:55
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public abstract class NHibernateRepository<TEntity> : INHibernateRepository<TEntity> where TEntity : class ,new()
    {
        /// <summary>
        /// 字段sessionManager
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISessionManager sessionManager;

        /// <summary>
        /// 字段sessionFactoryAlias
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly string sessionFactoryAlias;

        /// <summary>
        /// Prevents a default instance of the <see cref="NHibernateRepository{TEntity}"/> class from being created.
        /// </summary>
        /// <param name="sessionManager">The sessionManager</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private NHibernateRepository(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="sessionManager">The sessionManager</param>
        /// <param name="alias">The alias</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:55
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected NHibernateRepository(ISessionManager sessionManager, string alias)
            : this(sessionManager)
        {
            this.sessionFactoryAlias = alias;
        }

        /// <summary>
        /// 创建一个ISession
        /// </summary>
        /// <returns>
        /// The ISession
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private ISession OpenSession()
        {
            return string.IsNullOrEmpty(this.sessionFactoryAlias) ? this.sessionManager.OpenSession() : this.sessionManager.OpenSession(this.sessionFactoryAlias);
        }

        /// <summary>
        /// Converts the local time to UTC.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected abstract void ConvertLocalTimeToUtc(TEntity entity);

        /// <summary>
        /// Converts the kind to UTC.
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected abstract void ConvertKindToUtc(TEntity entity);

        /// <summary>
        /// Gets the entity queryable.
        /// </summary>
        /// <value>
        /// The entity queryable.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public IQueryable<TEntity> EntityQueryable
        {
            get { return this.OpenSession().Linq<TEntity>(); }
        }

        /// <summary>
        /// 新增数据 
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Create(TEntity entity)
        {
            using (var session = this.OpenSession())
            {
                this.ConvertLocalTimeToUtc(entity);
                session.Save(entity);
                session.Flush();
            }
        }

        /// <summary>
        /// 批量新增数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void CreateTransaction(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    foreach (var entity in entityList)
                    {
                        this.ConvertLocalTimeToUtc(entity);
                        session.Save(entity);
                    }

                    tran.Commit();
                }
            }
        }

        /// <summary>
        /// 批量新增数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Create(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                foreach (var entity in entityList)
                {
                    this.ConvertLocalTimeToUtc(entity);
                    session.Save(entity);
                }

                session.Flush();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Remove(TEntity entity)
        {
            using (var session = this.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void RemoveTransaction(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    foreach (var entity in entityList)
                    {
                        session.Delete(entity);
                    }

                    tran.Commit();
                }
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Remove(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                foreach (var entity in entityList)
                {
                    session.Delete(entity);
                }

                session.Flush();
            }
        }

        /// <summary>
        /// 修改数据 
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Update(TEntity entity)
        {
            using (var session = this.OpenSession())
            {
                this.ConvertLocalTimeToUtc(entity);
                session.Update(entity);
                session.Flush();
            }
        }

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void UpdateTransaction(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    foreach (var entity in entityList)
                    {
                        this.ConvertLocalTimeToUtc(entity);
                        session.Update(entity);
                    }

                    tran.Commit();
                }
            }
        }

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Update(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                foreach (var entity in entityList)
                {
                    this.ConvertLocalTimeToUtc(entity);
                    session.Update(entity);
                }

                session.Flush();
            }
        }

        /// <summary>
        /// 新增或修改数据
        /// </summary>
        /// <param name="entity">The entity</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Save(TEntity entity)
        {
            using (var session = this.OpenSession())
            {
                this.ConvertLocalTimeToUtc(entity);
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        /// <summary>
        /// 批量新增或修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void SaveTransaction(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                using (var tran = session.BeginTransaction())
                {
                    foreach (var entity in entityList)
                    {
                        this.ConvertLocalTimeToUtc(entity);
                        session.SaveOrUpdate(entity);
                    }

                    tran.Commit();
                }
            }
        }

        /// <summary>
        /// 批量新增或修改数据
        /// </summary>
        /// <param name="entityList">The entityList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Save(List<TEntity> entityList)
        {
            if (entityList == null || entityList.Count == 0)
            {
                return;
            }

            using (var session = this.OpenSession())
            {
                foreach (var entity in entityList)
                {
                    this.ConvertLocalTimeToUtc(entity);
                    session.SaveOrUpdate(entity);
                }

                session.Flush();
            }
        }

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
        public IList<TEntity> FindAll()
        {
            using (var session = this.OpenSession())
            {
                var list = session.Linq<TEntity>().ToList();
                foreach (var entity in list)
                {
                    this.ConvertKindToUtc(entity);
                }
                return list;
            }
        }

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
        public TEntity FindById(object id)
        {
            using (var session = this.OpenSession())
            {
                return (TEntity)session.Get(typeof(TEntity), id);
            }
        }

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
        public IList<TEntity> FindByExpression(Expression<Func<TEntity, bool>> expression)
        {
            using (var session = this.OpenSession())
            {
                var specification = new ExpressionSpec<TEntity>(expression);
                var list = specification.SatisfyingElementsFrom(session.Linq<TEntity>()).ToList();
                foreach (var entity in list)
                {
                    this.ConvertKindToUtc(entity);
                }
                return list;
            }
        }

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
        public TEntity FindSingleByExpression(Expression<Func<TEntity, bool>> expression)
        {
            var entity = this.FindByExpression(expression).FirstOrDefault();
            if (entity != null)
            {
                this.ConvertKindToUtc(entity);
            }
            return entity;
        }

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
        public IQuery SqlIQuery(string querystring)
        {
            var query = this.OpenSession().CreateSQLQuery(querystring);
            return query;
        }

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
        public IQuery HSqlIQuery(string querystring)
        {
            var query = this.OpenSession().CreateQuery(querystring);
            return query;
        }

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
        public IQuery NamedQuery(string name)
        {
            var query = this.OpenSession().GetNamedQuery(name);
            return query;
        }
    }
}