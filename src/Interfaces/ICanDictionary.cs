using System;
using System.Collections;
using System.Collections.Generic;

namespace Cinling.Lib.Interfaces {

    /// <summary>
    /// 
    /// </summary>
    public interface ICanDictionary {
        /// <summary>
        /// 转为字典数据
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> ToDictionary();

        /// <summary>
        /// 使用字典数据初始化对象数据
        /// </summary>
        /// <param name="dictionary"></param>
        void SetByDictionary(IDictionary<string, object> dictionary);
    }

    /// <summary>
    /// 
    /// </summary>
    public static class CanDictionaryExtensions {

        /// <summary>
        /// implement ToDictionary()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static IDictionary<string, object> __ToDictionary(this ICanDictionary obj) {
            var type = obj.GetType();
            var dict = new Dictionary<string, object>();
            foreach (var property in type.GetProperties()) {
                var value = property.CanRead ? property.GetValue(obj, null) : null;
                value = ParseValue(value);
                dict.TryAdd(property.Name, value);
            }
            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ins"></param>
        /// <param name="dictionary"></param>
        public static void __SetByDictionary(this ICanDictionary ins, IDictionary<string, object> dictionary) {
            var type = ins.GetType();
            foreach (var property in type.GetProperties()) {
                if (dictionary.TryGetValue(property.Name, out var propValue)) {
                    var value = ParseProp(property.PropertyType, propValue);
                    property.SetValue(ins, value);
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static object ParseProp(Type propType, object propValue) {
            object value;

            if (propType.IsValueType || propType == typeof(string)) {
                value = propValue;
            }
            else if (propType.IsImplements(typeof(ICanDictionary)) && propValue is IDictionary<string, object> objDict) {
                var subObj = (ICanDictionary) propType.CreateInstance();
                subObj?.SetByDictionary(objDict);
                value = subObj;
            }
            else if (propType.IsImplements(typeof(IList)) && propValue is IList list) {
                var genericTypes = propType.GetGenericArguments();
                if (genericTypes.Length > 1) {
                    value = list;
                }
                else {
                    var subList = (IList) propType.CreateInstance();
                    var genericType = genericTypes[0];
                    if (subList != null) {
                        foreach (var item in list) {
                            var subValue = ParseProp(genericType, item);
                            subList.Add(subValue);
                        }
                    }
                    value = subList;
                }
            }
            else if (propType.IsImplements(typeof(IDictionary)) && propValue is IDictionary dict) {
                var genericTypes = propType.GetGenericArguments();
                if (genericTypes.Length != 2) {
                    value = dict;
                } 
                else {
                    var subDict = (IDictionary) propType.CreateInstance();
                    if (subDict != null) {
                        foreach (DictionaryEntry pair in dict) {
                            var subValue = ParseProp(pair.Value?.GetType(), pair.Value);
                            subDict.Add(pair.Key, subValue);
                        }
                    }
                    value = subDict;
                }
            }
            else {
                value = propValue;
            }
            return value;
        }

        /// <summary>
        /// 解析value的值
        /// </summary>
        /// <param name="originValue"></param>
        /// <returns></returns>
        private static object ParseValue(object originValue) {
            object value;
            if (originValue is ICanDictionary canDictionary) {
                value = canDictionary.ToDictionary();
            }
            else if (originValue is ICollection collection) {
                if (collection is IList list) {
                    value = new List<object>();
                    foreach (var item in list) {
                        var subValue = ParseValue(item);
                        ((IList) value).Add(subValue);
                    }
                }
                else if (collection is IDictionary dictionary) {
                    value = new Dictionary<object, object>();
                    foreach (DictionaryEntry pair in dictionary) {
                        var subValue = ParseValue(pair.Value);
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