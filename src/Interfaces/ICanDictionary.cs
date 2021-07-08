using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Cinling.Lib.Attributes;
using Cinling.Lib.Extensions;

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
        /// <param name="canDictionary"></param>
        /// <returns></returns>
        public static IDictionary<string, object> __ToDictionary(this ICanDictionary canDictionary) {
            var type = canDictionary.GetType();
            var dict = new Dictionary<string, object>();
            var convertDict = canDictionary.GetConvertDictionary();
            foreach (var prop in type.GetProperties()) {
                if (!convertDict.TryGetValue(prop.Name, out var key)) {
                    key = prop.Name;
                }
                var value = prop.CanRead ? prop.GetValue(canDictionary, null) : null;
                value = ParseValue(value);
                dict.TryAdd(key, value);
            }
            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canDictionary"></param>
        /// <param name="dictionary"></param>
        public static void __SetByDictionary(this ICanDictionary canDictionary, IDictionary<string, object> dictionary) {
            var type = canDictionary.GetType();
            var convertDict = canDictionary.GetConvertDictionary();
            foreach (var prop in type.GetProperties()) {
                if (!convertDict.TryGetValue(prop.Name, out var keyName)) {
                    keyName = prop.Name;
                }
                if (dictionary.TryGetValue(keyName, out var propValue) || dictionary.TryGetValue(prop.Name, out propValue)) {
                    var value = ParseProp(prop.PropertyType, propValue);
                    prop.SetValue(canDictionary, value);
                }
            }
        }

        /// <summary>
        /// 获取转换字段名字典。类属性 => 字典键名
        /// </summary>
        /// <param name="canDictionary"></param>
        public static Dictionary<string, string> GetConvertDictionary(this ICanDictionary canDictionary) {
            var type = canDictionary.GetType();
            var classAttribute = type.GetCustomAttribute<CanDictionaryClassAttribute>();
            var dict = new Dictionary<string, string>();

            if (classAttribute != null) {
                foreach (var prop in type.GetProperties()) {
                    var propAttribute = prop.PropertyType.GetCustomAttribute<CanDictionaryPropertyAttribute>();
                    dict[prop.Name] = propAttribute != null ? propAttribute.ParseName(prop) : classAttribute.ParseName(prop);
                }
            }
            else {
                foreach (var prop in type.GetProperties()) {
                    var propAttribute = prop.PropertyType.GetCustomAttribute<CanDictionaryPropertyAttribute>();
                    dict[prop.Name] = propAttribute != null ? propAttribute.ParseName(prop) : prop.Name;
                }
            }
            return dict;
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