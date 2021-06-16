using System.IO;
using Microsoft.Extensions.Configuration;

namespace Cinling.Lib.FileLogger {
    
    public class FileLoggerConfiguration {
        /// <summary>
        /// 
        /// </summary>
        private readonly IConfiguration configuration;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public FileLoggerConfiguration(IConfiguration configuration) {
            this.configuration = configuration;
        }
    }
}