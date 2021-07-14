using System;
using System.Collections.Generic;
using System.Text.Json;
using Cinling.Lib.Interfaces;

namespace Cinling.Lib.Structs.Vos {
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVo : IDisposable, ICanDictionary, IJsonSerializable {

        public BaseVo() {
            OnInit();    
        }
        
        public void OnInit() {
            
        }

        public void Dispose() {
            
        }

        /// <summary>
        /// convert Object Values turn to Json String  
        /// </summary>
        /// <returns></returns>
        public string ToJson() {
            return JsonSerializer.Serialize(ToDictionary());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetByJson(string json) {
            this.__SetByJson(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, object> ToDictionary() {
            return this.__ToDictionary();
        }

        public void SetByDictionary(IDictionary<string, object> dictionary) {
            this.__SetByDictionary(dictionary);
        }
        
        

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public string ToHttpGetString() => ToHttpGetString("?");

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        [Obsolete]
        public string ToHttpGetString(string prefix) {
            var str = "";
            foreach (var (name, value) in ToDictionary()) {
                
                str += name + "=";
            }
            return prefix + str;
        }
    }
}