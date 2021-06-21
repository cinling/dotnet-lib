using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.FileLogger {
    
    
    [Obsolete]
    public class FileLoggerConfiguration {

        /// <summary>
        /// 
        /// </summary>
        public string SavePath {
            get {
                string path = Directory.GetCurrentDirectory() + "/runtime/cin-log";
                if (configuration.GetSection("Logging:File:SavePath").Exists()) {
                    path = configuration["Logging.File.SavePath"];
                    if (path.EndsWith("/")) {
                        path = path[..^1]; // Delete the ending "/" 
                    }
                }

                return path;
            }
        }

        public LogLevel MinLevel {
            get {
                var level = LogLevel.Trace;
                if (configuration.GetSection("Logging:LogLevel:Default").Exists()) {
                    switch (configuration["Logging:LogLevel:Default"].ToLower()) {
                        case "trace":
                            level = LogLevel.Trace;
                            break;
                        case "debug":
                            level = LogLevel.Debug;
                            break;
                        case "information":
                            level = LogLevel.Information;
                            break;
                        case "warning":
                            level = LogLevel.Warning;
                            break;
                        case "error":
                            level = LogLevel.Error;
                            break;
                        case "critical":
                            level = LogLevel.Critical;
                            break;
                        case "none":
                            level = LogLevel.None;
                            break;
                    }
                }
                return level;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public FileLoggerConfiguration(IConfiguration configuration) {
            this.configuration = configuration;
        }
    }
}