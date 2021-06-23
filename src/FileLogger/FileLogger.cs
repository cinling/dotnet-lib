using System;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    public class FileLogger : ILogger {

        /// <summary>
        /// 
        /// </summary>
        protected string name;

        private readonly FileLoggerOptions options;

        /// <summary>
        /// 
        /// </summary>
        private readonly FileLoggerWriter loggerWriter;

        /// <summary>
        /// 
        /// </summary>
        private class FileLoggerDisposable : IDisposable {
            public Action DisposeAction { get; set; } = () => {};

            /// <summary>
            /// 
            /// </summary>
            public void Dispose() {
                DisposeAction();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cateName"></param>
        /// <param name="loggerWriter"></param>
        /// <param name="options"></param>
        public FileLogger(string cateName, FileLoggerWriter loggerWriter, FileLoggerOptions options) {
            name = cateName;
            this.loggerWriter = loggerWriter;
            this.options = options;
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
            message = options.MessageFormatter(logLevel, name, eventId.Id, message, exception);
            loggerWriter.Write(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel) {
            return logLevel >= options.MinLevel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <typeparam name="TState"></typeparam>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state) {
            var originName = name;
            name = state.ToString();
            var disposable = new FileLoggerDisposable();
            disposable.DisposeAction = () => {
                name = originName;
            };
            return disposable;
        }
    }
}