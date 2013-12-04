namespace Ets.SingleApi.Services
{
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
        /// 字段supplierCuisineEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/25/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCuisineEntity> supplierCuisineEntityRepository;

        /// <summary>
        /// 字段supplierBusinessAreaEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/25/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierBusinessAreaEntity> supplierBusinessAreaEntityRepository;

        /// <summary>
        /// 字段regionEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/25/2013 3:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<RegionEntity> regionEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuisineServices" /> class.
        /// </summary>
        /// <param name="cuisineEntityRepository">The cuisineEntityRepository</param>
        /// <param name="supplierCuisineEntityRepository">The supplierCuisineEntityRepository</param>
        /// <param name="supplierBusinessAreaEntityRepository">The supplierBusinessAreaEntityRepository</param>
        /// <param name="regionEntityRepository">The regionEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CuisineServices(
            INHibernateRepository<CuisineEntity> cuisineEntityRepository,
            INHibernateRepository<SupplierCuisineEntity> supplierCuisineEntityRepository,
            INHibernateRepository<SupplierBusinessAreaEntity> supplierBusinessAreaEntityRepository,
            INHibernateRepository<RegionEntity> regionEntityRepository)
        {
            this.cuisineEntityRepository = cuisineEntityRepository;
            this.supplierCuisineEntityRepository = supplierCuisineEntityRepository;
            this.supplierBusinessAreaEntityRepository = supplierBusinessAreaEntityRepository;
            this.regionEntityRepository = regionEntityRepository;
        }

        /// <summary>
        /// 获取菜品信息列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>
        /// 返回菜品信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<CuisineModel> GetCuisineList(string source)
        {
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

            return new ServicesResultList<CuisineModel> { ResultTotalCount = result.Count, Result = result };
        }

        /// <summary>
        /// 获取菜品信息列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="cityId">城市Id</param>
        /// <returns>
        /// 返回菜品信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<CuisineModel> GetCityCuisineList(string source, int cityId)
        {
            var cuisineList = (from regionEntity in this.regionEntityRepository.EntityQueryable
                               from supplierBusinessArea in this.supplierBusinessAreaEntityRepository.EntityQueryable
                               from supplierCuisine in this.supplierCuisineEntityRepository.EntityQueryable
                               from cuisine in this.cuisineEntityRepository.EntityQueryable
                               where (regionEntity.CityId == cityId || regionEntity.ProvinceId == cityId)
                               && supplierBusinessArea.BusinessArea.RegionCode == regionEntity.Code
                               && supplierCuisine.Supplier.SupplierId == supplierBusinessArea.Supplier.SupplierId
                               && supplierCuisine.Cuisine.CuisineId == cuisine.CuisineId
                               select new
                                                  {
                                                      cuisine.CuisineId,
                                                      cuisine.CuisineName,
                                                      cuisine.CuisineNo,
                                                      supplierCuisine.Supplier.SupplierId
                                                  }).ToList();


            var cuisineIdList = cuisineList.Select(p => p.CuisineId).Distinct().ToList();
            var result = (from cuisineId in cuisineIdList
                          let cuisine = cuisineList.FirstOrDefault(p => p.CuisineId == cuisineId)
                          where cuisine != null
                          let count = cuisineList.Where(p => p.CuisineId == cuisineId).Select(p => p.SupplierId).Distinct().Count()
                          select new CuisineModel
                              {
                                  CuisineId = cuisine.CuisineId,
                                  CuisineName = cuisine.CuisineName,
                                  CuisineNo = cuisine.CuisineNo,
                                  SupplierCount = count
                              }).ToList();

            return new ServicesResultList<CuisineModel> { ResultTotalCount = result.Count, Result = result };
        }
    }
}