
using Cinling.Lib.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace LibTest.Services {
    public class LogServiceTest {
        // private readonly TestServer server;
        private readonly ILogService logSrv;
        
        public LogServiceTest() {
            var server = new TestServer(new WebHostBuilder().UseStartup<StartUp>());
            logSrv = server.Host.Services.GetService<ILogService>();
        }

        [Test]
        public void LogInformation() {
            logSrv.LogInformation("info");
            logSrv.LogWarning("warn");
            logSrv.LogError("error");
            using (logSrv.BeginScope("abc")) {
                logSrv.LogInformation("info");
            }
            logSrv.LogError("error");
        }
    }
}
