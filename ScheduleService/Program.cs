using ScheduleService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddHostedService<CronJobService>();


var host = builder.Build();
host.Run();
