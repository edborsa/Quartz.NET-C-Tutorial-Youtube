using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Worker.Contracts.Entities;

namespace Worker.Persistence
{
    public class WorkerDbContext : DbContext
    {
        public WorkerDbContext(DbContextOptions<WorkerDbContext> dbContextoptions) : base(dbContextoptions)
        {
        }

        public DbSet<Log> Logs { get; set; }
    }
}