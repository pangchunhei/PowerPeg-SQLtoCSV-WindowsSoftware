using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Quartz.Logging.OperationName;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class BackgroundScheduler
    {
        private StdSchedulerFactory schedulerFactory;
        private IScheduler scheduler;

        public async Task runAsync()
        {
            schedulerFactory = new StdSchedulerFactory();
            scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            Debug.WriteLine("Background Scheduler is running");

            //创建作业和触发器 .WithIdentity("Backgroud-Schedule-Search")
            IJobDetail jobDetail = JobBuilder.Create<BackgroundProcessingJob>().Build();

            //Every 1 sec create an new Job
            ITrigger trigger = TriggerBuilder.Create()
                                        .WithSimpleSchedule(m =>
                                        {
                                            m.RepeatForever().WithIntervalInSeconds(10);
                                        })
                                        .Build();

            //添加调度
            await scheduler.ScheduleJob(jobDetail, trigger);

        }

        public async Task stopAsync()
        {

            IReadOnlyCollection<IJobExecutionContext> jobs = await this.scheduler.GetCurrentlyExecutingJobs();
            foreach (IJobExecutionContext context in jobs)
            {
                Debug.WriteLine($"Trying to interrupt job {context.JobDetail}");
                Debug.WriteLine(await this.scheduler.Interrupt(context.JobDetail.Key));
            }

            Debug.WriteLine("Stop scheduler");
            await scheduler.Shutdown(true);
        }
    }
}
