#nullable enable
using System;
using System.IO;
using System.Text;
using Cinling.Lib.Helpers;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    
    /// <summary>
    /// 日志初始化
    /// </summary>
    public class FileLoggerOptions {
        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string SavePath { get; set; } = Directory.GetCurrentDirectory() + "/runtime/cin-log";

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

        /// <summary>
        /// 使用 builder 重构配置
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public FileLoggerOptions SetWithBuilder(FileLoggerOptionsBuilder builder) {
            SavePath = builder.SavePath ?? SavePath;
            MessageFormatter = builder.MessageFormatter ?? MessageFormatter;
            return this;
        }
    }

    public class FileLoggerOptionsBuilder {
        /// <summary>
        /// 
        /// </summary>
        public string? SavePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Func<LogLevel, string, int, string, Exception?, string>? MessageFormatter { get; set; }
    }
}