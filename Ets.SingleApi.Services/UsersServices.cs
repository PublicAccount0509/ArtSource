namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：UsersServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：用户信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 0:16
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class UsersServices : IUsersServices
    {
        /// <summary>
        /// 字段appEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/30/2013 10:41 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<AppEntity> appEntityRepository;

        /// <summary>
        /// The login entity repository
        /// </summary>
        /// 创建者：苏建峰
        /// 创建日期：2014-2-18 16:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段customerFavoriteEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 15:03
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerFavoriteEntity> customerFavoriteEntityRepository;

        /// <summary>
        /// 字段customerAddressEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 15:27
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段supplierCuisineEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 15:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCuisineEntity> supplierCuisineEntityRepository;

        /// <summary>
        /// 字段supplierImageEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 15:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierImageEntity> supplierImageEntityRepository;

        /// <summary>
        /// 字段regionEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/19 22:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<RegionEntity> regionEntityRepository;

        /// <summary>
        /// 字段supplierFeatureEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/29/2013 10:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository;

        /// <summary>
        /// 字段usersDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IUsersDetailServices usersDetailServices;

        /// <summary>
        /// 字段smsDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/30/2013 3:28 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISmsDetailServices smsDetailServices;

        /// <summary>
        /// 字段userOrdersList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/21 13:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IUserOrders> userOrdersList;

        /// <summary>
        /// 字段existsList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 12:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IExists> existsList;

        /// <summary>
        /// 字段accountList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/12/2013 11:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IAccount> accountList;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersServices" /> class.
        /// </summary>
        /// <param name="appEntityRepository">The appEntityRepository</param>
        /// <param name="loginEntityRepository">The login entity repository.</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="customerFavoriteEntityRepository">The customerFavoriteEntityRepository</param>
        /// <param name="customerAddressEntityRepository">The customerAddressEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="supplierCuisineEntityRepository">The supplierCuisineEntityRepository</param>
        /// <param name="supplierImageEntityRepository">The supplierImageEntityRepository</param>
        /// <param name="regionEntityRepository">The regionEntityRepository</param>
        /// <param name="supplierFeatureEntityRepository">The supplierFeatureEntityRepository</param>
        /// <param name="usersDetailServices">The usersDetailServices</param>
        /// <param name="smsDetailServices">The smsDetailServices</param>
        /// <param name="userOrdersList">The userOrdersList</param>
        /// <param name="existsList">The existsList</param>
        /// <param name="accountList">The accountList</param>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public UsersServices(
            INHibernateRepository<AppEntity> appEntityRepository,
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<CustomerFavoriteEntity> customerFavoriteEntityRepository,
            INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<SupplierCuisineEntity> supplierCuisineEntityRepository,
            INHibernateRepository<SupplierImageEntity> supplierImageEntityRepository,
            INHibernateRepository<RegionEntity> regionEntityRepository,
            INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository,
            IUsersDetailServices usersDetailServices,
            ISmsDetailServices smsDetailServices,
            List<IUserOrders> userOrdersList,
            List<IExists> existsList,
            List<IAccount> accountList)
        {
            this.appEntityRepository = appEntityRepository;
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.customerFavoriteEntityRepository = customerFavoriteEntityRepository;
            this.customerAddressEntityRepository = customerAddressEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.supplierCuisineEntityRepository = supplierCuisineEntityRepository;
            this.supplierImageEntityRepository = supplierImageEntityRepository;
            this.regionEntityRepository = regionEntityRepository;
            this.supplierFeatureEntityRepository = supplierFeatureEntityRepository;
            this.usersDetailServices = usersDetailServices;
            this.smsDetailServices = smsDetailServices;
            this.userOrdersList = userOrdersList;
            this.existsList = existsList;
            this.accountList = accountList;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回用户信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:44
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<CustomerModel> GetUser(string source, int userId)
        {
            var loginEntity = this.loginEntityRepository.EntityQueryable.Where(p => p.LoginId == userId).Select(p => new { p.Username }).FirstOrDefault();

            var customerModel = (from customer in this.customerEntityRepository.EntityQueryable
                                 where customer.LoginId == userId
                                 select new CustomerModel
                                         {
                                             CustomerId = customer.CustomerId,
                                             UserId = customer.LoginId.Value,
                                             //UserName = loginEntity == null ? string.Empty : loginEntity.Username,
                                             Avatar = customer.Avatar,
                                             Email = customer.Email,
                                             Telephone = customer.Mobile
                                         }).FirstOrDefault();
            if (customerModel == null)
            {
                return new ServicesResult<CustomerModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new CustomerModel()
                };
            }

            customerModel.UserName = loginEntity == null ? string.Empty : loginEntity.Username;
            var supplierEntity = this.supplierEntityRepository.EntityQueryable.Where(p => p.Login.LoginId == userId).Select(p => new
                   {
                       p.SupplierId,
                       p.SupplierName
                   }).FirstOrDefault();
            if (supplierEntity != null)
            {
                customerModel.SupplierId = supplierEntity.SupplierId;
            }

            var customerAddressList = (from customerAddress in this.customerAddressEntityRepository.EntityQueryable
                                       where customerAddress.CustomerId == customerModel.CustomerId && customerAddress.IsDel == false
                                       select new
                                       {
                                           customerAddress.CustomerAddressId,
                                           customerAddress.Address1,
                                           customerAddress.AddressBuilding,
                                           customerAddress.AddressDetail,
                                           customerAddress.AddressAlias,
                                           Name = customerAddress.Recipient,
                                           customerAddress.Telephone,
                                           HomePhone = customerAddress.Plane,
                                           customerAddress.IsDefault,
                                           customerAddress.CityId,
                                           customerAddress.CountyId,
                                           ProvinceId = customerAddress.CountryId,
                                           customerAddress.RegionCode,
                                           customerAddress.Sex
                                       }).ToList();

            customerModel.CustomerAddressList = customerAddressList.Select(p => new CustomerAddressModel
                                                {
                                                    CustomerAddressId = p.CustomerAddressId,
                                                    Address = p.Address1,
                                                    AddressBuilding = p.AddressBuilding,
                                                    AddressDetail = p.AddressDetail,
                                                    AddressAlias = p.AddressAlias,
                                                    Name = p.Name,
                                                    Telephone = this.GetTelephone(p.Telephone, p.HomePhone),
                                                    IsDefault = p.IsDefault,
                                                    CityId = p.CityId,
                                                    CountyId = p.CountyId,
                                                    ProvinceId = p.ProvinceId,
                                                    RegionCode = p.RegionCode,
                                                    Sex = p.Sex
                                                }).ToList();

            if (!customerModel.Avatar.IsEmptyOrNull())
            {
                customerModel.Avatar = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl.Trim('/'), customerModel.Avatar.TrimStart('/'));
            }

            return new ServicesResult<CustomerModel>
                {
                    Result = customerModel
                };
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="account">账号</param>
        /// <param name="type">账号类型 1 邮箱  2 电话</param>
        /// <returns>
        /// The GetUserResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 18:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<CustomerSimpleModel> GetUserSimple(string source, string account, int type)
        {
            var accountProvide = this.accountList.FirstOrDefault(p => p.AccountType == (AccountType)type);
            if (accountProvide == null)
            {
                return new ServicesResult<CustomerSimpleModel>
                {
                    StatusCode = (int)StatusCode.General.UnknowError,
                    Result = new CustomerSimpleModel()
                };
            }

            var getCustomerData = accountProvide.GetCustomer(account);
            if (getCustomerData.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<CustomerSimpleModel>
                {
                    Result = new CustomerSimpleModel(),
                    StatusCode = getCustomerData.StatusCode
                };
            }

            var result = new CustomerSimpleModel
                {
                    UserId = getCustomerData.UserId,
                    Email = getCustomerData.Email,
                    Telephone = getCustomerData.Telephone
                };

            return new ServicesResult<CustomerSimpleModel>
                {
                    Result = result
                };
        }

        /// <summary>
        /// 获取用户地址
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="customerAddressId">用户地址Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<CustomerAddressModel> GetCustomerAddress(string source, int userId, int customerAddressId)
        {
            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResult<CustomerAddressModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new CustomerAddressModel()
                };
            }

            var customerAddressEntity = (from customerAddress in this.customerAddressEntityRepository.EntityQueryable
                                         where customerAddress.CustomerId == customerEntity.CustomerId &&
                                         customerAddress.CustomerAddressId == customerAddressId
                                         select new
                                         {
                                             customerAddress.CustomerAddressId,
                                             customerAddress.Address1,
                                             customerAddress.AddressBuilding,
                                             customerAddress.AddressDetail,
                                             customerAddress.AddressAlias,
                                             Name = customerAddress.Recipient,
                                             customerAddress.Telephone,
                                             HomePhone = customerAddress.Plane,
                                             customerAddress.IsDefault,
                                             customerAddress.CityId,
                                             customerAddress.CountyId,
                                             ProvinceId = customerAddress.CountryId,
                                             customerAddress.RegionCode,
                                             customerAddress.Sex
                                         }).FirstOrDefault();

            if (customerAddressEntity == null)
            {
                return new ServicesResult<CustomerAddressModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidCustomerAddressIdCode,
                    Result = new CustomerAddressModel()
                };
            }

            var result = new CustomerAddressModel
                {
                    CustomerAddressId = customerAddressEntity.CustomerAddressId,
                    Address = customerAddressEntity.Address1,
                    AddressBuilding = customerAddressEntity.AddressBuilding,
                    AddressDetail = customerAddressEntity.AddressDetail,
                    AddressAlias = customerAddressEntity.AddressAlias,
                    Name = customerAddressEntity.Name,
                    Telephone = this.GetTelephone(customerAddressEntity.Telephone, customerAddressEntity.HomePhone),
                    IsDefault = customerAddressEntity.IsDefault,
                    CityId = customerAddressEntity.CityId,
                    CountyId = customerAddressEntity.CountyId,
                    ProvinceId = customerAddressEntity.ProvinceId,
                    RegionCode = customerAddressEntity.RegionCode,
                    Sex = customerAddressEntity.Sex
                };

            return new ServicesResult<CustomerAddressModel>
            {
                Result = result
            };
        }

        /// <summary>
        /// 获取用户地址列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="cityId">The cityId</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<CustomerAddressModel> GetCustomerAddressList(string source, int userId, int? cityId)
        {
            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResultList<CustomerAddressModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new List<CustomerAddressModel>()
                };
            }

            var tempQueryable = this.GetCustomerAddressQueryable(cityId, customerEntity.CustomerId);
            var customerAddressEntityList = tempQueryable.Select(customerAddress => new
            {
                customerAddress.CustomerAddressId,
                customerAddress.Address1,
                customerAddress.AddressBuilding,
                customerAddress.AddressDetail,
                customerAddress.AddressAlias,
                Name = customerAddress.Recipient,
                customerAddress.Telephone,
                HomePhone = customerAddress.Plane,
                customerAddress.IsDefault,
                customerAddress.CityId,
                customerAddress.CountyId,
                ProvinceId = customerAddress.CountryId,
                customerAddress.RegionCode,
                customerAddress.Sex
            }).ToList();

            if (customerAddressEntityList.Count == 0)
            {
                return new ServicesResultList<CustomerAddressModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty,
                    Result = new List<CustomerAddressModel>()
                };
            }

            var result = customerAddressEntityList.Select(customerAddressEntity => new CustomerAddressModel
            {
                CustomerAddressId = customerAddressEntity.CustomerAddressId,
                Address = customerAddressEntity.Address1,
                AddressBuilding = customerAddressEntity.AddressBuilding,
                AddressDetail = customerAddressEntity.AddressDetail,
                AddressAlias = customerAddressEntity.AddressAlias,
                Name = customerAddressEntity.Name,
                Telephone = this.GetTelephone(customerAddressEntity.Telephone, customerAddressEntity.HomePhone),
                IsDefault = customerAddressEntity.IsDefault,
                CityId = customerAddressEntity.CityId,
                CountyId = customerAddressEntity.CountyId,
                ProvinceId = customerAddressEntity.ProvinceId,
                RegionCode = customerAddressEntity.RegionCode,
                Sex = customerAddressEntity.Sex
            }).ToList();

            return new ServicesResultList<CustomerAddressModel>
            {
                Result = result
            };
        }

        /// <summary>
        /// 管理用户地址
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveCustomerAddress(string source, int userId, CustomerAddressParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            var isDefault = parameter.IsDefault;
            var customerId = customerEntity.CustomerId;
            if (this.customerAddressEntityRepository.EntityQueryable.Count(p => p.CustomerId == customerId && p.IsDel == false) == 0)
            {
                isDefault = true;
            }

            var regionEntity = this.regionEntityRepository.FindSingleByExpression(p => p.Code == parameter.RegionCode);
            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(
                    p => p.CustomerId == customerId && p.CustomerAddressId == parameter.CustomerAddressId && p.IsDel == false) ?? new CustomerAddressEntity
                        {
                            IsDefault = isDefault ?? false
                        };

            customerAddressEntity.Recipient = parameter.Name;
            customerAddressEntity.Address1 = parameter.Address;
            customerAddressEntity.Address2 = string.Format("{0}{1}", parameter.AddressBuilding, parameter.AddressDetail);
            customerAddressEntity.AddressBuilding = parameter.AddressBuilding;
            customerAddressEntity.AddressDetail = parameter.AddressDetail;
            customerAddressEntity.AddressAlias = parameter.AddressAlias;
            customerAddressEntity.CityId = regionEntity == null ? null : (int?)regionEntity.CityId;
            customerAddressEntity.CountyId = regionEntity == null ? null : (int?)regionEntity.Id;
            customerAddressEntity.CountryId = regionEntity == null ? null : (int?)regionEntity.ProvinceId;
            customerAddressEntity.RegionCode = parameter.RegionCode;
            customerAddressEntity.Telephone = parameter.Telephone;
            customerAddressEntity.Sex = parameter.Sex ?? ServicesCommon.DefaultGender;
            customerAddressEntity.CustomerId = customerId;
            customerAddressEntity.IsDel = false;

            if (isDefault != null)
            {
                customerAddressEntity.IsDefault = isDefault;
            }

            if (isDefault != true)
            {
                this.customerAddressEntityRepository.Save(customerAddressEntity);
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            var customerAddressId = customerAddressEntity.CustomerAddressId;
            var customerAddressEntityList = this.customerAddressEntityRepository.FindByExpression(p => p.CustomerId == customerId && p.CustomerAddressId != customerAddressId && p.IsDefault == true && p.IsDel == false).ToList();
            foreach (var addressEntity in customerAddressEntityList)
            {
                addressEntity.IsDefault = false;
            }

            customerAddressEntityList.Add(customerAddressEntity);
            this.customerAddressEntityRepository.SaveTransaction(customerAddressEntityList);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 删除用户地址
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="customerAddressIdList">用户地址Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteCustomerAddress(string source, int userId, List<int> customerAddressIdList)
        {
            if (customerAddressIdList == null || customerAddressIdList.Count == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            var customerAddressEntityList = this.customerAddressEntityRepository.FindByExpression(p => customerAddressIdList.Contains(p.CustomerAddressId) && p.CustomerId == customerEntity.CustomerId && p.IsDel == false).ToList();
            if (customerAddressEntityList.Count == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            foreach (var customerAddressEntity in customerAddressEntityList)
            {
                customerAddressEntity.IsDel = true;
            }

            var customerAddressList = this.customerAddressEntityRepository.FindByExpression(p => !customerAddressIdList.Contains(p.CustomerAddressId) && p.CustomerId == customerEntity.CustomerId && p.IsDel == false);
            if (customerAddressList.Count == 1)
            {
                var customerAddress = customerAddressList.First();
                customerAddress.IsDefault = true;
                customerAddressEntityList.Add(customerAddress);
            }

            this.customerAddressEntityRepository.SaveTransaction(customerAddressEntityList);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 设置默认用户地址
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="customerAddressId">用户地址Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 21:54
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SetDefaultCustomerAddress(string source, int userId, int customerAddressId)
        {
            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            var customerAddressEntity = this.customerAddressEntityRepository.FindSingleByExpression(p => p.CustomerAddressId == customerAddressId && p.CustomerId == customerEntity.CustomerId && p.IsDel == false);
            if (customerAddressEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidCustomerAddressIdCode,
                    Result = false
                };
            }

            customerAddressEntity.IsDefault = true;
            var defaultCustomerAddressList = this.customerAddressEntityRepository.FindByExpression(p => p.IsDefault == true && p.CustomerId == customerEntity.CustomerId && p.CustomerAddressId != customerAddressId && p.IsDel == false).ToList();
            if (defaultCustomerAddressList.Count == 0)
            {
                this.customerAddressEntityRepository.Save(customerAddressEntity);
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            foreach (var addressEntity in defaultCustomerAddressList)
            {
                addressEntity.IsDefault = false;
            }

            defaultCustomerAddressList.Add(customerAddressEntity);
            this.customerAddressEntityRepository.SaveTransaction(defaultCustomerAddressList);
            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">参数</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 16:28
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<RegisterUserModel> Register(string source, RegisterUserParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (parameter.Telephone.IsEmptyOrNull())
            {
                return new ServicesResult<RegisterUserModel>
                    {
                        Result = new RegisterUserModel(),
                        StatusCode = (int)StatusCode.Validate.EmptyTelephoneCode
                    };
            }

            var authCode = CacheUtility.GetInstance().Get(string.Format("{0}_{1}{2}", source, ServicesCommon.AuthCodeCacheKey, parameter.Telephone));
            if (parameter.AuthCode != (authCode == null ? string.Empty : authCode.ToString()))
            {
                return new ServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidAuthCode
                };
            }

            if (this.customerEntityRepository.EntityQueryable.Any(p => p.Mobile == parameter.Telephone))
            {
                return new ServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.Validate.ExistUserCode
                };
            }

            if (!parameter.Email.IsEmptyOrNull() && this.customerEntityRepository.EntityQueryable.Any(p => p.Email == parameter.Email))
            {
                return new ServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.Validate.ExistEmailCode
                };
            }

            if (!this.appEntityRepository.EntityQueryable.Any(p => p.AppKey == parameter.AppKey))
            {
                return new ServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.OAuth.InvalidClient
                };
            }

            var code = CommonUtility.RandNum(6);
            var password = (parameter.Password ?? string.Empty).Trim();
            if (parameter.Password.IsEmptyOrNull())
            {
                parameter.Password = code;
            }

            var result = this.usersDetailServices.Register(parameter);
            if (result.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<RegisterUserModel>
                {
                    StatusCode = result.StatusCode,
                    Result = new RegisterUserModel
                        {
                            UserId = result.Result.UserId,
                            AccessToken = result.Result.AccessToken,
                            RefreshToken = result.Result.RefreshToken,
                            TokenType = result.Result.TokenType
                        }
                };
            }

            if (!password.IsEmptyOrNull())
            {
                return new ServicesResult<RegisterUserModel>
                {
                    StatusCode = result.StatusCode,
                    Result = new RegisterUserModel
                    {
                        UserId = result.Result.UserId,
                        AccessToken = result.Result.AccessToken,
                        RefreshToken = result.Result.RefreshToken,
                        TokenType = result.Result.TokenType
                    }
                };
            }

            CacheUtility.GetInstance().Delete(string.Format("{0}_{1}{2}", source, ServicesCommon.AuthCodeCacheKey, parameter.Telephone));
            var sendSmsResult = this.smsDetailServices.SendSms(parameter.Telephone, string.Format(ServicesCommon.FirstRegisterMessage, code), parameter.SmsSource, parameter.SupplierId, parameter.IsVoiceSms);
            return new ServicesResult<RegisterUserModel>
            {
                StatusCode = sendSmsResult.StatusCode,
                Result = new RegisterUserModel
                {
                    UserId = result.Result.UserId,
                    AccessToken = result.Result.AccessToken,
                    RefreshToken = result.Result.RefreshToken,
                    TokenType = result.Result.TokenType
                }
            };
        }

        /// <summary>
        /// 第三方登录注册用户
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// 返回注册结果
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/17/2014 5:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<RegisterUserModel> RegisterOAuth(string source, RegisterUserOAuthParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.appEntityRepository.EntityQueryable.Any(p => p.AppKey == parameter.AppKey))
            {
                return new ServicesResult<RegisterUserModel>
                {
                    Result = new RegisterUserModel(),
                    StatusCode = (int)StatusCode.OAuth.InvalidClient
                };
            }

            var result = this.usersDetailServices.RegisterOAuth(parameter);
            if (result.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<RegisterUserModel>
                {
                    StatusCode = result.StatusCode,
                    Result = new RegisterUserModel
                    {
                        UserId = result.Result.UserId,
                        AccessToken = result.Result.AccessToken,
                        RefreshToken = result.Result.RefreshToken,
                        TokenType = result.Result.TokenType
                    }
                };
            }

            return new ServicesResult<RegisterUserModel>
            {
                StatusCode = result.StatusCode,
                Result = new RegisterUserModel
                {
                    UserId = result.Result.UserId,
                    AccessToken = result.Result.AccessToken,
                    RefreshToken = result.Result.RefreshToken,
                    TokenType = result.Result.TokenType
                }
            };
        }

        /// <summary>
        /// 获取收藏餐厅列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="isEtaoshi">是否为etaoshi内部网站</param>
        /// <returns>
        /// 返回收藏餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<FollowerSupplierModel> GetFollowerSupplierList(string source, int userId, int? supplierGroupId, bool isEtaoshi)
        {
            if (supplierGroupId == 0)
            {
                supplierGroupId = null;
            }

            var retentionSupplierGroupIdList = ServicesCommon.RetentionSupplierGroupIdList.Select(temp => (int?)temp).ToList();
            var queryableTemp = (from customerFavorite in this.customerFavoriteEntityRepository.EntityQueryable
                                 from supplier in this.supplierEntityRepository.EntityQueryable
                                 where customerFavorite.Supplier.SupplierId == supplier.SupplierId
                                 && customerFavorite.Customer.LoginId == userId && supplier.Login.IsEnabled
                                 select new
                                         {
                                             supplier.SupplierId,
                                             supplier.SupplierName,
                                             supplier.SupplierDescription,
                                             Address = supplier.Address1,
                                             supplier.Averageprice,
                                             supplier.AverageRating,
                                             supplier.Telephone,
                                             customerFavorite.DateAdded,
                                             supplier.SupplierGroupId
                                         });

            if (supplierGroupId != null)
            {
                queryableTemp = queryableTemp.Where(p => p.SupplierGroupId == supplierGroupId);
            }

            if (isEtaoshi)
            {
                queryableTemp = queryableTemp.Where(p => retentionSupplierGroupIdList.Contains(p.SupplierGroupId));
            }

            var supplierList = queryableTemp.OrderByDescending(p => p.DateAdded).ToList();
            var followerSupplierList = (from supplier in supplierList
                                        select new FollowerSupplierModel
                                            {
                                                SupplierId = supplier.SupplierId,
                                                SupplierName = supplier.SupplierName,
                                                SupplierDescription = supplier.SupplierDescription,
                                                Address = supplier.Address,
                                                Averageprice = supplier.Averageprice,
                                                AverageRating = supplier.AverageRating,
                                                Telephone = supplier.Telephone,
                                                CuisineName = string.Empty
                                            }).ToList();

            if (followerSupplierList.Count == 0)
            {
                return new ServicesResultList<FollowerSupplierModel>
                    {
                        Result = followerSupplierList
                    };
            }

            var supplierIdList = followerSupplierList.Select(p => p.SupplierId).ToList();
            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                    p => supplierIdList.Contains(p.Supplier.SupplierId) && p.IsEnabled == true)
                    .Select(p => new { p.SupplierFeatureId, p.Supplier.SupplierId, p.Feature.Feature, p.Feature.FeatureId })
                    .ToList();
            var supplierCuisineList = (from supplierCuisine in this.supplierCuisineEntityRepository.EntityQueryable
                                       where supplierIdList.Contains(supplierCuisine.Supplier.SupplierId)
                                       select new
                                               {
                                                   supplierCuisine.Supplier.SupplierId,
                                                   supplierCuisine.Cuisine.CuisineId,
                                                   supplierCuisine.Cuisine.CuisineName
                                               }).ToList();

            var supplierImageList = (from supplierCuisine in this.supplierImageEntityRepository.EntityQueryable
                                     where supplierIdList.Contains(supplierCuisine.Supplier.SupplierId)
                                     select new
                                     {
                                         supplierCuisine.Supplier.SupplierId,
                                         supplierCuisine.ImagePath
                                     }).ToList();

            foreach (var followerSupplier in followerSupplierList)
            {
                var supplierImage = supplierImageList.FirstOrDefault(p => p.SupplierId == followerSupplier.SupplierId);
                followerSupplier.LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, supplierImage == null ? string.Empty : supplierImage.ImagePath);

                if (followerSupplier.CuisineId.HasValue)
                {
                    continue;
                }

                var cuisineNameList = supplierCuisineList.Where(p => p.SupplierId == followerSupplier.SupplierId).Select(p => p.CuisineName).Where(p => !p.IsEmptyOrNull()).ToList();
                followerSupplier.CuisineName = string.Join(",", cuisineNameList);

                followerSupplier.SupplierFeatureList = supplierFeatureList.Where(p => p.SupplierId == followerSupplier.SupplierId)
                                                                           .Select(p => new SupplierFeatureModel
                                                                                   {
                                                                                       FeatureId = p.FeatureId,
                                                                                       FeatureName = p.Feature,
                                                                                       SupplierFeatureId = p.SupplierFeatureId
                                                                                   }).ToList();
            }

            return new ServicesResultList<FollowerSupplierModel>
                  {
                      ResultTotalCount = followerSupplierList.Count,
                      Result = followerSupplierList
                  };
        }

        /// <summary>
        /// 判定是否已经收藏餐厅
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">The userId</param>
        /// <param name="supplierId">The supplierId</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> IsFollowerSupplier(string source, int userId, int supplierId)
        {
            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdListCode,
                    Result = false
                };
            }

            var result = this.customerFavoriteEntityRepository.EntityQueryable.Any(
                    p => p.Customer.LoginId == customerEntity.LoginId && p.Supplier.SupplierId == supplierId);

            return new ServicesResult<bool>
                {
                    Result = result
                };
        }

        /// <summary>
        /// 收藏餐厅
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddFollowerSupplier(string source, int userId, List<int> supplierIdList)
        {
            if (supplierIdList == null || supplierIdList.Count == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            var favoriteSupplierIdList = this.customerFavoriteEntityRepository.EntityQueryable.Where(p => p.Customer.LoginId == userId)
                              .Where(p => p.Supplier != null).Select(p => p.Supplier.SupplierId).ToList();

            var list = supplierIdList.Where(p => favoriteSupplierIdList.All(q => q != p)).ToList();
            if (list.Count == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = true
                };
            }

            var supplierEntityList = this.supplierEntityRepository.FindByExpression(p => list.Contains(p.SupplierId));
            if (supplierEntityList.Count == 0)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdListCode,
                    Result = false
                };
            }

            var customerFavoriteEntityList = supplierEntityList.Select(p => new CustomerFavoriteEntity
                {
                    Customer = customerEntity,
                    Supplier = p,
                    DateAdded = DateTime.Now
                }).ToList();

            this.customerFavoriteEntityRepository.SaveTransaction(customerFavoriteEntityList);

            return new ServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 取消收藏餐厅
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="supplierIdList">餐厅Id列表</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 14:42
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteFollowerSupplier(string source, int userId, List<int> supplierIdList)
        {
            if (supplierIdList == null || supplierIdList.Count == 0)
            {
                return new ServicesResult<bool>
                {
                    Result = false,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == userId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = false
                };
            }

            var customerFavoriteList = this.customerFavoriteEntityRepository.FindByExpression(p => p.Customer.LoginId == userId && supplierIdList.Contains(p.Supplier.SupplierId));
            if (customerFavoriteList.Count == 0)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdListCode,
                    Result = false
                };
            }

            this.customerFavoriteEntityRepository.RemoveTransaction(customerFavoriteList.ToList());
            return new ServicesResult<bool>
                {
                    Result = true
                };
        }

        /// <summary>
        /// 获取用户订单
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <param name="orderType">订单类型</param>
        /// <param name="parameter">查询订单参数</param>
        /// <returns>
        /// 获取用户订单
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/21 13:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<UserOrderModel> GetUserOrderList(string source, int userId, OrderType orderType, GetUserOrderParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<UserOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new List<UserOrderModel>()
                };
            }

            var customerEntity = this.customerEntityRepository.FindSingleByExpression(p => p.LoginId == userId);
            if (customerEntity == null)
            {
                return new ServicesResultList<UserOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new List<UserOrderModel>()
                };
            }

            var customerId = customerEntity.CustomerId;
            var userOrder = this.userOrdersList.FirstOrDefault(p => p.OrderType == orderType);
            if (userOrder == null)
            {
                return new ServicesResultList<UserOrderModel>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode,
                        Result = new List<UserOrderModel>()
                    };
            }

            var userOrderResult = userOrder.GetUserOrderList(new UserOrdersParameter
                {
                    CustomerId = customerId,
                    OrderStatus = parameter.OrderStatus,
                    PaidStatus = parameter.PaidStatus,
                    SupplierId = parameter.SupplierId,
                    SupplierGroupId = parameter.SupplierGroupId,
                    IsEtaoshi = parameter.IsEtaoshi,
                    PageIndex = parameter.PageIndex,
                    PageSize = parameter.PageSize,
                    Cancelled = parameter.Cancelled
                });

            if (userOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResultList<UserOrderModel>
                {
                    StatusCode = userOrderResult.StatusCode,
                    Result = new List<UserOrderModel>()
                };
            }

            var list = userOrder.Convert(userOrderResult.OrderList);
            if (list == null || list.Count == 0)
            {
                return new ServicesResultList<UserOrderModel>
                    {
                        StatusCode = (int)StatusCode.Succeed.Empty,
                        Result = new List<UserOrderModel>()
                    };
            }

            return new ServicesResultList<UserOrderModel>
                {
                    StatusCode = userOrderResult.StatusCode,
                    ResultTotalCount = userOrderResult.ResultTotalCount,
                    Result = list
                };
        }

        /// <summary>
        /// 验证用户是否存在
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameterList">The parameterList</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 4:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<ExistModel> Exist(string source, List<ExistParameter> parameterList)
        {
            if (parameterList == null || parameterList.Count(p => p != null) == 0)
            {
                return new ServicesResultList<ExistModel>
                    {
                        StatusCode = (int)StatusCode.System.InvalidRequest,
                        Result = new List<ExistModel>()
                    };
            }

            var parameters = parameterList.Where(p => !p.Account.IsEmptyOrNull()).ToList();
            if (parameters.Count == 0)
            {
                return new ServicesResultList<ExistModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new List<ExistModel>()
                };
            }

            var list = (from existParameter in parameters
                        let existsType = (ExistsType)existParameter.Type
                        let exists = this.existsList.FirstOrDefault(p => p.ExistsType == existsType)
                        where exists != null
                        let data = exists.Exist(existParameter.Account)
                        select new ExistModel
                            {
                                Account = existParameter.Account,
                                Exist = data.Exist,
                                Login = data.Login
                            }).ToList();

            return new ServicesResultList<ExistModel>
            {
                Result = list
            };
        }

        /// <summary>
        /// 获取电话号码
        /// </summary>
        /// <param name="telephone">手机号</param>
        /// <param name="homePhone">固定电话</param>
        /// <returns>
        /// 返回电话号码
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 19:38
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private string GetTelephone(string telephone, string homePhone)
        {
            var phone = telephone.IsMobilephone()
                           ? telephone
                           : homePhone;

            return phone.IsEmptyOrNull() ? telephone : phone;
        }

        /// <summary>
        /// 取得CustomerAddress的查询Queryable
        /// </summary>
        /// <param name="cityId">The cityId</param>
        /// <param name="customerId">The customerId</param>
        /// <returns>
        /// IQueryable{CustomerAddressEntity}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/27/2013 9:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private IQueryable<CustomerAddressEntity> GetCustomerAddressQueryable(int? cityId, int customerId)
        {
            var queryable = this.customerAddressEntityRepository.EntityQueryable.Where(p => p.CustomerId == customerId && p.IsDel == false);
            if (cityId == null)
            {
                return queryable;
            }

            return queryable.Where(p => p.CountryId == cityId || p.CityId == cityId);
        }
    }
}