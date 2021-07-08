using Cinling.Lib.FileLogger;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.Extensions {
    
    /// <summary>
    /// ILoggerFactory Extensions
    /// 日志扩展
    /// </summary>
    public static class FileLoggerFactoryExtensions {
        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, FileLoggerOptions options) {
            factory.AddProvider(new FileLoggerProvider(options));
            return factory;
        }
    }
}