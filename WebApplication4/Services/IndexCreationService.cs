using Redis.OM;
using System;
using WebApplication4.Models;

namespace WebApplication4.Services; 
public class IndexCreationService : IHostedService
{
    private readonly RedisConnectionProvider _provider;

    public IndexCreationService(RedisConnectionProvider provider) 
    {
        _provider = provider;
    }

    public async Task StartAsync(CancellationToken cancellationToken) 
    {
        await _provider.Connection.CreateIndexAsync(typeof(LogModel));
    }

    public Task StopAsync(CancellationToken cancellationToken) 
    {
        return Task.CompletedTask;
    }
}
