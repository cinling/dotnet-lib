using System;
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
        public static IServiceCollection AddCinlingLibLogService(this IServiceCollection services) => AddCinlingLibLogService(services, new LogServiceOptionsBuilder());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IServiceCollection AddCinlingLibLogService(this IServiceCollection services, LogServiceOptionsBuilder builder) => AddCinlingLibLogService(services, options => {
            options.SetWithBuilder(builder);
        });

        public static IServiceCollection AddCinlingLibLogService(this IServiceCollection services, Action<LogServiceOptions> optionsAction) {
            services.AddOptions<LogServiceOptions>().Configure(optionsAction);
            services.AddOptions();
            services.AddLogging(builder => {
                builder.AddFile();
            });
            services.AddScoped<ILogService, LogService>();
            return services;
        }
    }
}