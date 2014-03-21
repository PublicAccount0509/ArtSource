namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IQueueServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：排队相关的方法
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 15:18
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IQueueServices
    {
        /// <summary>
        /// 获取可排队的台位类型列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回可排队的台位类型列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/21/2014 12:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<QueueDeskModel> GetQueueDeskList(string source, GetQueueDeskListParameter parameter);
    }
}