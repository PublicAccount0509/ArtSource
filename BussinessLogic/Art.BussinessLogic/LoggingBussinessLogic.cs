using Art.Data.Domain;
using Art.Data.Domain.Access;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.BussinessLogic
{
    public class OperationLogBussinessLogic
    {
        //public static readonly OperationLogBussinessLogic Instance = new OperationLogBussinessLogic();

        private   IRepository<OperationLog> _operationLogRepository;
        [InjectionMethod]
        public void Initialize(IRepository<OperationLog> operationLogRepository)
        {
            _operationLogRepository = operationLogRepository;
        }

        public void LogOperation(int userId, string userName, string actionName, string friendlyActionName, Exception ex, bool exceptionHandled)
        {
            var log = new OperationLog
            {
                UserId = userId,
                UserName = userName,
                ActionName = actionName,
                FriendlyActionName = friendlyActionName,
                ExceptionInfo = ex == null ? null : ex.ToString(),
                ExceptionHandled = exceptionHandled,

                FADateTime = DateTime.Now
            };
            _operationLogRepository.Insert(log);
        }
    }
}
