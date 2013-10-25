namespace Ets.SingleApi.Services
{
    using System;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;

    /// <summary>
    /// 类名称：CuisineServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：提供菜品信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 15:21
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CuisineServices : ICuisineServices
    {
        /// <summary>
        /// 字段cuisineEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 9:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CuisineEntity> cuisineEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuisineServices" /> class.
        /// </summary>
        /// <param name="cuisineEntityRepository">The cuisineEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CuisineServices(
            INHibernateRepository<CuisineEntity> cuisineEntityRepository)
        {
            this.cuisineEntityRepository = cuisineEntityRepository;
        }

        /// <summary>
        /// 获取菜品信息列表
        /// </summary>
        /// <returns>
        /// 返回菜品信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<CuisineModel> GetCuisineList()
        {
            throw new Exception();
            var cuisineList = (from cuisine in this.cuisineEntityRepository.EntityQueryable
                               select new
                               {
                                   cuisine.CuisineId,
                                   cuisine.CuisineName,
                                   cuisine.CuisineNo,
                                   cuisine.SupplierCuisineList.Count
                               }).ToList().OrderByDescending(p => p.Count).ToList();

            var result = cuisineList.Select(p => new CuisineModel
                            {
                                CuisineId = p.CuisineId,
                                CuisineName = p.CuisineName,
                                CuisineNo = p.CuisineNo,
                                SupplierCount = p.Count
                            }).ToList();

            return new ServicesResultList<CuisineModel> { Result = result };
        }
    }
}