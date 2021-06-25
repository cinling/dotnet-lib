using System.Collections;
using System.Collections.Generic;

namespace Cinling.Lib.Interfaces {
    
    /// <summary>
    /// 
    /// </summary>
    public interface IToDictionary {
        Dictionary<string, object> ToDictionary();
    }

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
                if (value is IToDictionary toDictionary) {
                    value = toDictionary.ToDictionary();
                } else if (value is ICollection collection) {
                    value = Implement_ToDictionary_ForeachCollection(collection);
                }
                dict.TryAdd(property.Name, value);
            }
            return dict;
        }
        
        /// <summary>
        /// 循环集合，查看集合内是否有元素实现了 IToDictionary
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        private static object Implement_ToDictionary_ForeachCollection(ICollection collection) {
            object value = null;
            if (collection is IList list) {
                value = new List<object>();
                foreach (var item in list) {
                    object subValue = null;
                    if (item is IToDictionary toDictionary) {
                        subValue = toDictionary.ToDictionary();
                    } else if (item is ICollection subCollection) {
                        subValue = Implement_ToDictionary_ForeachCollection(subCollection);
                    }
                    ((IList) value).Add(subValue);
                }
            } else if (collection is IDictionary dictionary) {
                value = new Dictionary<string, object>();
                foreach (var pair in dictionary) {
                    object subValue = null;
                    ((IDictionary) value).Add(pair.subValue);
                }
            }
            return value;
        }
    }
}