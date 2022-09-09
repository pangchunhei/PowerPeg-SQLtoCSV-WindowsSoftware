using log4net;
using PowerPeg_SQL_to_CSV.Log;
using Quartz;
using Quartz.Impl;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class BackgroundScheduler
    {
        private StdSchedulerFactory schedulerFactory;
        private IScheduler scheduler;
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Enable to running of background job in the background
        /// </summary>
        /// <returns></returns>
        public async Task runAsync()
        {
            schedulerFactory = new StdSchedulerFactory();
            scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            log.Info("Background Scheduler is running");

            //创建作业和触发器 .WithIdentity("Backgroud-Schedule-Search")
            IJobDetail jobDetail = JobBuilder.Create<BackgroundJobScheduleTask>().Build();

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

        /// <summary>
        /// Stop the running of the background job
        /// </summary>
        /// <returns></returns>
        public async Task stopAsync()
        {

            IReadOnlyCollection<IJobExecutionContext> jobs = await this.scheduler.GetCurrentlyExecutingJobs();
            foreach (IJobExecutionContext context in jobs)
            {
                log.Debug($"Trying to interrupt job: {context.JobDetail}");
                log.Debug("Interrupt status: " + await this.scheduler.Interrupt(context.JobDetail.Key));
            }

            log.Info("Scheduler Stopped");
            await scheduler.Shutdown(true);
        }
    }
}
