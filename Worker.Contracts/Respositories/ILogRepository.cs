using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worker.Contracts.Respositories
{
    public interface ILogRepository
    {
        Task RemoveLogsAfterPeriodOfTime(DateTime date);
    }
}