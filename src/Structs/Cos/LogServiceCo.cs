using System;
using Cinling.Lib.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cinling.Lib.Structs.Cos {
    
    /// <summary>
    /// 
    /// </summary>
    public class LogServiceCo : BaseCo, ILogServiceCo, IConfigureOptions<LogServiceCo> {
        /// <summary>
        /// 
        /// </summary>
        public Action<ILoggerFactory> InitLoggerFactoryAction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public LogServiceCo(IConfiguration configuration) {
            this.configuration = configuration;
            LoadDefaultConfig();
        }

        /// <summary>
        /// 加载默认配置
        /// </summary>
        private void LoadDefaultConfig() {
            this.SetInitLoggerFactoryAction(loggerFactory => {
                loggerFactory.AddFileProvider(configuration);
            });
        }

        public void Configure(LogServiceCo options) {
            
        }
    }
}