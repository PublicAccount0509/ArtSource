namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IOrdersService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Orders服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IOrdersService
    {
        /// <summary>
        /// 判定指定订单支付状态
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为0</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：判定指定订单支付状态；参数说明：id（订单号），orderType（订单类型：0 外卖，1 堂食，2 订台），orderSourceType（订单来源：0 默认类型，1 海底捞；默认为 0）；返回结果 0 不存在 1 支付 2 未支付")]
        Response<int> Exist(string id, int orderType, int orderSourceType);

        /// <summary>
        /// 取得外卖订单详情
        /// </summary>
        /// <param name="id">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得外卖订单详情；参数说明：id（订单号），orderType（订单类型：0 外卖，1 堂食，2 订台），orderSourceType（订单来源：0 默认类型，1 海底捞；默认为 0）")]
        Response<WaiMaiOrderDetailModel> GetOrder(string id, int orderType, int orderSourceType);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：保存订单信息；参数说明：shoppingCartId（购物车Id），orderType（订单类型：0 外卖，1 堂食，2 订台），orderSourceType（订单来源：0 默认类型，1 海底捞；默认为 0）；返回结果：订单号")]
        Response<string> SaveOrder(string shoppingCartId, int orderType, int orderSourceType);

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 8:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取订单号；参数说明：orderType（订单类型：0 外卖，1 堂食，2 订台），orderSourceType（订单来源：0 默认类型，1 海底捞；默认为 0）；返回结果：订单号")]
        Response<string> OrderNumber(int orderType, int orderSourceType);
    }
}