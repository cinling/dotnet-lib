using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.Options {
    public class LogServiceOptions {
        /// <summary>
        /// 默认日志等级
        /// </summary>
        public LogLevel MinLevel { get; set; } = LogLevel.Information;
        /// <summary>
        /// 日志工厂初始化方法
        /// </summary>
        public Action<ILoggerFactory, IConfiguration> InitLoggerFactoryFunc { get; set; } = delegate(ILoggerFactory factory, IConfiguration configuration) {
            factory.AddFileProvider(configuration);
        };
    }

    public class LogServiceOptionsBuilder {
        /// <summary>
        /// 
        /// </summary>
        public LogLevel? MinLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Action<ILoggerFactory, IConfiguration>? InitLoggerFactoryFunc { get; set; }
    }
}