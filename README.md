# How to create the job using Quartz.NET and set up Entity Framework Core

Youtube link: [LINK](https://www.youtube.com/watch?v=XBzX_sKt5eY)

# Generate Migrations

## Steps:

1. Be sure that you ware inside the Worker foler.
2. run this command: `dotnet ef --startup-project ./Worker.csproj migrations add Init --context Worker.Persistence.WorkerDbContext --output-dir Migrations --project ../Worker.Persistence/Worker.Persistence.csproj`
3. run: `dotnet ef database update`