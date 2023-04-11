using System;

namespace Backend.Shared.Utilities.Telemetry
{
    public interface ITelemetryException
    {
        void RegisterException(Exception exception);
    }
}