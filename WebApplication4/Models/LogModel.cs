using Redis.OM.Modeling;

namespace WebApplication4.Models;

[Document]
public class LogModel 
{
    [Indexed]
    public string? LogSource { get; set; }

    [Indexed]
    public string? LogText { get; set; }
}
