namespace Ets.SingleApi.Utility
{
    using System;
    using System.Configuration;

    using Memcached.ClientLibrary;

    /// <summary>
    /// 类名称：CacheUtility
    /// 命名空间：Ets.SingleApi.Utility
    /// 类功能：缓存类
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 20:34
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CacheUtility
    {
        /// <summary>
        /// 字段instance
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/10 9:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private static CacheUtility instance;

        /// <summary>
        /// 缓存客户端
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly MemcachedClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheUtility"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected CacheUtility()
        {
            var serverlist = ConfigurationManager.AppSettings["Memcached.ServerList"].Split(',');
            try
            {
                var pool = SockIOPool.GetInstance();
                pool.SetServers(serverlist);
                pool.InitConnections = 3;
                pool.MinConnections = 3;
                pool.MaxConnections = 50;
                pool.SocketConnectTimeout = 1000;
                pool.SocketTimeout = 3000;
                pool.MaintenanceSleep = 30;
                pool.Failover = true;
                pool.Nagle = false;
                pool.Initialize();

                this.client = new MemcachedClient();
            }
            catch (Exception ex)
            {
                ex.WriteLog("");
            }
        }

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Add(string key, object value)
        {
            if (!this.client.KeyExists(key))
            {
                this.client.Add(key, value);
                return;
            }

            this.client.Set(key, value);
        }

        /// <summary>
        /// 添加缓存，并设置过期时间
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <param name="expiredTime">过期时间</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Add(string key, object value, DateTime expiredTime)
        {
            this.client.Add(key, value, expiredTime);
        }

        /// <summary>
        /// 修改缓存的值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Replace(string key, object value)
        {
            this.client.Replace(key, value);
        }

        /// <summary>
        /// 修改缓存的值，并设置过期时间
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <param name="expiredTime">过期时间</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Replace(string key, object value, DateTime expiredTime)
        {
            this.client.Replace(key, value, expiredTime);
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Set(string key, object value)
        {
            this.client.Set(key, value);
        }

        /// <summary>
        /// 设置缓存，并修改过期时间
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="value">值</param>
        /// <param name="expiredTime">过期时间</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Set(string key, object value, DateTime expiredTime)
        {
            this.client.Set(key, value, expiredTime);
        }

        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">关键字</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public void Delete(string key)
        {
            this.client.Delete(key);
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>
        /// 缓存的值
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public object Get(string key)
        {
            return this.client.Get(key);
        }

        /// <summary>
        /// 缓存是否存在
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>
        /// True存在，False不存在
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 20:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool Exists(string key)
        {
            return this.client.KeyExists(key);
        }

        /// <summary>
        /// 注册缓存
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:02
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void Register()
        {
            if (instance == null)
            {
                instance = new CacheUtility();
            }
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns>
        /// 返回实例
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 20:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static CacheUtility GetInstance()
        {
            return instance;
        }
    }
}