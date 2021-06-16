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
        private readonly FileLoggerConfiguration co;
        /// <summary>
        /// 
        /// </summary>
        private readonly FileLoggerWriter loggerWriter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public FileLoggerProvider(FileLoggerConfiguration configuration) {
            co = configuration;
            loggerWriter = new FileLoggerWriter(co.SavePath);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            loggerWriter.BeginWriteQueue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName) {
            return loggerCateDict.GetOrAdd(categoryName, name => {
                var logger = new FileLogger(name, loggerWriter);
                return logger;
            });
        }
    }
}