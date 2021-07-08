using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Cinling.Lib.Extensions;

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
        /// <param name="json"></param>
        public static void __SetByJson(this IJsonSerializable serializable, string json) {
            if (serializable is ICanDictionary canDictionary) {
                var dict = ParseJson(serializable.GetType(), json);
                if (dict != null) {
                    canDictionary.SetByDictionary(dict);
                }
            }
            else {
                JsonSerializer.Deserialize(json, serializable.GetType());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        private static Dictionary<string, object> ParseJson(Type type, string json) 
            => ParseJson(type, JsonSerializer.Deserialize<Dictionary<string, object>>(json));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static Dictionary<string, object> ParseJson(Type type, Dictionary<string, object> dict) {
            if (dict == null) {
                return null;
            }
            foreach (var (key, o) in dict) {
                var prop = type.GetProperty(key);
                if (prop == null) {
                    continue;
                }
                if (o is not JsonElement element) continue;

                var value = ParseElement(prop.PropertyType, element);
                dict[key] = value;
            }
            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="element"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        private static object ParseElement(Type type, JsonElement element) {
            object value = null;
            switch (element.ValueKind) {
                case JsonValueKind.Number when type.IsValueType: {
                    value = ParseNumber(type, element);
                    break;
                }
                case JsonValueKind.String when type == typeof(string): {
                    value = element.GetString();
                    break;
                }
                case JsonValueKind.True:
                case JsonValueKind.False: {
                    if (type == typeof(bool)) {
                        value = element.GetBoolean();
                    }
                    break;
                }
                case JsonValueKind.Array when type.IsImplements<IList>(): {
                    value = ParseList(type, element);
                    break;
                }
                case JsonValueKind.Object when type.IsImplements<IDictionary>(): {
                    value = ParseDictionary(type, element);
                    break;
                }
                case JsonValueKind.Undefined:
                    break;
                case JsonValueKind.Null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private static object ParseNumber(Type type, JsonElement element) {
            object number = 0;

            if (type == typeof(int) && element.TryGetInt32(out var int32)) {
                number = int32;
            } else if (type == typeof(float) && element.TryGetSingle(out var floatSingle)) {
                number = floatSingle;
            } else if (type == typeof(long) && element.TryGetInt64(out var int64)) {
                number = int64;
            } else if (type == typeof(double) && element.TryGetDouble(out var floatDouble)) {
                number = floatDouble;
            } else if (type == typeof(short) && element.TryGetInt16(out var int16)) {
                number = int16;
            } else if (type == typeof(byte) && element.TryGetByte(out var int8)) {
                number = int8;
            } else if (type == typeof(uint) && element.TryGetUInt32(out var uint32)) {
                number = uint32;
            } else if (type == typeof(ushort) && element.TryGetUInt16(out var uint16)) {
                number = uint16;
            } else if (type == typeof(ulong) && element.TryGetUInt64(out var uint64)) {
                number = uint64;
            } else if (type == typeof(sbyte) && element.TryGetSByte(out var sbyteNum)) {
                number = sbyteNum;
            } else if (type == typeof(decimal) && element.TryGetDecimal(out var decimalNum)) {
                number = decimalNum;
            }
            return number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private static IList ParseList(Type type, JsonElement element) {
            var list = type.CreateInstance<IList>();
            var subTypes = type.GetGenericArguments();
            if (subTypes.Length != 1) {
                return null;
            }
            var subType = subTypes[0];
            
            foreach (var value in element.EnumerateArray().Select(subElement => ParseElement(subType, subElement))) {
                list.Add(value);
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private static IDictionary ParseDictionary(Type type, JsonElement element) {
            var dict = type.CreateInstance<IDictionary>();            
            var subTypes = type.GetGenericArguments();
            if (subTypes.Length != 2) {
                return null;
            }
            var valueType = subTypes[1];
            foreach (var pair in element.EnumerateObject()) {
                var value = ParseElement(valueType, pair.Value);
                dict.Add(pair.Name, value);
            }
            return dict;
        }
    }
}