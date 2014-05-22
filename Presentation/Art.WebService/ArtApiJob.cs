using Art.BussinessLogic;
using Art.Data.Common;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Art.WebService
{
    public class ArtApiJobManager
    {
        public static void Start()
        {
            // construct a scheduler factory
            ISchedulerFactory factory = new StdSchedulerFactory();

            // get a scheduler
            IScheduler scheduler = factory.GetScheduler();

            scheduler.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<TryToCloseOrderJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity("myTrigger", "group1")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(60)
                  .RepeatForever())
              .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }

    public class TryToCloseOrderJob : IJob
    {
        public int ORDER_WAIT_PAY_MINUTE = 45;
        public void Execute(IJobExecutionContext context)
        {
            var logic = GlobalConfiguration.Configuration.DependencyResolver.BeginScope().GetService(typeof(IOrderBussinessLogic)) as IOrderBussinessLogic;

            var orders = logic.GetOrdersByStatus(OrderStatus.生成中);

            foreach (var order in orders)
            {
                if (DateTime.Now > order.FADateTime.AddMinutes(ORDER_WAIT_PAY_MINUTE))
                {
                    logic.CloseOrder(order);
                }
            }
        }
    }
}