namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：ShoppingCartSupplierService
    /// 命名空间：Ets.SingleApi.Services.ShoppingCart
    /// 类功能：购物车餐厅供应商数据
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 10:27 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class ShoppingCartSupplierService : IShoppingCartBusinessService
    {
        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 10:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段supplierFeatureEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/21/2013 10:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartSupplierService"/> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="supplierFeatureEntityRepository">The supplierFeatureEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：11/21/2013 10:31 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartSupplierService(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.supplierFeatureEntityRepository = supplierFeatureEntityRepository;
        }

        /// <summary>
        /// 购物车类型
        /// </summary>
        /// <value>
        /// 购物车类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/21/2013 10:25 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BusinessType BusinessType
        {
            get
            {
                return BusinessType.Supplier;
            }
        }

        /// <summary>
        /// 取得供应商信息
        /// </summary>
        /// <param name="businessId">供应商Id</param>
        /// <returns>
        /// 供应商信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 10:25 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ShoppingCartResult<IShoppingCartBusiness> GetShoppingCartBusiness(int businessId)
        {
            var shoppingCartSupplier = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                        where supplierEntity.SupplierId == businessId
                                        select new ShoppingCartSupplier
                                        {
                                            SupplierId = supplierEntity.SupplierId,
                                            SupplierName = supplierEntity.SupplierName,
                                            Telephone = supplierEntity.Telephone,
                                            PackagingFee = supplierEntity.PackagingFee ?? 0,
                                            FixedDeliveryCharge = supplierEntity.FixedDeliveryCharge ?? 0,
                                            FreeDeliveryLine = supplierEntity.FreeDeliveryLine ?? 0,
                                            DelMinOrderAmount = supplierEntity.DelMinOrderAmount ?? 0,
                                            PackLadder = supplierEntity.PackLadder ?? 0
                                        }).FirstOrDefault();

            if (shoppingCartSupplier == null)
            {
                return new ShoppingCartResult<IShoppingCartBusiness>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                        Result = new ShoppingCartSupplier()
                    };
            }

            shoppingCartSupplier.IsPackLadder = this.supplierFeatureEntityRepository.EntityQueryable.Any(p => p.Supplier.SupplierId == businessId && p.IsEnabled == true && p.Feature.FeatureId == ServicesCommon.PackageFeatureId);
            return new ShoppingCartResult<IShoppingCartBusiness>
            {
                Result = shoppingCartSupplier
            };
        }
    }
}