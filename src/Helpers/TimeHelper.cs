using System;

namespace Cinling.Lib.Helpers {

    /// <summary>
    /// Time Helper
    /// 时间工具
    /// </summary>
    public static class TimeHelper {

        /// <summary>
        /// 获取今天的日期
        /// </summary>
        /// <returns></returns>
        public static string Date() => Date(DateTime.Now);

        /// <summary>
        /// 将 DateTime 转为日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string Date(DateTime dateTime) {
            return dateTime.ToString("yyyy-MM-dd hh:mm:ss");
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static string Datetime() => Datetime(DateTime.Now);

        /// <summary>
        /// 将 Datetime 转为字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string Datetime(DateTime dateTime) {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long UnixTimeSeconds() => UnixTimeSeconds(DateTime.Now);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long UnixTimeSeconds(DateTime dateTime) {
            return new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static long UnixTimeMilliseconds() => UnixTimeMilliseconds(DateTime.Now);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long UnixTimeMilliseconds(DateTime dateTime) {
            return new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
        }
    }
}