﻿using Art.Data.Domain;
using Art.Data.Domain.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art.BussinessLogic
{
    public class OperationLogBussinessLogic
    {
        public static readonly OperationLogBussinessLogic Instance = new OperationLogBussinessLogic();

        private readonly IRepository<OperationLog> _operationLogRepository;
        private OperationLogBussinessLogic()
        {
            _operationLogRepository = new EfRepository<OperationLog>();
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