using Microsoft.AspNetCore.Hosting;
using nas_daily_api.Controllers;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Repositories;
using nas_daily_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure the application's services.
builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("DatabaseSetting"));

builder.Services.AddHttpClient();

// Register the controllers and enable API endpoints.

builder.Services.AddControllers();

// Configure Swagger/OpenAPI.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configure Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Configure our services
ConfigureServices(builder.Services);
var app = builder.Build();

//Add CORS middleware to allow req from any origin
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

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

void ConfigureServices(IServiceCollection services)
{
    builder.Services.AddScoped<IOASRepository, OASRepository>();
    builder.Services.AddScoped<IOASService, OASService>();
    builder.Services.AddScoped<INASRepository, NASRepository>();
    builder.Services.AddScoped<INASService, NASService>();
    builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
    builder.Services.AddScoped<IOfficeService, OfficeService>();
    builder.Services.AddScoped<ISuperiorRepository, SuperiorRepository>();
    builder.Services.AddScoped<ISuperiorService, SuperiorService>();
    builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
    builder.Services.AddScoped<IScheduleService, ScheduleService>();
    builder.Services.AddScoped<ILogRepository, LogRepository>();
    builder.Services.AddScoped<ILogService, LogService>();
    builder.Services.AddScoped<ITasksRepository, TasksRepository>();
    builder.Services.AddScoped<ITasksService, TasksService>();
    builder.Services.AddScoped<IAbsenceRepository, AbsenceRepository>();
    builder.Services.AddScoped<IAbsenceService, AbsenceService>();
    builder.Services.AddScoped<IAttendanceSummaryRepository, AttendanceSummaryRepository>();
    builder.Services.AddScoped<IAttendanceSummaryService, AttendanceSummaryService>();
    builder.Services.AddScoped<IEvaluationResultRepository, EvaluationResultRepository>();
    builder.Services.AddScoped<IEvaluationResultService, EvaluationResultService>();
    builder.Services.AddScoped<IEvaluationRatingRepository, EvaluationRatingRepository>();
    builder.Services.AddScoped<IEvaluationRatingService, EvaluationRatingService>();

    //AutoMapper
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
}
