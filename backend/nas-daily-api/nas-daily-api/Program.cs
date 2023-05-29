using nas_daily_api.Controllers;
using nas_daily_api.DatabaseSettings;
using nas_daily_api.Repositories;
using nas_daily_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure the application's services.
builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("DatabaseSetting"));
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
builder.Services.AddHttpClient();

// Register the controllers and enable API endpoints.

builder.Services.AddControllers();

// Configure Swagger/OpenAPI.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
