using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using Quartz;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    //Background Job
    //Only run 1 instance at a time
    [DisallowConcurrentExecution]
    public class BackgroundJobScheduleTask : IJob
    {
        private ScheduleSearchTasklist searchTasklist;
        private List<SearchTask> scheduleRunlist;
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Run the background job's function
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            //testJob(context);

            processTask(context);
        }

        /// <summary>
        /// Detail of the background job
        /// </summary>
        /// <param name="context"></param>
        private void processTask(IJobExecutionContext context)
        {
            log.Info($"Backround job is created and running: {context.JobDetail.Key}, UTCFiretime: {context.FireTimeUtc}");

            searchTasklist = new ScheduleSearchTasklist();

            scheduleRunlist = searchTasklist.getCurrentTaskList();

            foreach (SearchTask searchTask in scheduleRunlist)
            {
                log.Debug($"Background job process search task of {searchTask.getTaskInfo()[0]}");
                searchTask.toRunTask();
            }

            if (context.CancellationToken.IsCancellationRequested)
            {
                //Interrrupt triggered
                log.Info("Background Job interrupted");
            }
            else
            {
                log.Info("Finished background job, save the search task state");
                JSONGateway jsonGateway = JSONGateway.getInstance();
                jsonGateway.updateTasklistJSON(this.scheduleRunlist);
            }
        }

        /// <summary>
        /// Detail of the testing background job
        /// </summary>
        /// <param name="context"></param>
        private void testJob(IJobExecutionContext context)
        {
            log.Info("Test Job is executing");
            for (int i = 0; i < 10; i++)
            {
                log.Debug("> " + i);
                Thread.Sleep(1000);
            }

            //Interrrupt triggered
            if (context.CancellationToken.IsCancellationRequested)
            {
                log.Debug("Test Job interrupted");
            }
        }
    }
}
