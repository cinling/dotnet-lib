using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace Cinling.Lib.FileLogger {
    /// <summary>
    /// 
    /// </summary>
    public class FileLoggerWriter : IDisposable {

        /// <summary>
        /// 
        /// </summary>
        private readonly ConcurrentQueue<string> logQueue = new();
        /// <summary>
        /// 
        /// </summary>
        private readonly FileLoggerOptions options;
        /// <summary>
        /// 
        /// </summary>
        private readonly Mutex writeMutex = new ();

        /// <summary>
        /// 
        /// </summary>
        public FileLoggerWriter(FileLoggerOptions options) {
            this.options = options;
            if (!Directory.Exists(this.options.SavePath)) {
                Directory.CreateDirectory(this.options.SavePath);
            }
        }

        /// <summary>
        /// 写入文本
        /// </summary>
        /// <param name="content"></param>
        public void Write(string content) {
            logQueue.Enqueue(content);
            BeginWriteQueue();
        }

        public void BeginWriteQueue() {
            writeMutex.WaitOne();
            const int maxWriteNum = 1000;
            var writer = File.AppendText(this.options.SavePath + "/app.log");
            for (var i = 0; i < maxWriteNum; i++) {
                if (!logQueue.TryDequeue(out var writeContent)) {
                    break;
                }
                writer.Write(writeContent);
                writer.Flush();
            }
            writer.Close();
            writer.Dispose();
            writeMutex.ReleaseMutex();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            BeginWriteQueue();
            writeMutex?.Dispose();
        }
    }
}