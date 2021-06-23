using System;
using Cinling.Lib.FileLogger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Logging {
    
    /// <summary>
    /// ILoggerFactory Extensions
    /// 日志扩展
    /// </summary>
    public static class CinlingLibFileLoggerFactoryExtensions {
        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, FileLoggerOptions options) {
            factory.AddProvider(new FileLoggerProvider(options));
            return factory;
        }
    }
}