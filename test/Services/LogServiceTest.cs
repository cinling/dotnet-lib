using System;
using Cinling.Lib.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace LibTest.Services {
    public class LogServiceTest {
        private readonly LogService logSrv;

        public LogServiceTest() {
            IConfiguration i = new ConfigurationBuilder().Build();
            ILoggerFactory f = new LoggerFactory();
            f.AddFileProvider(i);
            
            logSrv = new LogService(f);
        }

        [Test]
        public void logInformation() {
            logSrv.LogInformation("info");
            logSrv.LogWarning("warn");
            logSrv.LogError("error");
            
            
        }
    }
}
