using System;
using System.IO;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.Services.Implementations
{
    /// <summary>
    /// Defines error logging action in system for global error handling
    /// </summary>
    public class LogService : ILogService
    {
        /// <summary>
        /// File to log exceptions in
        /// </summary>
        private const string logFilePath = "exceptionlog.txt";

        /// <summary>
        /// Logs error message of exception to logfile
        /// </summary>
        /// <param name="message">error message to log to logfile</param>
        public void LogToFile(string message)
        {
            using (var file = new StreamWriter(logFilePath, true))
            {
                file.WriteLine($"{DateTime.Now}: {message}\n");
            }
        }
    }
}