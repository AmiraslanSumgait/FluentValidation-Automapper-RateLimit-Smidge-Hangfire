using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddOptions();
builder.Services.AddMemoryCache();


//builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<ClientRateLimitOptions>(builder.Configuration.GetSection("ClientRateLimiting"));

//builder.Services.Configure<IpRateLimitPolicy>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.Configure <ClientRateLimitPolicies>(builder.Configuration.GetSection("ClientRateLimitPolicies"));

//builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();

builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();


var webHost = builder.Build();
var IpPolicy = webHost.Services.GetRequiredService<IClientPolicyStore>();
IpPolicy.SeedAsync().Wait();

// Configure the HTTP request pipeline.
if (webHost.Environment.IsDevelopment())
{
    webHost.UseSwagger();
    webHost.UseSwaggerUI();
}
//webHost.UseIpRateLimiting();
webHost.UseClientRateLimiting();

webHost.UseHttpsRedirection();

webHost.UseAuthorization();

webHost.MapControllers();

webHost.Run();
