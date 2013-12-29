namespace Ets.SingleApi.Services.DetailServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Services.Transaction;

    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：SupplierDetailServices
    /// 命名空间：Ets.SingleApi.Services.DetailServices
    /// 类功能：餐厅详细功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/1/2013 4:57 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class SupplierDetailServices : ISupplierDetailServices
    {
        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/3/2013 5:28 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段categoryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/2/2013 4:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CategoryEntity> categoryEntityRepository;

        /// <summary>
        /// 字段categoryTypeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CategoryTypeEntity> categoryTypeEntityRepository;

        /// <summary>
        /// 字段supplierDishEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/1/2013 5:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository;

        /// <summary>
        /// 字段supplierDishImageEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/3/2013 5:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDishImageEntity> supplierDishImageEntityRepository;

        /// <summary>
        /// 字段supplierCategoryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/1/2013 5:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCategoryEntity> supplierCategoryEntityRepository;

        /// <summary>
        /// 字段supplierMenuCategoryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/1/2013 5:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierMenuCategoryEntity> supplierMenuCategoryEntityRepository;

        /// <summary>
        /// 字段suppTimeTableDisplayEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:44 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SuppTimeTableDisplayEntity> suppTimeTableDisplayEntityRepository;

        /// <summary>
        /// 字段timeTableDisplayEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:44 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository;

        /// <summary>
        /// 字段supplierTimeTableEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/11/2013 2:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierTimeTableEntity> supplierTimeTableEntityRepository;

        /// <summary>
        /// 字段timeTableEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/11/2013 2:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TimeTableEntity> timeTableEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierDetailServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="categoryEntityRepository">The categoryEntityRepository</param>
        /// <param name="categoryTypeEntityRepository">The categoryTypeEntityRepository</param>
        /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierDishImageEntityRepository">The supplierDishImageEntityRepository</param>
        /// <param name="supplierCategoryEntityRepository">The supplierCategoryEntityRepository</param>
        /// <param name="supplierMenuCategoryEntityRepository">The supplierMenuCategoryEntityRepository</param>
        /// <param name="suppTimeTableDisplayEntityRepository">The suppTimeTableDisplayEntityRepository</param>
        /// <param name="timeTableDisplayEntityRepository">The timeTableDisplayEntityRepository</param>
        /// <param name="supplierTimeTableEntityRepository">The supplierTimeTableEntityRepository</param>
        /// <param name="timeTableEntityRepository">The timeTableEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：11/1/2013 5:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SupplierDetailServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CategoryEntity> categoryEntityRepository,
            INHibernateRepository<CategoryTypeEntity> categoryTypeEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierDishImageEntity> supplierDishImageEntityRepository,
            INHibernateRepository<SupplierCategoryEntity> supplierCategoryEntityRepository,
            INHibernateRepository<SupplierMenuCategoryEntity> supplierMenuCategoryEntityRepository,
            INHibernateRepository<SuppTimeTableDisplayEntity> suppTimeTableDisplayEntityRepository,
            INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository,
            INHibernateRepository<SupplierTimeTableEntity> supplierTimeTableEntityRepository,
            INHibernateRepository<TimeTableEntity> timeTableEntityRepository)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.categoryEntityRepository = categoryEntityRepository;
            this.categoryTypeEntityRepository = categoryTypeEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierDishImageEntityRepository = supplierDishImageEntityRepository;
            this.supplierCategoryEntityRepository = supplierCategoryEntityRepository;
            this.supplierMenuCategoryEntityRepository = supplierMenuCategoryEntityRepository;
            this.suppTimeTableDisplayEntityRepository = suppTimeTableDisplayEntityRepository;
            this.timeTableDisplayEntityRepository = timeTableDisplayEntityRepository;
            this.supplierTimeTableEntityRepository = supplierTimeTableEntityRepository;
            this.timeTableEntityRepository = timeTableEntityRepository;
        }

        /// <summary>
        /// 添加餐厅菜品信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<bool> AddSupplierCuisine(SaveSupplierCuisineParameter parameter)
        {
            if (parameter == null || parameter.CuisineList == null || parameter.CuisineList.Count == 0)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var supplierMenuCategoryEntity = this.supplierMenuCategoryEntityRepository.FindSingleByExpression(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId && p.SupplierId == parameter.SupplierId);
            if (supplierMenuCategoryEntity == null)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var categoryTypeList = parameter.CuisineList.Select(p => p.CuisineType).Distinct().ToList();
            var categoryTypeEntityList = this.categoryTypeEntityRepository.EntityQueryable.Where(p => categoryTypeList.Contains(p.CategoryType)).ToList();
            var categoryEntityList = parameter.CuisineList.Select(p => new CategoryEntity
                  {
                      CategoryName = p.CuisineName,
                      CategoryNo = p.CuisineNo,
                      CategoryDescription = p.CuisineDescription,
                      CategoryImage = p.CuisineImage,
                      SupplierMenuCategoryId = supplierMenuCategoryEntity.SupplierMenuCategoryId,
                      SupplierId = parameter.SupplierId,
                      CategoryType = categoryTypeEntityList.FirstOrDefault(q => q.CategoryType == p.CuisineType)
                  }).ToList();
            this.categoryEntityRepository.Save(categoryEntityList);

            var supplierCategoryEntityList = categoryEntityList.Select(p => new SupplierCategoryEntity
                        {
                            SupplierId = parameter.SupplierId,
                            Category = p,
                            SupplierMenuCategoryId = supplierMenuCategoryEntity.SupplierMenuCategoryId
                        }).ToList();
            this.supplierCategoryEntityRepository.Save(supplierCategoryEntityList);
            return new DetailServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 更新菜品信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<bool> UpdateSupplierCuisine(SaveSupplierCuisineParameter parameter)
        {
            if (parameter == null || parameter.CuisineList == null || parameter.CuisineList.Count == 0)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var supplierMenuCategoryEntity = this.supplierMenuCategoryEntityRepository.FindSingleByExpression(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId && p.SupplierId == parameter.SupplierId);
            if (supplierMenuCategoryEntity == null)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var categoryIdList = parameter.CuisineList.Select(p => p.CategoryId).Distinct().ToList();
            var categoryEntityList = (from entity in this.supplierCategoryEntityRepository.EntityQueryable
                                      where entity.SupplierId == parameter.SupplierId
                                      && entity.SupplierMenuCategoryId == supplierMenuCategoryEntity.SupplierMenuCategoryId
                                      && categoryIdList.Contains(entity.Category.CategoryId)
                                      select entity.Category).ToList();

            var categoryTypeList = parameter.CuisineList.Select(p => p.CuisineType).Distinct().ToList();
            var categoryTypeEntityList = this.categoryTypeEntityRepository.EntityQueryable.Where(p => categoryTypeList.Contains(p.CategoryType)).ToList();
            foreach (var cuisine in parameter.CuisineList)
            {
                var category = categoryEntityList.FirstOrDefault(p => p.CategoryId == cuisine.CategoryId);
                if (category == null)
                {
                    continue;
                }

                category.CategoryName = cuisine.CuisineName;
                category.CategoryNo = cuisine.CuisineNo;
                category.CategoryDescription = cuisine.CuisineDescription;
                category.CategoryImage = cuisine.CuisineImage;
                category.CategoryType = categoryTypeEntityList.FirstOrDefault(p => p.CategoryType == cuisine.CuisineType);
            }

            this.categoryEntityRepository.Save(categoryEntityList);
            return new DetailServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 删除菜品信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<bool> DeleteSupplierCuisine(DeleteSupplierCuisineParameter parameter)
        {
            if (parameter == null || parameter.CategoryIdList == null || parameter.CategoryIdList.Count == 0)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var supplierMenuCategoryEntity = this.supplierMenuCategoryEntityRepository.FindSingleByExpression(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId && p.SupplierId == parameter.SupplierId);
            if (supplierMenuCategoryEntity == null)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var supplierCategoryEntityList = this.supplierCategoryEntityRepository.EntityQueryable.Where(
                                                p =>
                                                p.SupplierId == parameter.SupplierId
                                                && p.SupplierMenuCategoryId == supplierMenuCategoryEntity.SupplierMenuCategoryId
                                                && parameter.CategoryIdList.Contains(p.Category.CategoryId)).ToList();
            this.supplierCategoryEntityRepository.Remove(supplierCategoryEntityList);

            var categoryEntityList = this.categoryEntityRepository.EntityQueryable.Where(
                                    p =>
                                    p.SupplierId == parameter.SupplierId
                                    && p.SupplierMenuCategoryId == supplierMenuCategoryEntity.SupplierMenuCategoryId
                                    && parameter.CategoryIdList.Contains(p.CategoryId)).ToList();
            this.categoryEntityRepository.Remove(categoryEntityList);
            return new DetailServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 添加餐厅菜信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<bool> AddSupplierDish(SaveSupplierDishParameter parameter)
        {
            if (parameter == null || parameter.DishList == null || parameter.DishList.Count == 0)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == parameter.SupplierId);
            if (supplierEntity == null)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            var supplierMenuCategoryEntity = this.supplierMenuCategoryEntityRepository.FindSingleByExpression(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId && p.SupplierId == parameter.SupplierId);
            if (supplierMenuCategoryEntity == null)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var tempCategoryIdList = parameter.DishList.Select(p => p.CategoryId).ToList();
            var categoryIdList = (from entity in this.supplierCategoryEntityRepository.EntityQueryable
                                  where entity.SupplierId == parameter.SupplierId
                                      && entity.SupplierMenuCategoryId == supplierMenuCategoryEntity.SupplierMenuCategoryId
                                      && tempCategoryIdList.Contains(entity.Category.CategoryId)
                                  select entity.Category.CategoryId).ToList();

            foreach (var dish in parameter.DishList.Where(p => categoryIdList.Contains(p.CategoryId)).ToList())
            {
                var supplierDishEntity = new SupplierDishEntity
                   {
                       SupplierDishName = dish.SupplierDishName,
                       SuppllierDishDescription = dish.SuppllierDishDescription,
                       DishNo = dish.SupplierDishNo == null ? null : dish.SupplierDishNo.Value.ToString(),
                       Price = dish.Price,
                       PackagingFee = dish.PackagingFee,
                       IsCommission = dish.IsCommission,
                       IsDiscount = dish.IsDiscount,
                       Vegetarian = dish.IsVegetarian == true ? 1 : 0,
                       SpicyLevel = dish.SpicyLevel,
                       StockLevel = dish.StockLevel,
                       Recipe = dish.Recipe,
                       Recommended = dish.Recommended,
                       IsDel = false,
                       Online = true,
                       Supplier = supplierEntity,
                       SupplierCategoryId = dish.CategoryId,
                       QuanPin = dish.SupplierDishName.ToFullSpell(),
                       JianPin = dish.SupplierDishName.ToSimpleSpell()
                   };

                this.supplierDishEntityRepository.Save(supplierDishEntity);

                var supplierDishImageEntity = new SupplierDishImageEntity
                    {
                        SupplierDishId = supplierDishEntity.SupplierDishId,
                        ImagePath = dish.ImagePath,
                        Position = 0,
                        Online = true,
                        DateAdded = DateTime.Now
                    };

                this.supplierDishImageEntityRepository.Save(supplierDishImageEntity);
            }

            return new DetailServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 更新菜信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<bool> UpdateSupplierDish(SaveSupplierDishParameter parameter)
        {
            if (parameter == null || parameter.DishList == null || parameter.DishList.Count == 0)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == parameter.SupplierId);
            if (supplierEntity == null)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            var supplierMenuCategoryEntity = this.supplierMenuCategoryEntityRepository.FindSingleByExpression(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId && p.SupplierId == parameter.SupplierId);
            if (supplierMenuCategoryEntity == null)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var supplierDishIdList = parameter.DishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishEntityList = this.supplierDishEntityRepository.FindByExpression(p => p.Supplier.SupplierId == parameter.SupplierId && supplierDishIdList.Contains(p.SupplierDishId)).ToList();
            var tempCategoryIdList = parameter.DishList.Select(p => p.CategoryId).ToList();
            var categoryIdList = (from entity in this.supplierCategoryEntityRepository.EntityQueryable
                                  where entity.SupplierId == parameter.SupplierId
                                      && entity.SupplierMenuCategoryId == supplierMenuCategoryEntity.SupplierMenuCategoryId
                                      && tempCategoryIdList.Contains(entity.Category.CategoryId)
                                  select entity.Category.CategoryId).ToList();

            foreach (var supplierDishEntity in supplierDishEntityList)
            {
                var dish = parameter.DishList.FirstOrDefault(p => p.SupplierDishId == supplierDishEntity.SupplierDishId);
                if (dish == null)
                {
                    continue;
                }

                supplierDishEntity.SupplierDishName = dish.SupplierDishName;
                supplierDishEntity.SuppllierDishDescription = dish.SuppllierDishDescription;
                supplierDishEntity.DishNo = dish.SupplierDishNo == null ? null : dish.SupplierDishNo.Value.ToString();
                supplierDishEntity.Price = dish.Price;
                supplierDishEntity.PackagingFee = dish.PackagingFee;
                supplierDishEntity.IsCommission = dish.IsCommission;
                supplierDishEntity.IsDiscount = dish.IsDiscount;
                supplierDishEntity.Vegetarian = dish.IsVegetarian == true ? 1 : 0;
                supplierDishEntity.SpicyLevel = dish.SpicyLevel;
                supplierDishEntity.StockLevel = dish.StockLevel;
                supplierDishEntity.Recipe = dish.Recipe;
                supplierDishEntity.Recommended = dish.Recommended;
                supplierDishEntity.SupplierCategoryId = categoryIdList.Any(p => p == dish.CategoryId) ? (int?)dish.CategoryId : null;
                supplierDishEntity.QuanPin = dish.SupplierDishName.ToFullSpell();
                supplierDishEntity.JianPin = dish.SupplierDishName.ToSimpleSpell();
            }

            this.supplierDishEntityRepository.Save(supplierDishEntityList);

            var supplierDishImageEntityList = this.supplierDishImageEntityRepository.FindByExpression(p => supplierDishIdList.Contains(p.SupplierDishId) && p.Online == true).ToList();
            foreach (var supplierDishImageEntity in supplierDishImageEntityList)
            {
                var dish = parameter.DishList.FirstOrDefault(p => p.SupplierDishId == supplierDishImageEntity.SupplierDishId);
                if (dish == null)
                {
                    continue;
                }

                supplierDishImageEntity.ImagePath = dish.ImagePath;
            }

            this.supplierDishImageEntityRepository.Save(supplierDishImageEntityList);
            return new DetailServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 删除菜信息
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<bool> DeleteSupplierDish(DeleteSupplierDishParameter parameter)
        {
            if (parameter == null || parameter.DishIdList == null || parameter.DishIdList.Count == 0)
            {
                return new DetailServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var supplierDishEntityList = this.supplierDishEntityRepository.EntityQueryable.Where(
                                                p =>
                                                p.Supplier.SupplierId == parameter.SupplierId
                                                && parameter.DishIdList.Contains(p.SupplierDishId)).ToList();

            foreach (var supplierDishEntity in supplierDishEntityList)
            {
                supplierDishEntity.Online = false;
            }

            this.supplierDishEntityRepository.Save(supplierDishEntityList);

            return new DetailServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 取得餐厅营业时间
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="startServiceDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DetailServicesResultList<SupplierServiceTimeModel> GetSupplierServiceTime(int supplierId, DateTime startServiceDate, int days)
        {
            var dayList = new List<string>();
            for (var i = 0; i < days; i++)
            {
                var day = startServiceDate.AddDays(i).GetDayOfWeek();
                dayList.Add(day);
            }

            var timeTableDisplayList = (from entity in this.suppTimeTableDisplayEntityRepository.EntityQueryable
                                        from timeTable in this.timeTableDisplayEntityRepository.EntityQueryable
                                        where entity.SupplierId == supplierId
                                        && entity.TimeTableDisplayId == timeTable.TimeTableDisplayId
                                        && timeTable.OpenTime != null
                                        && timeTable.CloseTime != null
                                        select new
                                        {
                                            entity.Day,
                                            timeTable.OpenTime,
                                            timeTable.CloseTime
                                        }).ToList();

            var result = new List<SupplierServiceTimeModel>();
            for (var i = 0; i < days; i++)
            {
                var serviceDate = startServiceDate.AddDays(i);
                var day = serviceDate.AddDays(i).GetDayOfWeek();
                var timeTableList = timeTableDisplayList.Where(p => p.Day != null && p.OpenTime != null && p.CloseTime != null)
                                    .Where(p => p.Day.Value.ToString() == day).ToList();
                if (timeTableList.Count <= 0)
                {
                    continue;
                }

                var list = new List<string>();
                foreach (var item in timeTableList)
                {
                    var startDate = item.OpenTime.Value.AddMinutes(ServicesCommon.ServiceTimeBeginReadyTime);
                    var endDate = item.CloseTime.Value.AddMinutes(ServicesCommon.ServiceTimeEndReadyTime);
                    while (startDate <= endDate)
                    {
                        if (serviceDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") && DateTime.Parse(string.Format("{0} {1:t}", DateTime.Now.ToString("yyyy-MM-dd"), startDate)) < DateTime.Now.AddMinutes(ServicesCommon.BeginReadyTime))
                        {
                            startDate = startDate.AddMinutes(ServicesCommon.ServiceTimeInterval);
                            continue;
                        }

                        list.Add(startDate.ToString("HH:mm"));
                        startDate = startDate.AddMinutes(ServicesCommon.ServiceTimeInterval);
                    }
                }

                if (list.Count <= 0)
                {
                    continue;
                }

                result.Add(new SupplierServiceTimeModel
                    {
                        SupplierId = supplierId,
                        ServiceDate = serviceDate.ToString("yyyy-MM-dd"),
                        ServiceTime = timeTableList.Aggregate(string.Empty, (current, timeTableDisplay) => string.Format("{0} {1:t}-{2:t}", current, timeTableDisplay.OpenTime, timeTableDisplay.CloseTime)),
                        ServiceTimeList = list
                    });
            }

            return new DetailServicesResultList<SupplierServiceTimeModel>
                {
                    Result = result,
                    StatusCode = result.Count == 0 ? (int)StatusCode.Succeed.Empty : (int)StatusCode.Succeed.Ok
                };
        }

        /// <summary>
        /// 取得餐厅送餐时间
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="startDeliveryDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DetailServicesResultList<SupplierDeliveryTimeModel> GetSupplierDeliveryTime(int supplierId, DateTime startDeliveryDate, int days)
        {
            var dayList = new List<string>();
            for (var i = 0; i < days; i++)
            {
                var day = startDeliveryDate.AddDays(i).GetDayOfWeek();
                dayList.Add(day);
            }

            var supplierTimeTableList = (from entity in this.supplierTimeTableEntityRepository.EntityQueryable
                                         from timeTable in this.timeTableEntityRepository.EntityQueryable
                                         where entity.SupplierId == supplierId
                                         && entity.TimeTableId == timeTable.TimeTableId
                                         select new
                                         {
                                             entity.Day,
                                             timeTable.OpenTime,
                                             timeTable.CloseTime
                                         }).ToList();

            var result = new List<SupplierDeliveryTimeModel>();
            for (var i = 0; i < days; i++)
            {
                var deliveryDate = startDeliveryDate.AddDays(i);
                var day = deliveryDate.AddDays(i).GetDayOfWeek();
                var list = new List<string>();
                var timeTableList = supplierTimeTableList.Where(p => p.Day.ToString() == day).ToList();
                if (timeTableList.Count <= 0)
                {
                    foreach (var item in ServicesCommon.EmptyDeliveryTime.Split(' '))
                    {
                        var timeList = item.Split('-').ToList();
                        if (timeList.Count != 2)
                        {
                            continue;
                        }

                        var itemDay = Convert.ToInt32(day);
                        var itemOpenTime = DateTime.Parse(string.Format("{0} {1}", startDeliveryDate.ToString("yyyy-MM-dd"), timeList.First()));
                        var itemCloseTime = DateTime.Parse(string.Format("{0} {1}", startDeliveryDate.ToString("yyyy-MM-dd"), timeList.Last()));
                        timeTableList.Add(new { Day = itemDay, OpenTime = itemOpenTime, CloseTime = itemCloseTime });
                    }
                }

                foreach (var item in timeTableList)
                {
                    var startDate = item.OpenTime.AddMinutes(ServicesCommon.DeliveryTimeBeginReadyTime);
                    var endDate = item.CloseTime.AddMinutes(ServicesCommon.DeliveryTimeEndReadyTime);
                    while (startDate <= endDate)
                    {
                        if (deliveryDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") && DateTime.Parse(string.Format("{0} {1:t}", DateTime.Now.ToString("yyyy-MM-dd"), startDate)) < DateTime.Now.AddMinutes(ServicesCommon.BeginReadyTime))
                        {
                            startDate = startDate.AddMinutes(ServicesCommon.DeliveryTimeInterval);
                            continue;
                        }

                        list.Add(startDate.ToString("HH:mm"));
                        startDate = startDate.AddMinutes(ServicesCommon.DeliveryTimeInterval);
                    }
                }

                if (list.Count <= 0)
                {
                    continue;
                }

                result.Add(new SupplierDeliveryTimeModel
                {
                    SupplierId = supplierId,
                    DeliveryDate = deliveryDate.ToString("yyyy-MM-dd"),
                    DeliveryTime = timeTableList.Aggregate(string.Empty, (current, timeTableDisplay) => string.Format("{0} {1:t}-{2:t}", current, timeTableDisplay.OpenTime, timeTableDisplay.CloseTime)),
                    DeliveryTimeList = list
                });
            }

            return new DetailServicesResultList<SupplierDeliveryTimeModel>
            {
                Result = result,
                StatusCode = result.Count == 0 ? (int)StatusCode.Succeed.Empty : (int)StatusCode.Succeed.Ok
            };
        }
    }
}