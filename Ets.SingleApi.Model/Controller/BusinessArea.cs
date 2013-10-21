namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：BusinessArea
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:38
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BusinessArea
    {
        /// <summary>
        /// Gets or sets the Name of BusinessArea
        /// </summary>
        /// <value>
        /// The Name
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:39
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Code of BusinessArea
        /// </summary>
        /// <value>
        /// The Code
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 12:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the Depth of BusinessArea
        /// </summary>
        /// <value>
        /// The Depth
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 17:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the ParentCode of BusinessArea
        /// </summary>
        /// <value>
        /// The ParentCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 17:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ParentCode { get; set; }
    }
}