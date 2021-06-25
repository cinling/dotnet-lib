using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Cinling.Lib.Structs.Vos {
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVo : IDisposable {

        public BaseVo() {
            OnInit();    
        }
        
        public void OnInit() {
            
        }

        public void Dispose() {
            
        }

        /// <summary>
        /// 将对象数据转为 Dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> ToDict() {
            var type = GetType();
            var dict = new Dictionary<string, object>();
            foreach (var property in type.GetProperties()) {
                var value = property.CanRead ? property.GetValue(this, null) : null;
                dict.TryAdd(property.Name, value);
            }
            return dict;
        }

        /// <summary>
        /// convert Object Values turn to Json String  
        /// </summary>
        /// <returns></returns>
        public string ToJson() {
            return JsonSerializer.Serialize(ToDict());
        }
    }
}