using Microsoft.EntityFrameworkCore;
using Quartz;
using Worker.Contracts.Respositories;
using Worker.Jobs;
using Worker.Options;
using Worker.Persistence;
using Worker.Persistence.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<WorkerDbContext>(options =>
        {
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("DbConnectionString"));
        });

        services.AddQuartz(q =>
        {
            var jobKey = new JobKey("DeleteLogsJob");

            q.AddJob<DeleteLogsJob>(opts => opts.WithIdentity(jobKey));

            q.AddTrigger(opts => opts
            .ForJob(jobKey)
            .WithIdentity($"{jobKey}-trigger")
            .WithCronSchedule(hostContext.Configuration.GetSection("DeleteLogsJob:CronSchedule").Value ?? "0/5 * * * * ?"));
        });

        services.AddScoped<ILogRepository, LogRepository>();
        services.Configure<DeleteLogsJobOptions>(hostContext.Configuration.GetSection(DeleteLogsJobOptions.DeleteLogsJob));
    })
    .Build();

using var scope = host.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<WorkerDbContext>();

if (dbContext != null)
{
    Seeder.Seed(dbContext);
}

host.Run();