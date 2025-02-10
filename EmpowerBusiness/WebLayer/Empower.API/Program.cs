using Autofac.Extensions.DependencyInjection;
using Autofac;
using Empower.API.Config;
using Empower.Business;
using Empower.Data.EntityFrameworkCore; // Add this to access EPowerDbContext
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empower.Data.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Empower.API.Models;
using Empower.Models.AppSettings;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
    {
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));
builder.Services.AddHangfireServer();


builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    // Add security definition for JWT Bearer
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter your JWT token in the format: Bearer {your token}"
    });

    // Add a global security requirement for the Bearer token
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>() // Empty string array means it applies globally
        }
    });
});


// Register EF Core DbContext
builder.Services.AddDbContext<EPowerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HangfireConnection")));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingConfig));

// Use Autofac for Dependency Injection
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // Register application modules
    containerBuilder.RegisterModule(new BLServiceModules());

    // Ensure EPowerDbContext is registered
    containerBuilder.RegisterType<EPowerDbContext>()
                    .AsSelf()
                    .InstancePerLifetimeScope();

    // Register generic repository
    containerBuilder.RegisterGeneric(typeof(Repository<>))
                    .As(typeof(IRepository<>))
                    .InstancePerLifetimeScope();
});

//Activate JWT Tokern service
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");
var issuer = builder.Configuration.GetValue<string>("ApiSettings:Issuer");
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = false
    };
});



//Configure app setting map
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.Configure<Domains>(builder.Configuration.GetSection("Domains"));
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));
//builder.Services.Configure<SmsConfig>(builder.Configuration.GetSection("SmsConfig"));
//builder.Services.Configure<PaymentConfig>(builder.Configuration.GetSection("PaymentConfig"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseHangfireDashboard("/dashboard");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllers();
app.Run();















//using Autofac.Extensions.DependencyInjection;
//using Autofac;
//using Empower.API.Config;
//using Empower.Business;
//using Hangfire;
//using Hangfire.SqlServer;
//using Microsoft.AspNetCore.Mvc;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddHangfire(configuration => configuration
//       .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//       .UseSimpleAssemblyNameTypeSerializer()
//       .UseRecommendedSerializerSettings()
//       .UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"), new SqlServerStorageOptions
//       {
//           CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
//           SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
//           QueuePollInterval = TimeSpan.Zero,
//           UseRecommendedIsolationLevel = true,
//           DisableGlobalLocks = true
//       }));
//builder.Services.AddHangfireServer();

//builder.Services.AddControllers();
//// Add services to the container.

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(MappingConfig));

//builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new BLServiceModules()));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseHangfireDashboard("/dashboard");

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
