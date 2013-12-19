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
    /// 类名称：AllAreaBusinessArea
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：商圈信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 16:36
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AllAreaBusinessArea : IBusinessArea
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
        public AllAreaBusinessArea(
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
                return AreaType.AllArea;
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
            var list = this.GetBusinessAreaDataByParentId(parentId);
            return list;
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
            var parentId = this.GetParentId(parentCode);
            var list = this.GetBusinessAreaDataByParentId(parentId);
            return list;
        }

        /// <summary>
        /// Gets the business area data by parent identifier.
        /// </summary>
        /// <returns>
        /// List{BusinessAreaModel}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private IEnumerable<BusinessAreaModel> GetBusinessAreaDataByParentCode()
        {
            var list = this.addrBusinessAreaEntityRepository.EntityQueryable.Where(p => p.RegionCode.Length > 0).Select(p => new BusinessAreaModel
            {
                Id = p.BusinessAreaId,
                Code = p.BusinessAreaId,
                Name = p.BusinessAreaName,
                No = p.BusinessAreaNo,
                ParentCode = p.RegionCode,
                Depth = (int)AreaType.BusinessArea
            }).ToList();

            return list;
        }

        /// <summary>
        /// Gets the business area data by parent identifier.
        /// </summary>
        /// <param name="parentId">The parentId</param>
        /// <returns>
        /// List{BusinessAreaModel}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<BusinessAreaModel> GetBusinessAreaDataByParentId(int? parentId)
        {
            var queryable = this.regionEntityRepository.EntityQueryable;
            if (parentId != null)
            {
                queryable = queryable.Where(p => p.F == parentId || p.ProvinceId == parentId || p.CityId == parentId);
            }

            var list = queryable.Select(p => new BusinessAreaModel
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                BriefName = p.BriefName,
                ChnName = p.ChnName,
                EnName = p.EnName,
                BriefJPing = p.BriefJPing,
                BriefQPing = p.BriefQPing,
                Depth = p.Depth,
                Code = p.Code,
                Host = p.Host,
                JPing = p.JPing,
                QPing = p.QPing,
                ParentId = p.F
            }).ToList();

            foreach (var item in list)
            {
                var parent = list.FirstOrDefault(p => p.Id == item.ParentId.ToString());
                if (parent == null)
                {
                    continue;
                }

                item.ParentCode = parent.Code;
            }

            var regionCodeList = list.Where(p => p.Depth == (int)AreaType.Region).Select(p => p.Code).ToList();
            list.AddRange(this.GetBusinessAreaDataByParentCode().Where(p=>regionCodeList.Contains(p.ParentCode)).ToList());
            return list;
        }

        /// <summary>
        /// Gets the parent identifier.
        /// </summary>
        /// <param name="parentCode">The parentCode</param>
        /// <returns>
        /// Nullable{System.Int32}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:53
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int? GetParentId(string parentCode)
        {
            if (parentCode.IsEmptyOrNull())
            {
                return null;
            }

            var regionEntity = this.regionEntityRepository.EntityQueryable.FirstOrDefault(p => p.Code == parentCode);
            return regionEntity == null ? int.MinValue : regionEntity.Id;
        }
    }
}