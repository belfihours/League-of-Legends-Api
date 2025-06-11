using League.Common.Configuration;
using League.Service;
using League.Service.Interface;
using Serilog;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

builder.Services.AddOptions<ApiConfiguration>().BindConfiguration(ApiConfiguration.Section)
    .ValidateDataAnnotations()
    .ValidateOnStart();

Log.Logger = new LoggerConfiguration().CreateLogger();
builder.Services.AddLogging(logging=>
    logging.Services.AddSingleton<ILoggerProvider, SerilogLoggerProvider>(s=>new()));

builder.Services.AddHttpClient();

builder.Services.AddSingleton<IChampionsService, ChampionsService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
