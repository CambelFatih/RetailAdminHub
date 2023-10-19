using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RetailAdminHub.API.Extensions.Middleware;
using RetailAdminHub.Application;
using RetailAdminHub.Application.Helpers;
using RetailAdminHub.Domain.Base.Logger;
using RetailAdminHub.Domain.Base.Token;
using RetailAdminHub.Infrastructure.Filters;
using RetailAdminHub.Persistence;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure appsettings.json
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
// Configure Logger
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
Log.Information("App server is starting.");

// Configure JWT
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// Configure CORS policy to allow any origin, method, and header
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

//builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
}).ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = false);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Swagger customization
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RetailAdminHubApi Api Management", Version = "v1.0" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "RetailAdminHubApi Management for IT Company",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});

// JWT Authentication customization
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>(); // JwtConfig ayarlarýný al
    if (jwtConfig != null)
    {
        x.RequireHttpsMetadata = true;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtConfig.Issuer,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
            ValidAudience = jwtConfig.Audience,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(2)
        };
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure request-response logging middleware
Action<RequestProfilerModel> requestResponseHandler = requestProfilerModel =>
{
    Log.Information("-------------Request-Begin------------");
    Log.Information(requestProfilerModel.Request);
    Log.Information(Environment.NewLine);
    Log.Information(requestProfilerModel.Response);
    Log.Information("-------------Request-End------------");
};
// Configure and use middleware for error handling, heartbeat, request logging, HTTPS redirection, authentication, authorization, and user context
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<HeartBeatMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>(requestResponseHandler);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<UserContextMiddleware>();
app.MapControllers();

app.Run();
