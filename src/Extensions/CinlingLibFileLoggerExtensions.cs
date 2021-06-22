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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="configuration"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [Obsolete]
        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, IConfiguration configuration) => AddFileProvider(factory, new FileLoggerConfiguration(configuration));
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="factory"></param>
        /// <param name="fileLoggerSettings"></param>
        /// <returns></returns>
        [Obsolete]
        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, FileLoggerConfiguration fileLoggerSettings) {
            factory.AddProvider(new FileLoggerProvider(fileLoggerSettings));
            return factory;
        }

        public static ILoggerFactory AddFileProvider(this ILoggerFactory factory, FileLoggerOptions options) {
            return factory;
        }
    }

    public static class CinlingLibFileLoggerExtensions {
        /// <summary>
        /// 添加文件提供服务
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder) => AddFile(builder, new FileLoggerOptionsBuilder());

        /// <summary>
        /// 提娜佳
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="fileLoggerOptionsBuilder"></param>
        /// <returns></returns>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, FileLoggerOptionsBuilder fileLoggerOptionsBuilder) => AddFile(builder, options => {
            options.SetWithBuilder(fileLoggerOptionsBuilder);
        });

        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, Action<FileLoggerOptions> optionsAction) {
            builder.Services.AddOptions<FileLoggerOptions>().Configure(optionsAction);
            return builder;
        } 
    }
}