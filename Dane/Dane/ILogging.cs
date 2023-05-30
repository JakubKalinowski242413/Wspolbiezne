using System;

namespace Dane
{
    public interface ILogging
    {
        void writeLogs(ILoggingSingle singleLog);

        void clearLogFile();
    }
}