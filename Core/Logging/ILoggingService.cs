using Lunula.Core.Components;

namespace Lunula.Core.Logging
{
    public interface ILoggingService
    {
        ILogger CreateLogger(string name = "");
    }
}