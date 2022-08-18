using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.Extensions.Logging;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class Processor : IInvocable
    {
        private readonly ILogger<Processor> logger;

        public Processor(ILogger<Processor> Logger)
        {
            this.logger = Logger;
        }

        public Task Invoke()
        {
            var jobId = Guid.NewGuid();
            logger.LogInformation($"Starting job ID {jobId}");

            return Task.FromResult(true);
        }
    }
}
