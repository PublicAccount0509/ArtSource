namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：DistanceParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/12/2014 11:54 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DistanceParameter
    {
        /// <summary>
        /// 用户定位坐标
        /// </summary>
        /// <value>
        /// The LocationA
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：2/12/2014 1:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Location LocationA { get; set; }
        /// <summary>
        /// 店面坐标
        /// </summary>
        /// <value>
        /// The LocationB
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：2/12/2014 1:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Location LocationB { get; set; }
        /// <summary>
        /// 高斯投影
        /// </summary>
        /// <value>
        /// The Gs
        /// </value>
        /// 创建者：单琪彬
        /// 创建日期：2/12/2014 1:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public GaussSphere Gs { get; set; }
    }
}
