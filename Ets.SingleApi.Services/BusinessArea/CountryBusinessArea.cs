namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;

    /// <summary>
    /// 类名称：CountryBusinessArea
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：获取国家信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 15:12
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CountryBusinessArea : BusinessArea
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryBusinessArea"/> class.
        /// </summary>
        /// <param name="regionEntityRepository">The regionEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CountryBusinessArea(INHibernateRepository<RegionEntity> regionEntityRepository)
            : base(regionEntityRepository)
        {
        }

        /// <summary>
        /// Gets the type of the area.
        /// </summary>
        /// <value>
        /// The type of the area.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override AreaType AreaType
        {
            get
            {
                return AreaType.Country;
            }
        }
    }
}