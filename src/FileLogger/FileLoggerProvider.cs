using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    /// <summary>
    /// 
    /// </summary>
    public class FileLoggerProvider : ILoggerProvider {
        /// <summary>
        /// 
        /// </summary>
        private readonly ConcurrentDictionary<string, FileLogger> loggerCateDict = new ();
        /// <summary>
        /// 
        /// </summary>
        private readonly FileLoggerOptions options;
        /// <summary>
        /// 
        /// </summary>
        private FileLoggerWriter loggerWriter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public FileLoggerProvider(FileLoggerOptions options) {
            this.options = options;
            OnInit();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            loggerWriter?.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        protected void OnInit() {
            loggerWriter = new FileLoggerWriter(options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName) {
            return loggerCateDict.GetOrAdd(categoryName, name => {
                var logger = new FileLogger(name, loggerWriter, options);
                return logger;
            });
        }
    }
}