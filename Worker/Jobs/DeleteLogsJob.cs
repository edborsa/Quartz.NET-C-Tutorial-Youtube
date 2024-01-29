using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;
using Worker.Contracts.Respositories;

namespace Worker.Jobs
{
    public class DeleteLogsJob : IJob
    {
        private readonly ILogRepository _logRepository;

        public DeleteLogsJob(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}