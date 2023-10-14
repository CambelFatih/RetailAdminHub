using FluentValidation;
using FluentValidation.AspNetCore;
using RetailAdminHub.API.Extensions.Middleware;
using RetailAdminHub.Application;
using RetailAdminHub.Application.Validators;
using RetailAdminHub.Domain.Logger;
using RetailAdminHub.Infrastructure.Filters;
using RetailAdminHub.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
Log.Information("App server is starting.");


// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
//builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost/4200", "https://localhost/4200").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
})
.ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<BaseValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<HeartBeatMiddleware>();
Action<RequestProfilerModel> requestResponseHandler = requestProfilerModel =>
{
    Log.Information("-------------Request-Begin------------");
    Log.Information(requestProfilerModel.Request);
    Log.Information(Environment.NewLine);
    Log.Information(requestProfilerModel.Response);
    Log.Information("-------------Request-End------------");
};
app.UseMiddleware<RequestLoggingMiddleware>(requestResponseHandler);
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<UserContextMiddleware>();
app.MapControllers();

app.Run();
