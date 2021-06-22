using System;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    public class FileLogger : ILogger {

        /// <summary>
        /// 
        /// </summary>
        private string name;

        /// <summary>
        /// 
        /// </summary>
        private readonly LogLevel level;

        /// <summary>
        /// 
        /// </summary>
        private readonly FileLoggerWriter loggerWriter;

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
        /// <param name="loggerWriter"></param>
        /// <param name="level"></param>
        public FileLogger(string cateName, FileLoggerWriter loggerWriter, LogLevel level) {
            name = cateName;
            this.loggerWriter = loggerWriter;
            this.level = level;
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
            if (!IsEnabled(logLevel)) {
                return;
            }

            var message = formatter(state, exception);
            loggerWriter.Write(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel) {
            return logLevel >= level;
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