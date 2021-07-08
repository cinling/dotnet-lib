#nullable enable
using System;
using System.Text;
using Cinling.Lib.Extensions;
using Cinling.Lib.FileLogger;
using Cinling.Lib.Helpers;
using Cinling.Lib.Interfaces;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.Options {
    
    /// <summary>
    /// 日志配置选项
    /// </summary>
    public class LogServiceOptions : ICloneWith {
        /// <summary>
        /// 默认日志等级
        /// </summary>
        public LogLevel MinLevel { get; set; } = LogLevel.Information;
        /// <summary>
        /// 日志工厂初始化方法
        /// </summary>
        public Action<ILoggerFactory, FileLoggerOptions> InitLoggerFactoryAction { get; set; } = delegate(ILoggerFactory factory, FileLoggerOptions options) {
            factory.AddFileProvider(options);
        };
    }
}