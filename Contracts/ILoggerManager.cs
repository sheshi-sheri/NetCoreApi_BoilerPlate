using System;

namespace Contracts
{
    public interface ILoggerManager
    {
        void LogWarn(string message);
        void LogInfo(string message);

        void LogDebug(string message);

        void LogError(string message);

    }
}
