using API.Extensions;
using Application;
using Hangfire;
using Infrastructure;
using Persistence;
using Hangfire;
using API.BackgroundJobs;
using Microsoft.Extensions.Configuration;
using Hangfire.SqlServer;
using Hangfire.Dashboard;
using Application.Interfaces.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<ICarrierReport, CarrierReport>();

builder.Services.AddHangfire(x => builder.Configuration.GetConnectionString("DevConnection"));
builder.Services.AddHangfireServer();

GlobalConfiguration.Configuration
                .UseSqlServerStorage(builder.Configuration.GetConnectionString("DevConnection"));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();

app.MapHangfireDashboard();

app.UseHangfireServer(new BackgroundJobServerOptions());

GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 3 });

RecurringJobs.GetHourlyCarrierReport(app.Services);

//app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
