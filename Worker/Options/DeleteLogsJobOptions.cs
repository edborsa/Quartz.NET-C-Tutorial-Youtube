using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worker.Options
{
    public class DeleteLogsJobOptions
    {
        public const string DeleteLogsJob = "DeleteLogsJob";
        public int? AmountOfDays { get; set; }
    }
}