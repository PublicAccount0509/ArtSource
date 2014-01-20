using System;

namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IHaiDiLaoSupplierServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：海底捞餐厅服务接口
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 22:09
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IHaiDiLaoSupplierServices
    {
        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型</param>
        /// <returns>
        /// 返回餐厅菜单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierCuisineModel> GetMenu(string source, int supplierId, int supplierMenuCategoryTypeId);

        /// <summary>
        /// 获取套餐详细信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="packageId">套餐Id</param>
        /// <returns>
        /// 返回套餐详细信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<PackageCuisineModel> GetPackageDetail(string source, int supplierId, int packageId);
        /// <summary>
        /// 取得餐厅营业时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <param name="startServiceDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierServiceTimeModel> GetSupplierServiceTime(string source,
            int supplierId, int deliveryMethodId, DateTime? startServiceDate, int? days, bool onlyActive);

        /// <summary>
        /// 取得餐厅送餐时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="startDeliveryDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierDeliveryTimeModel> GetSupplierDeliveryTime(
            string source, int supplierId, int deliveryMethodId, DateTime? startDeliveryDate, int? days, bool onlyActive);
    }
}