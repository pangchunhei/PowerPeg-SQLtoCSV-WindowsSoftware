using PowerPeg_SQL_to_CSV.Gateway;
using Quartz;
using System.Diagnostics;
using System.Threading;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    //Only run 1 instance at a time
    [DisallowConcurrentExecution]
    public class BackgroundProcessingJob : IJob
    {
        private ScheduleSearchTasklist searchTasklist;
        private List<SearchTask> scheduleRunlist;

        public async Task Execute(IJobExecutionContext context)
        {
            testJob(context);
        }

        private void processTask(IJobExecutionContext context)
        {
            searchTasklist = new ScheduleSearchTasklist();

            scheduleRunlist = searchTasklist.getCurrentTaskList();

            DateTime bwCurrentDateTime = DateTime.Now;

            foreach (SearchTask searchTask in scheduleRunlist)
            {
                searchTask.toRunTask(bwCurrentDateTime);
            }

            if (context.CancellationToken.IsCancellationRequested)
            {
                //Interrrupt triggered
                Debug.WriteLine("Background Job interrupted");
            }
            else
            {
                Debug.WriteLine("State saved");
                JSONGateway jsonGateway = JSONGateway.getInstance();
                jsonGateway.updateJSON(this.scheduleRunlist);
            }
        }

        private void testJob(IJobExecutionContext context)
        {
            Debug.WriteLine("> " + DateTime.Now + " Test Job is executing. ");
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("> " + i);
                Thread.Sleep(1000);
            }

            //Interrrupt triggered
            if (context.CancellationToken.IsCancellationRequested)
            {
                Debug.WriteLine("Test Job interrupted");
            }
        }
    }
}
