using Cinling.Lib.FileLogger;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Logging {
    public static class FileLoggerExtensions {
        public static ILoggerFactory AddFile(this ILoggerFactory factory, IConfiguration configuration) {
            return AddFile(factory, new FileLoggerConfiguration(configuration));
        }

        public static ILoggerFactory AddFile(this ILoggerFactory factory, FileLoggerConfiguration fileLoggerSettings) {
            factory.AddProvider(new FileLoggerProvider(fileLoggerSettings));
            return factory;
        }
    }
}