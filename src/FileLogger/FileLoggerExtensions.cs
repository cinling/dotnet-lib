using Cinling.Lib.FileLogger;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Logging {
    public static class FileLoggerExtensions {
        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, IConfiguration configuration) {
            return AddFileProvider(factory, new FileLoggerConfiguration(configuration));
        }

        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, FileLoggerConfiguration fileLoggerSettings) {
            factory.AddProvider(new FileLoggerProvider(fileLoggerSettings));
            return factory;
        }
    }
}