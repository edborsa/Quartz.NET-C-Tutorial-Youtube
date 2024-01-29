using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Quartz;
using Worker.Contracts.Respositories;
using Worker.Options;

namespace Worker.Jobs
{
    public class DeleteLogsJob : IJob
    {
        private readonly ILogRepository _logRepository;
        


        public DeleteLogsJob(ILogRepository logRepository, IOptions<DeleteLogsJobOptions> options)
        {
            _logRepository = logRepository;
            _amountOfDays = options.Value.DeleteAfterDate ??
                throw new ArgumentException("DeleteAfterDate was not found in configuration");
        }
        public async Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}