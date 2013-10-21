namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：BusinessAreaBusinessArea
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：商圈信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 16:36
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BusinessAreaBusinessArea : IBusinessArea
    {
        /// <summary>
        /// 字段regionEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:12
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<RegionEntity> regionEntityRepository;

        /// <summary>
        /// 字段addrBusinessAreaEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:32
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<AddrBusinessAreaEntity> addrBusinessAreaEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessAreaBusinessArea"/> class.
        /// </summary>
        /// <param name="regionEntityRepository">The regionEntityRepository</param>
        /// <param name="addrBusinessAreaEntityRepository">The addrBusinessAreaEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:31
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BusinessAreaBusinessArea(
            INHibernateRepository<RegionEntity> regionEntityRepository,
            INHibernateRepository<AddrBusinessAreaEntity> addrBusinessAreaEntityRepository)
        {
            this.regionEntityRepository = regionEntityRepository;
            this.addrBusinessAreaEntityRepository = addrBusinessAreaEntityRepository;
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
        public AreaType AreaType
        {
            get
            {
                return AreaType.BusinessArea;
            }
        }

        /// <summary>
        /// 根据id查询商圈信息列表
        /// </summary>
        /// <param name="parentId">The parentId</param>
        /// <returns>
        /// 返回数据列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<BusinessAreaModel> GetBusinessAreaData(int? parentId)
        {
            var parentCode = string.Empty;
            if (!parentCode.IsEmptyOrNull())
            {
                parentCode = this.regionEntityRepository.EntityQueryable.Where(p => p.Code == parentCode).Select(p => p.Code).FirstOrDefault();
            }

            return this.GetBusinessAreaDataByParentCode(parentCode);
        }

        /// <summary>
        /// 根据code查询商圈信息列表
        /// </summary>
        /// <param name="parentCode">The parentCode</param>
        /// <returns>
        /// 返回数据列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 15:07
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<BusinessAreaModel> GetBusinessAreaData(string parentCode)
        {
            return this.GetBusinessAreaDataByParentCode(parentCode);
        }

        /// <summary>
        /// Gets the business area data by parent identifier.
        /// </summary>
        /// <param name="parentCode">The parentCode</param>
        /// <returns>
        /// List{BusinessAreaModel}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<BusinessAreaModel> GetBusinessAreaDataByParentCode(string parentCode)
        {
            Func<AddrBusinessAreaEntity, bool> express = entity =>
                {
                    var result = entity.RegionCode.Length > 0;
                    if (!parentCode.IsEmptyOrNull())
                    {
                        result &= entity.RegionCode == parentCode;
                    }

                    return result;
                };

            var list = this.addrBusinessAreaEntityRepository.EntityQueryable.Where(express).Select(p => new BusinessAreaModel
            {
                Id = p.BusinessAreaId,
                Code = p.BusinessAreaId,
                Name = p.BusinessAreaName,
                No = p.BusinessAreaNo,
                ParentCode = p.RegionCode,
                Depth = (int)this.AreaType
            }).ToList();

            return list;
        }
    }
}