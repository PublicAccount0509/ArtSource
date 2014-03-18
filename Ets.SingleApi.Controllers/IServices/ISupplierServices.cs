namespace Ets.SingleApi.Controllers.IServices
{
    using System;
    using System.Collections.Generic;

    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：ISupplierServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 21:56
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISupplierServices
    {
        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="cityCode">城市Code</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<SupplierDetailModel> GetSupplier(string source, int supplierId, string cityCode);

        /// <summary>
        /// 获取餐厅基本信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<SupplierSimpleModel> GetSupplierSimple(string source, int supplierId);

        /// <summary>
        /// 根据餐厅域名获取餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierDomain">餐厅域名</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<RoughSupplierModel> GetRoughSupplier(string source, string supplierDomain);

        /// <summary>
        /// 取得打包费
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="dishList">菜品信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 12:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<decimal> GetPackagingFee(string source, int supplierId, List<PackagingFeeItem> dishList);

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierModel> GetSupplierList(string source, GetSupplierListParameter parameter);

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierModel> GetSearchSupplierList(string source, GetSearchSupplierListParameter parameter);

        /// <summary>
        /// 获取餐厅分店列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅分店列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:38 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<GroupSupplierModel> GetGroupSupplierList(string source, GetGroupSupplierListParameter parameter);

        /// <summary>
        /// 获取餐厅分店列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅分店列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:38 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<GroupSupplierModel> GetSearchGroupSupplierList(string source, GetSearchGroupSupplierListParameter parameter);

        /// <summary>
        /// 获取餐厅已经开通的功能列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回餐厅已经开通的功能列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierFeatureModel> GetSupplierFeatureList(string source, int supplierId);

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
        /// 取得赠品菜
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/18/2013 11:59 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierDishModel> GetPresentDishList(string source, int supplierId);

        /// <summary>
        /// 获取餐厅菜品类型信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型</param>
        /// <returns>
        /// 返回餐厅菜品类型信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierCuisineDetailModel> GetSupplierCuisineList(string source, int supplierId, int supplierMenuCategoryTypeId);

        /// <summary>
        /// 获取餐厅菜品类型信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierCategoryId">The supplierCategoryId</param>
        /// <returns>
        /// 返回餐厅菜品类型信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<SupplierCuisineDetailModel> GetSupplierCuisine(string source, int supplierId, int supplierCategoryId);

        /// <summary>
        /// 添加餐厅菜品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AddSupplierCuisine(string source, SaveSupplierCuisineParameter parameter);

        /// <summary>
        /// 更新菜品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> UpdateSupplierCuisine(string source, SaveSupplierCuisineParameter parameter);

        /// <summary>
        /// 删除菜品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> DeleteSupplierCuisine(string source, DeleteSupplierCuisineParameter parameter);

        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型</param>
        /// <param name="supplierCategoryId">The supplierCategoryId</param>
        /// <returns>
        /// 返回餐厅菜单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierDishDetailModel> GetSupplierDishList(string source, int supplierId, int supplierMenuCategoryTypeId, int? supplierCategoryId);

        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierDishId">菜品Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id（1：外卖菜单、2：订台堂食菜单）</param>
        /// <returns>
        /// 返回餐厅菜单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<SupplierDishDetailModel> GetSupplierDish(string source, int supplierId, int supplierDishId, int supplierMenuCategoryTypeId);

        /// <summary>
        /// 添加餐厅菜信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AddSupplierDish(string source, SaveSupplierDishParameter parameter);

        /// <summary>
        /// 更新菜信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> UpdateSupplierDish(string source, SaveSupplierDishParameter parameter);

        /// <summary>
        /// 删除菜信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> DeleteSupplierDish(string source, DeleteSupplierDishParameter parameter);

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
        /// 创建者：周超
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
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierDeliveryTimeModel> GetSupplierDeliveryTime(
            string source, int supplierId, int deliveryMethodId, DateTime? startDeliveryDate, int? days, bool onlyActive);
        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parameter"></param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<DistanceModel> GetDistance(string source, DistanceParameter parameter);

        /// <summary>
        /// 获取订台台位列表
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 6:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<DingTaiDeskModel> GetDeskList(string source, DingTaiGetDeskListParameter parameter);
    }
}