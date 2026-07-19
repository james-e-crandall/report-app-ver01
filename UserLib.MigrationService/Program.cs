using Microsoft.EntityFrameworkCore;
using UserLib.Data;
using UserLib.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbContextPool<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("userLibDb"), sqlOptions =>
        sqlOptions.MigrationsAssembly("UserLib.MigrationService")
    ));
builder.EnrichSqlServerDbContext<UserContext>();

var host = builder.Build();
host.Run();
