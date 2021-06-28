using System.Collections;
using System.Collections.Generic;

namespace Cinling.Lib.Interfaces {

    /// <summary>
    /// 
    /// </summary>
    public interface IToDictionary {
        Dictionary<string, object> ToDictionary();
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ToDictionaryExtensions {

        /// <summary>
        /// implement ToDictionary()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, object> __ToDictionary(this IToDictionary obj) {
            var type = obj.GetType();
            var dict = new Dictionary<string, object>();
            foreach (var property in type.GetProperties()) {
                var value = property.CanRead ? property.GetValue(obj, null) : null;
                value = Implement_ToDictionary_ParseValue(value);
                dict.TryAdd(property.Name, value);
            }
            return dict;
        }

        /// <summary>
        /// 解析value的值
        /// </summary>
        /// <param name="originValue"></param>
        /// <returns></returns>
        private static object Implement_ToDictionary_ParseValue(object originValue) {
            object value;
            if (originValue is IToDictionary toDictionary) {
                value = toDictionary.ToDictionary();
            }
            else if (originValue is ICollection collection) {
                if (collection is IList list) {
                    value = new List<object>();
                    foreach (var item in list) {
                        var subValue = Implement_ToDictionary_ParseValue(item);
                        ((IList) value).Add(subValue);
                    }
                }
                else if (collection is IDictionary dictionary) {
                    value = new Dictionary<object, object>();
                    foreach (DictionaryEntry pair in dictionary) {
                        var subValue = Implement_ToDictionary_ParseValue(pair.Value);
                        ((IDictionary) value).Add(pair.Key, subValue);
                    }
                }
                else {
                    value = collection;
                }
            }
            else {
                value = originValue;
            }

            return value;
        }
    }
}