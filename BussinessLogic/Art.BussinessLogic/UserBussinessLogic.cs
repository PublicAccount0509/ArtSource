using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.BussinessLogic
{
    public class UserBussinessLogic
    {
        //public static readonly UserBussinessLogic Instance = new UserBussinessLogic();

        private readonly IRepository<AdminUser> _userRepository;
        private UserBussinessLogic(IRepository<AdminUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public UserLoginResults ValidateUser(string userName, string password)
        {
            var user = _userRepository.Table.Where(i => i.LoginName == userName).FirstOrDefault();
            if (user == null)
            {
                return UserLoginResults.UserNotExist;
            }
            if (user.Password != password)
            {
                return UserLoginResults.WrongPassword;
            }
            return UserLoginResults.Successful;
        }
    }
}
