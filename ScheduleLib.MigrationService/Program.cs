using Microsoft.EntityFrameworkCore;
using ScheduleLib.Data;
using ScheduleLib.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContextPool<ScheduleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("scheduleLibDb"), sqlOptions =>
        sqlOptions.MigrationsAssembly("ScheduleLib.MigrationService")
    ));
builder.EnrichSqlServerDbContext<ScheduleContext>();

var host = builder.Build();
host.Run();
