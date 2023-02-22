using Redis.OM;
using StackExchange.Redis;
using WebApplication4.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHostedService<IndexCreationService>();
var config = ConfigurationOptions.Parse(builder.Configuration["REDIS_CONNECTION_STRING"]!);
config.SocketManager = SocketManager.ThreadPool;
config.AbortOnConnectFail = false;
builder.Services.AddSingleton(new RedisConnectionProvider(config));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
