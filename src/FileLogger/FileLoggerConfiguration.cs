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
        public string SavePath => configuration["Logging.File.SavePath"];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public FileLoggerConfiguration(IConfiguration configuration) {
            this.configuration = configuration;
        }
    }
}