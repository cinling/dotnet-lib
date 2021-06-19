using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.Interfaces {
    
    /// <summary>
    /// 日志配置接口
    /// </summary>
    public interface ILogServiceCo {
        
        /// <summary>
        /// LoggerFactory 初始化方法
        /// </summary>
        Action<ILoggerFactory> InitLoggerFactoryAction { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class LogServiceCoExtensions {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="co"></param>
        /// <param name="action"></param>
        public static void SetInitLoggerFactoryAction(this ILogServiceCo co, Action<ILoggerFactory> action) {
            co.InitLoggerFactoryAction = action;
        }
    }
}