#nullable enable
using System;
using System.Text;
using Cinling.Lib.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.Options {
    
    /// <summary>
    /// 日志配置选项
    /// </summary>
    public class LogServiceOptions {
        /// <summary>
        /// 默认日志等级
        /// </summary>
        public LogLevel MinLevel { get; set; } = LogLevel.Information;
        /// <summary>
        /// 日志工厂初始化方法
        /// </summary>
        public Action<ILoggerFactory, IConfiguration> InitLoggerFactoryAction { get; set; } = delegate(ILoggerFactory factory, IConfiguration configuration) {
            factory.AddFileProvider(configuration);
        };
        
        /// <summary>
        /// 
        /// </summary>
        public Func<LogLevel, string, int, string, Exception?, string> MessageFormatter { get; set; } = delegate(LogLevel level, string logName, int eventId, string message, Exception? exception) {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"[{eventId}-{logName}][{TimeHelper.datetime()} {level} {message}]" + Environment.NewLine);
            if (exception != null) {
                stringBuilder.Append(exception);
            }
            return stringBuilder.ToString();
        };

        public void SetWithBuilder(LogServiceOptionsBuilder builder) {
            MinLevel = builder.MinLevel ?? MinLevel;
            InitLoggerFactoryAction = builder.InitLoggerFactoryFunc ?? InitLoggerFactoryAction;
            MessageFormatter = builder.MessageFormatter ?? MessageFormatter;
        }
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
        
        /// <summary>
        /// 
        /// </summary>
        public Func<LogLevel, string, int, string, Exception?, string>? MessageFormatter { get; set; } = delegate(LogLevel level, string logName, int eventId, string message, Exception? exception) {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"[{eventId}-{logName}][{TimeHelper.datetime()} {level} {message}]" + Environment.NewLine);
            if (exception != null) {
                stringBuilder.Append(exception);
            }
            return stringBuilder.ToString();
        };
    }
}