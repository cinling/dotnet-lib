using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Cinling.Lib.Interfaces {
    
    /// <summary>
    /// 日志配置接口
    /// </summary>
    public interface ILogServiceCo {
        IServiceCollection Services { get; }

        bool IsFileLogger { get; }

        void DisableFileLogger();
    }
}