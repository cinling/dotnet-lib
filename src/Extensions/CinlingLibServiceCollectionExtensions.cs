using System;
using Cinling.Lib.FileLogger;
using Cinling.Lib.Interfaces;
using Cinling.Lib.Options;
using Cinling.Lib.Services;
using Cinling.Lib.Structs.Cos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection {
    
    /// <summary>
    /// IServiceCollection Extensions
    /// 服务扩展方法
    /// </summary>
    public static class CinlingLibServiceCollectionExtensions {

        /// <summary>
        /// 添加日志服务
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddLogServiceScoped(this IServiceCollection services) => AddLogServiceScoped(services, new LogServiceOptions());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IServiceCollection AddLogServiceScoped(this IServiceCollection services, LogServiceOptions options) => AddLogServiceScoped(services, originOptions => {
            originOptions.CloneWith(options);
        }, _ => {});

        /// <summary>
        /// 最终初始化方法
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <param name="fileLoggerOptionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddLogServiceScoped(this IServiceCollection services, Action<LogServiceOptions> optionsAction, Action<FileLoggerOptions> fileLoggerOptionsAction) {
            services.AddOptions();
            services.AddOptions<LogServiceOptions>().Configure(optionsAction);
            services.AddOptions<FileLoggerOptions>().Configure(fileLoggerOptionsAction);
            services.AddLogging();
            services.AddScoped<ILogService, LogService>();
            return services;
        }
    }
}