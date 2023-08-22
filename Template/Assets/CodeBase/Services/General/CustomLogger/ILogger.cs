using System;

namespace CodeBase.Infrastructure.Services.CustomLogger
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string errorMessage);
        void LogException(Exception exception);
    }
}