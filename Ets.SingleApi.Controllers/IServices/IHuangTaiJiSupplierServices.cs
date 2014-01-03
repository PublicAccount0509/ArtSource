namespace Ets.SingleApi.Controllers.IServices
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IHuangTaiJiSupplierServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：黄太极餐厅服务
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 11:49 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IHuangTaiJiSupplierServices
    {
        /// <summary>
        /// 获取餐厅菜单明细信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierDishId">餐厅菜单Id</param>
        /// <returns>
        /// 返回餐厅菜单明细信息
        /// </returns>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<HuangTaiJiSupplierDishDetail> GetSupplierDish(string source, int supplierId, int supplierDishId);
        /// <summary>
        /// 获取餐厅菜单列表信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型</param>
        /// <param name="supplierCategoryId">餐厅菜单类别</param>
        /// <returns>
        /// 返回餐厅菜单列表信息
        /// </returns>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<HuangTaiJiSupplierDishDetail> GetSupplierDishList(string source, int supplierId, int supplierMenuCategoryTypeId, int? supplierCategoryId);
    }
}
