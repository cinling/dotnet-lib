using System;
using System.Text.Json;

namespace Cinling.Lib.Utils {
    
    /// <summary>
    /// JSON encode and decode tools
    /// JSON 序列化、反序列化工具
    /// </summary>
    [Obsolete]
    public static class JsonUtil {
        /// <summary>
        /// JSON encode
        /// JSON 序列化
        /// </summary>
        /// <returns></returns>
        public static string encode(object value) {
            return JsonSerializer.Serialize(value);
        }       
    }
}