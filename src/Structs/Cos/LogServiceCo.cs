using Cinling.Lib.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cinling.Lib.Structs.Cos {
    
    /// <summary>
    /// 
    /// </summary>
    public class LogServiceCo : BaseCo, ILogServiceCo {
        /// <summary>
        /// 
        /// </summary>
        public IServiceCollection Services { get; }
        
        public bool IsFileLogger { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public LogServiceCo(IServiceCollection services) {
            Services = services;
            LoadDefaultConfig();
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void DisableFileLogger() {
            IsFileLogger = false;
        }

        /// <summary>
        /// 加载默认配置
        /// </summary>
        private void LoadDefaultConfig() {
            IsFileLogger = true;
        }
    }
}