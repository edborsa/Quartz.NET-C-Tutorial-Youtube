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

using var scope = host.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<WorkerDbContext>();

if (dbContext != null) {
    Seeder.Seed(dbContext);
}

host.Run();