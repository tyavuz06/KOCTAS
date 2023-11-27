using AspNetCoreRateLimit;
using KOCTAS.API;
using KOCTAS.Business;
using KOCTAS.Business.Core;
using KOCTAS.Business.Interfaces;
using KOCTAS.Data.Core;
using KOCTAS.Data.Interfaces;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//IP limits
builder.Services.AddOptions();
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddControllers();

builder.Services.AddSingleton<IMapper, AutoMap>();
builder.Services.AddSingleton<IMovieBusiness, MovieBusiness>();
builder.Services.AddSingleton<IMovieDal, MovieDal>();
var app = builder.Build();
app.UseIpRateLimiting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
IIpPolicyStore IpPolicy = app.Services.GetRequiredService<IIpPolicyStore>();
await IpPolicy.SeedAsync();
app.Run();
