using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worker.Contracts.Respositories;

namespace Worker.Persistence.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly WorkerDbContext _dbContext;

        public LogRepository(WorkerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task RemoveLogsAfterPeriodOfTime(DateTime date)
        {
            var logsToDelete = _dbContext.Logs.Where(x => x.Created < date);
            _dbContext.Logs.RemoveRange(logsToDelete);
            await _dbContext.SaveChangesAsync();
        }

    }
}