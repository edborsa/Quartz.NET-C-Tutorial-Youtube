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
    [DisallowConcurrentExecution]
    public class DeleteLogsJob : IJob
    {
        private readonly ILogRepository _logRepository;
        private readonly int _amountOfDays;

        public DeleteLogsJob(ILogRepository logRepository, IOptions<DeleteLogsJobOptions> options)
        {
            _logRepository = logRepository;
            _amountOfDays = options.Value.AmountOfDays ??
                throw new ArgumentException("Amount of days can't be null");
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var date = DateTime.Now.AddDays(-_amountOfDays);
            await _logRepository.RemoveLogsAfterPeriodOfTime(date);
        }
    }
}