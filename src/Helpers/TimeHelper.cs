using System;

namespace Cinling.Lib.Helpers {

    /// <summary>
    /// 时间工具
    /// </summary>
    public static class TimeHelper {

        /// <summary>
        /// 获取今天的日期
        /// </summary>
        /// <returns></returns>
        public static string date() => date(DateTime.Now);

        /// <summary>
        /// 将 DateTime 转为日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string date(DateTime dateTime) {
            return dateTime.ToString("yyyy-MM-dd hh:mm:ss");
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        /// <returns></returns>
        public static string datetime() => datetime(DateTime.Now);

        /// <summary>
        /// 将 Datetime 转为字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string datetime(DateTime dateTime) {
            return dateTime.ToString("yyyy-MM-dd");
        }
    }
}