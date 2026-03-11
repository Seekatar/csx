// Requires NuGet: Microsoft.Extensions.Logging.Abstractions
// Requires NuGet: Microsoft.Extensions.Logging.Console

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Logging.Console;
using static System.Console;

// ILoggerFactory loggerFactory = new LoggerFactory().AddConsole();
ILogger logger = null;
int i = 0;
string
using (var lt = new LogTimer(logger, () => $"{i}")) {
    await Task.Delay(1000);
    i = 123;
}

var a = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic","Test");
WriteLine($">>{a}<<");

try {
    new Uri("{Request.Host}/{Request.Path}/{body.AppName}");
} catch ( Exception e)
{
    WriteLine($"e is ${e.GetType().Name} {e}");
}
new Uri("http://unknown")

WriteLine(Type.GetType("asdfsdaf")?.Name ?? "Null");
WriteLine(Type.GetType("System.String").Name);

public class LogTimer : IDisposable
{
    private bool disposedValue;
    private readonly ILogger _logger;
    private readonly Stopwatch _sw;
    private readonly Guid _correlationId;
    Func<string> _f;

    public LogTimer(ILogger logger, Guid correlationId, Func<string> f)
    {
        _f = f;
        _logger = logger;
        _correlationId = correlationId;
        _sw = Stopwatch.StartNew();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            System.Console.WriteLine($"{_name} took {_f()} {_sw.Elapsed.TotalSeconds:0.00}s");
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}