namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：DishImageModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：菜品图片
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 13:06
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DishImage
    {
        /// <summary>
        /// Gets or sets the ImagePath of DishImage
        /// </summary>
        /// <value>
        /// The ImagePath
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the Online of DishImage
        /// </summary>
        /// <value>
        /// The Online
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? Online { get; set; }

        /// <summary>
        /// Gets or sets the Position of DishImage
        /// </summary>
        /// <value>
        /// The Position
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the Width of DishImage
        /// </summary>
        /// <value>
        /// The Width
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the Height of DishImage
        /// </summary>
        /// <value>
        /// The Height
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? Height { get; set; }
    }
}