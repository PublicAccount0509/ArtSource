namespace Ets.SingleApi.Services.IDetailServices
{
    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IHaiDiLaoSupplierDetailServices
    /// 命名空间：Ets.SingleApi.Services.IDetailServices
    /// 接口功能：餐厅详细功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 8:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IHaiDiLaoSupplierDetailServices
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
    }
}