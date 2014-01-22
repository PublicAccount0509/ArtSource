namespace Ets.SingleApi.Services.IDetailServices
{
    using System;

    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：ISupplierDetailServices
    /// 命名空间：Ets.SingleApi.Services.IDetailServices
    /// 接口功能：餐厅详细功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 8:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ISupplierDetailServices
    {
        /// <summary>
        /// 添加餐厅菜品信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<bool> AddSupplierCuisine(SaveSupplierCuisineParameter parameter);

        /// <summary>
        /// 更新菜品信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<bool> UpdateSupplierCuisine(SaveSupplierCuisineParameter parameter);

        /// <summary>
        /// 删除菜品信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<bool> DeleteSupplierCuisine(DeleteSupplierCuisineParameter parameter);

        /// <summary>
        /// 添加餐厅菜信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<bool> AddSupplierDish(SaveSupplierDishParameter parameter);

        /// <summary>
        /// 更新菜信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<bool> UpdateSupplierDish(SaveSupplierDishParameter parameter);

        /// <summary>
        /// 删除菜信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResult<bool> DeleteSupplierDish(DeleteSupplierDishParameter parameter);

        /// <summary>
        /// 取得餐厅营业时间
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="startServiceDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="beginReadyTime">备餐时间</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResultList<SupplierServiceTimeModel> GetSupplierServiceTime(
            int supplierId, DateTime startServiceDate, int days, int beginReadyTime, bool onlyActive);

        /// <summary>
        /// 取得餐厅送餐时间
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="startDeliveryDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="beginReadyTime">备餐时间</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        DetailServicesResultList<SupplierDeliveryTimeModel> GetSupplierDeliveryTime(
            int supplierId, DateTime startDeliveryDate, int days, int beginReadyTime, bool onlyActive);

        /// <summary>
        /// 根据百度坐标计算距离
        /// </summary>
        /// <param name="baidulat">The baidulat</param>
        /// <param name="baidulong">The baidulong</param>
        /// <returns>
        /// Int32}
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：1/21/2014 11:23 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        dynamic CalculateSpaceLatLong(double baidulat, double baidulong);
    }
}