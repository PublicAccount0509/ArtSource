namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：GetCustomerAddressResponse
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：取得用户地址返回结果
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/16 23:57
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetCustomerAddressResponse : ApiResponse
    {
        /// <summary>
        /// Gets or sets the Result of GetCustomerAddressResponse
        /// </summary>
        /// <value>
        /// The Result
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/7/2013 9:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CustomerAddress Result { get; set; }
    }
}