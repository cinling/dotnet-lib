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
        public LogLevel MinLevel { get; set; } = LogLevel.Information;

        /// <summary>
        /// 
        /// </summary>
        public Func<LogLevel, string, int, string, Exception?, string> MessageFormatter { get; set; } = delegate(LogLevel level, string logName, int eventId, string message, Exception? exception) {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"[{eventId}-{logName}][{TimeHelper.Datetime()} {level} {message}]" + Environment.NewLine);
            if (exception != null) {
                stringBuilder.Append(exception);
            }
            return stringBuilder.ToString();
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public void Reset(FileLoggerOptions options) {
            SavePath = options.SavePath;
            MinLevel = options.MinLevel;
            MessageFormatter = options.MessageFormatter;
        }
    }
}