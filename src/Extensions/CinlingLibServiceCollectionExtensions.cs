using System;
using Cinling.Lib.Interfaces;
using Cinling.Lib.Services;
using Cinling.Lib.Structs.Cos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
        public static IServiceCollection AddCinlingLibLogService(this IServiceCollection services) {
            services.AddOptions();
            services.AddLogging();
            services.AddScoped<ILogService, LogService>();
            return services;
        }
    }
}