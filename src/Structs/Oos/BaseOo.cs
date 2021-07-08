using System;
using System.Collections.Generic;
using Cinling.Lib.Structs.Vos;

namespace Cinling.Lib.Structs.Oos {
    public class BaseOo : BaseVo {
        /// <summary>
        /// Extended data received (property not in the object) 
        /// 接收到的扩展数据（对象中没有的属性）
        /// </summary>
        private readonly Dictionary<string, object> __extParams = new ();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        public new void SetByDictionary(IDictionary<string, object> dictionary) {
            base.SetByDictionary(dictionary);
            var type = GetType();
            foreach (var (name, value) in dictionary) {
                var prop = type.GetProperty(name);
                if (prop != null && prop.PropertyType.IsPublic) {
                    continue;
                }
                __extParams[name] = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool TryGetParam(string name, out object value) {
            if (__extParams.TryGetValue(name, out value)) {
                return true;
            }
            var prop = GetType().GetProperty(name);
            if (prop == null) return false;
            value = prop.GetValue(this);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetParam(string name) {
            if (!__extParams.TryGetValue(name, out var value)) {
                value = GetType().GetProperty(name)?.GetValue(this);
            }
            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new IDictionary<string, object> ToDictionary() {
            var dict = base.ToDictionary();
            foreach (var (key, value) in __extParams) {
                dict.TryAdd(key, value);
            }
            return dict;
        }
    }
}