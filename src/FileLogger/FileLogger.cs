using System;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    public class FileLogger : ILogger {

        /// <summary>
        /// 
        /// </summary>
        public string name { get; private set; }

        public LogLevel level;
        
        /// <summary>
        /// 
        /// </summary>
        private readonly FileLoggerConfiguration co;

        /// <summary>
        /// 
        /// </summary>
        private class FileLoggerDisposable : IDisposable {
            public void Dispose() {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly FileLoggerDisposable disposable = new();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cateName"></param>
        /// <param name="co"></param>
        public FileLogger(string cateName, FileLoggerConfiguration co) {
            name = cateName;
            this.co = co;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="eventId"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        /// <param name="formatter"></param>
        /// <typeparam name="TState"></typeparam>
        /// <exception cref="NotImplementedException"></exception>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel) {
            return level <= logLevel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <typeparam name="TState"></typeparam>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state) {
            return disposable;
        }
    }
}