using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using Quartz;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    //Only run 1 instance at a time
    [DisallowConcurrentExecution]
    public class BackgroundProcessingJob : IJob
    {
        private ScheduleSearchTasklist searchTasklist;
        private List<SearchTask> scheduleRunlist;
        private static readonly ILog log = LogHelper.getLogger();

        public async Task Execute(IJobExecutionContext context)
        {
            //testJob(context);

            processTask(context);
        }

        private void processTask(IJobExecutionContext context)
        {
            log.Info($"Backround job is created and running");

            searchTasklist = new ScheduleSearchTasklist();

            scheduleRunlist = searchTasklist.getCurrentTaskList();

            DateTime bwCurrentDateTime = DateTime.Now;

            foreach (SearchTask searchTask in scheduleRunlist)
            {
                log.Debug($"Background job process search task of {searchTask.getTaskInfo()[0]}");
                searchTask.toRunTask(bwCurrentDateTime);
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
