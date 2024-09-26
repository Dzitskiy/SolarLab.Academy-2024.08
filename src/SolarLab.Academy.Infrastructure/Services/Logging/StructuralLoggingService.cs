using Serilog.Context;
using SolarLab.Academy.AppServices.Services;

namespace SolarLab.Academy.Infrastructure.Services.Logging;

/// <inheritdoc />
public class StructuralLoggingService : IStructuralLoggingService
{
    /// <inheritdoc />
    public IDisposable PushProperty(string name, object value, bool destructureObjects = false)
    {
        return LogContext.PushProperty(name, value, destructureObjects);
    }
}