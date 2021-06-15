using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    public class FileLoggerProvider : ILoggerProvider {
        private readonly ConcurrentDictionary<string, FileLogger> loggerCateDict = new ();
        private readonly FileLoggerConfiguration co;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public FileLoggerProvider(FileLoggerConfiguration configuration) {
            co = configuration;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName) {
            return loggerCateDict.GetOrAdd(categoryName, name => {
                var logger = new FileLogger(name);
                return logger;
            });
        }
    }
}