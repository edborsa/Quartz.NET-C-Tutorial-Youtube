using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Worker.Contracts.Entities
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime Created { get; set; }

        public LogLevel LogLevel { get; set; }
    }
}