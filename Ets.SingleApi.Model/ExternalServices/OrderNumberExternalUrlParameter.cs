namespace Ets.SingleApi.Model.ExternalServices
{
    /// <summary>
    /// 类名称：OrderNumberExternalUrlParameter
    /// 命名空间：Ets.SingleApi.Model.ExternalServices
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/28/2014 5:21 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OrderNumberExternalUrlParameter : IExternalUrlParameter
    {
        /// <summary>
        /// 设置或取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：王巍
        /// 创建日期：12/13/2013 1:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }
    }
}
