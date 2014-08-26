namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：CityBusinessArea
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：县城信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/14 16:05
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CityBusinessArea : BusinessArea
    {
        /// <summary>
        /// 字段regionEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/19/2013 8:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<RegionEntity> regionEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityBusinessArea"/> class.
        /// </summary>
        /// <param name="regionEntityRepository">The regionEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public CityBusinessArea(INHibernateRepository<RegionEntity> regionEntityRepository)
            : base(regionEntityRepository)
        {
            this.regionEntityRepository = regionEntityRepository;
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
                return AreaType.City;
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
        public override List<BusinessAreaModel> GetBusinessAreaData(int? parentId)
        {
            return this.GetBusinessAreaDataByParentId(parentId, string.Empty, (int)this.AreaType);
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
        public override List<BusinessAreaModel> GetBusinessAreaData(string parentCode)
        {
            var parentId = this.GetParentId(parentCode);
            return this.GetBusinessAreaDataByParentId(parentId, parentCode, (int)this.AreaType);
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
            int? parentId = null;
            if (!parentCode.IsEmptyOrNull())
            {
                parentId = this.regionEntityRepository.EntityQueryable.Where(p => p.Code == parentCode).Select(p => p.Id).FirstOrDefault();
            }

            return parentId;
        }

        /// <summary>
        /// Gets the business area data by parent identifier.
        /// </summary>
        /// <param name="parentId">The parentId</param>
        /// <param name="parentCode">The parentCode</param>
        /// <param name="depth">The depth</param>
        /// <returns>
        /// List{BusinessAreaModel}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<BusinessAreaModel> GetBusinessAreaDataByParentId(int? parentId, string parentCode, int depth)
        {
            var queryable = this.regionEntityRepository.EntityQueryable.Where(p => p.Depth == depth);
            if (parentId != null)
            {
                queryable = queryable.Where(p => p.F == parentId);
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

            var cityIdList = list.Where(p => p.Name.EndsWith(ServicesCommon.MunicipalitySign)).Select(p => p.ParentId).ToList();
            var cityList = list.Where(p => !cityIdList.Contains(p.ParentId)).ToList();

            //var tempList = this.regionEntityRepository.EntityQueryable.Where(p => cityIdList.Contains(p.Id)).Select(p => new BusinessAreaModel
            //   {
            //       Id = p.Id.ToString(),
            //       Name = p.Name,
            //       BriefName = p.BriefName,
            //       ChnName = p.ChnName,
            //       EnName = p.EnName,
            //       BriefJPing = p.BriefJPing,
            //       BriefQPing = p.BriefQPing,
            //       Depth = p.Depth,
            //       Code = p.Code,
            //       Host = p.Host,
            //       JPing = p.JPing,
            //       QPing = p.QPing,
            //       ParentId = p.F
            //   }).ToList();
            var tempList = this.regionEntityRepository.EntityQueryable.Where(p => p.Depth == depth - 1 && cityIdList.Contains(p.Id)).Select(p => new BusinessAreaModel
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
            if (tempList.Count > 0)
            {
                cityList.AddRange(tempList);
            }

            return parentCode.IsEmptyOrNull() ? this.SetParentCode(cityList) : this.SetParentCode(cityList, parentCode);
        }

        /// <summary>
        /// Sets the parent code.
        /// </summary>
        /// <param name="list">The list</param>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<BusinessAreaModel> SetParentCode(List<BusinessAreaModel> list)
        {
            var parentIdList = list.Select(p => p.ParentId).Distinct().ToList();
            var parentList = this.regionEntityRepository.EntityQueryable.Where(p => parentIdList.Contains(p.Id)).Select(p => new { p.Code, p.Id }).ToList();

            foreach (var item in list)
            {
                var parent = parentList.FirstOrDefault(p => p.Id == item.ParentId);
                if (parent == null)
                {
                    continue;
                }

                item.ParentCode = parent.Code;
            }

            return list;
        }

        /// <summary>
        /// Sets the parent code.
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="parentCode">The parentCode</param>
        /// 创建者：周超
        /// 创建日期：2013/10/14 16:47
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<BusinessAreaModel> SetParentCode(List<BusinessAreaModel> list, string parentCode)
        {
            foreach (var item in list)
            {
                item.ParentCode = parentCode;
            }

            return list;
        }
    }
}