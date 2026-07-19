var builder = DistributedApplication.CreateBuilder(args);

var sqlserver = builder.AddSqlServer("sqlserver")
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDbGate();

var userLibDb = sqlserver.AddDatabase("userLibDb");

var scheduleLibDb = sqlserver.AddDatabase("scheduleLibDb");

var userLibMigrationService = builder.AddProject<Projects.UserLib_MigrationService>("userLibMigrationService")
    .WithReference(userLibDb)
    .WaitFor(userLibDb);

var scheduleLibMigrationService = builder.AddProject<Projects.ScheduleLib_MigrationService>("scheduleLibMigrationService")
    .WithReference(scheduleLibDb)
    .WaitFor(scheduleLibDb);


builder.Build().Run();
