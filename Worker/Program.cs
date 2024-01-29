using Microsoft.EntityFrameworkCore;
using Worker.Contracts.Respositories;
using Worker.Persistence;
using Worker.Persistence.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<WorkerDbContext>(options =>
        {
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbConnectionString"));
        });
        services.AddScoped<ILogRepository, LogRepository>();
    })
    .Build();

host.Run();