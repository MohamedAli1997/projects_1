using Newtonsoft.Json;

namespace evisa.api.Extensions;

public class AppSettings
{
    public Logging Logging { get; set; }
    public string Secret { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; }
}

public class Logging
{
    public LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    public string Default { get; set; }
    
    [JsonProperty("Microsoft.AspNetCore")]
    public string MicrosoftAspNetCore { get; set; }
}