using System;
using Cinling.Lib.Services;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace LibTest.Services {
    public class LogServiceTest {
        private readonly LogService logSrv;

        public LogServiceTest() {
            logSrv = new LogService();
        }

        [Test]
        public void logInformation() {
            logSrv.LogInformation("info");
            logSrv.LogWarning("warn");
            logSrv.LogError("error");
            
            
        }
    }
}
