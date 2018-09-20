using System;
using System.IO;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    public class LogService : ILogService
    {
        private const string logFilePath = "exceptionlog.txt";
        public void LogToFile(string message)
        {
            using (var file = new StreamWriter(logFilePath, true))
            {
                file.WriteLine($"{DateTime.Now}: {message}\n");
            }
        }
    }
}