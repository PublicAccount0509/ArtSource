namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：ITestService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：测试服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface ITestService
    {
        /// <summary>
        /// GET测试方法
        /// </summary>
        /// <returns>
        /// 返回测试结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：GET测试方法")]
        Response<string> GetTest();

        /// <summary>
        /// POST测试方法
        /// </summary>
        /// <returns>
        /// 返回测试结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:54 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：POST测试方法")]
        Response<string> PostTest();
    }
}