# How to create the job using Quartz.NET and set up Entity Framework Core

Youtube link: [LINK](https://www.youtube.com/watch?v=XBzX_sKt5eY)

# Purpose of the video

Create a ASP NET application that triggers a job every 5 seconds that delete all logs with attribute "Created"
greater than the specified value in `Worker/appsettings.json`.

```json
{
   "DeleteLogsJob":{
      "CronSchedule":"0/5 * * * * ?",
      "AmountOfDays":30
   }
}
```

The logs comes from another class called `Seeder` in `Worker.Persistence/Seeder.cs` that uses a Faker method to generate data and insert into the database. It inserts this data whenever you start the application.

# Generate Migrations

## Steps:

1. Be sure that you ware inside the Worker foler.
2. run this command: `dotnet ef --startup-project ./Worker.csproj migrations add Init --context Worker.Persistence.WorkerDbContext --output-dir Migrations --project ../Worker.Persistence/Worker.Persistence.csproj`
3. run: `dotnet ef database update`

## Other

- On the part "Creating Seeder" the author forgot that the added the Bogus library:
    - `dotnet add package Bogus` 