using Microsoft.EntityFrameworkCore;
using Worker.Persistence;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<WorkerDbContext>(options =>
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbConnectionString")));
           })
    .Build();

host.Run();