namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IShoppingCartService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：ShoppingCart服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IShoppingCartService
    {
        /// <summary>
        /// 更改购物车状态
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="complete">The  complete indicates whether</param>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：更改购物车状态；参数说明：id（购物车Id），complete（是否完成），orderId（订单号），orderType（订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付）；")]
        Response<bool> SaveShoppingCartComplete(string id, bool complete, int orderId = 0, int orderType = 0);

        /// <summary>
        /// 取得购物车是否完成的状态
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回购物车状态
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得购物车是否完成的状态；参数说明：id（购物车Id），orderId（订单号），orderType（订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付）；")]
        Response<bool> GetShoppingCartComplete(string id, int orderId = 0, int orderType = 0);

        /// <summary>
        /// 取得购物车Id
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回购物车Id
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得购物车Id；参数说明：id（购物车Id），orderType（订单类型：0 外卖，1 堂食，2 订台，3 排队，4 当面付）；")]
        Response<string> GetShoppingCartId(int orderId, int orderType = 0);
    }
}