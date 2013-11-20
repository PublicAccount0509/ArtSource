namespace Ets.SingleApi.Services.IDetailServices
{
    using System.Collections.Generic;

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
    }
}