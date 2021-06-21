using System.IO;

namespace Cinling.Lib.FileLogger {
    public class FileLoggerOptions {
        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string SavePath = Directory.GetCurrentDirectory() + "/runtime/cin-log";
    }

    public class FileLoggerOptionsBuilder {
        
    }
}