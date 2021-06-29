
using System.Text.Json;

namespace Cinling.Lib.Interfaces {
    /// <summary>
    /// JSON 序列化接口
    /// </summary>
    public interface IJsonSerializable {

        /// <summary>
        /// 将数据转为 json 字符串
        /// </summary>
        /// <returns></returns>
        public string ToJson();

        /// <summary>
        /// 使用 json 字符串加载数据
        /// </summary>
        /// <param name="json"></param>
        public void SetByJson(string json);
    }

    public static class JsonSerializableExtensions {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializable"></param>
        /// <returns></returns>
        public static string __ToJson(this IJsonSerializable serializable) {
            return JsonSerializer.Serialize(serializable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializable"></param>
        /// <param name="json"></param>
        public static void __SetByJson(this IJsonSerializable serializable, string json) {
            JsonSerializer.Deserialize<object>(json);
        }
    }
}