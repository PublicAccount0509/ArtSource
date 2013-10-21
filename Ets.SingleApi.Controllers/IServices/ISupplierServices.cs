namespace Ets.SingleApi.Controllers.IServices
{
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
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<SupplierDetailModel> GetSupplier(int supplierId);
        
        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<SupplierModel> GetSupplierList(GetSupplierListParameter parameter);

        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
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
        ServicesResultList<SupplierCuisineModel> GetMenu(int supplierId, int supplierMenuCategoryTypeId);
    }
}