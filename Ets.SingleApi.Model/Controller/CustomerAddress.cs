namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：CustomerAddress
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：用户地址
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 18:03
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CustomerAddress
    {
        /// <summary>
        /// Gets or sets the CustomerAddressId of CustomerAddress
        /// </summary>
        /// <value>
        /// The CustomerAddressId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int CustomerAddressId { get; set; }

        /// <summary>
        /// Gets or sets the Name of CustomerAddress
        /// </summary>
        /// <value>
        /// The Name
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Sex of CustomerAddress
        /// </summary>
        /// <value>
        /// The Sex
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? Sex { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of CustomerAddress
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsDefault
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets the Address of CustomerAddress
        /// </summary>
        /// <value>
        /// The Address
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Building of CustomerAddressParameter
        /// </summary>
        /// <value>
        /// The Building
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/4/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Building { get; set; }

        /// <summary>
        /// Gets or sets the CityId of CustomerAddress
        /// </summary>
        /// <value>
        /// The CityId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CityId { get; set; }

        /// <summary>
        /// Gets or sets the ProvinceId of CustomerAddress
        /// </summary>
        /// <value>
        /// The ProvinceId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? ProvinceId { get; set; }

        /// <summary>
        /// Gets or sets the CountyId of CustomerAddress
        /// </summary>
        /// <value>
        /// The CountyId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CountyId { get; set; }

        /// <summary>
        /// Gets or sets the RegionCode of CustomerAddress
        /// </summary>
        /// <value>
        /// The RegionCode
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string RegionCode { get; set; }
    }
}