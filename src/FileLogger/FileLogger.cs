using System;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    public class FileLogger : ILogger {

        /// <summary>
        /// 
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public LogLevel level;

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
        public FileLogger(string cateName, FileLoggerWriter loggerWriter) {
            name = cateName;
            this.loggerWriter = loggerWriter;
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

            var content = formatter(state, exception);
            loggerWriter.write(content);
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