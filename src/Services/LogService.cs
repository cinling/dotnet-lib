﻿#nullable enable

using System;
using Cinling.Lib.Interfaces;
using Cinling.Lib.Structs.Cos;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.Services {

    public interface ILogService : ILogger<LogService> {
        
    }
    
    /// <summary>
    /// 日志服务
    /// </summary>
    public class LogService : ILogService {

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogServiceCo co;
        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<LogService> logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="co"></param>
        /// <param name="loggerFactory"></param>
        public LogService(ILogServiceCo co, ILoggerFactory loggerFactory) {
            this.co = co;
            this.co.InitLoggerFactoryAction(loggerFactory);
            logger = loggerFactory.CreateLogger<LogService>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="eventId"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        /// <param name="formatter"></param>
        /// <typeparam name="TState"></typeparam>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) {
            logger.Log(logLevel, eventId, state, exception, formatter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel) {
            return logger.IsEnabled(logLevel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <typeparam name="TState"></typeparam>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state) {
            return logger.BeginScope(state);
        }
    }
}