using Microsoft.AspNetCore.Mvc;
using Redis.OM;
using Redis.OM.Searching;
using System;
using WebApplication4.Models;

namespace WebApplication4.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase 
{
    private readonly RedisConnectionProvider _provider;
    private readonly RedisCollection<LogModel> _log;

    public WeatherForecastController(RedisConnectionProvider provider) 
    {
        _provider = provider;
        _log = (RedisCollection<LogModel>)provider.RedisCollection<LogModel>();
    }

    [HttpPost]
    public async Task<LogModel> AddLog([FromBody] LogModel model) 
    {
        await _log.InsertAsync(model, TimeSpan.FromSeconds(20));
        return model;
    }

    [HttpGet]
    public IActionResult GetLog() 
    {
        var firstData = _log.First();
        return Ok(firstData);
    }
}