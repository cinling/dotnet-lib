using Cinling.Lib.FileLogger;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Logging {
    
    /// <summary>
    /// ILoggerFactory Extensions
    /// 日志扩展
    /// </summary>
    public static class CinlingLibLoggerFactoryExtensions {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, IConfiguration configuration) {
            return AddFileProvider(factory, new FileLoggerConfiguration(configuration));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="fileLoggerSettings"></param>
        /// <returns></returns>
        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, FileLoggerConfiguration fileLoggerSettings) {
            factory.AddProvider(new FileLoggerProvider(fileLoggerSettings));
            return factory;
        }
    }
}