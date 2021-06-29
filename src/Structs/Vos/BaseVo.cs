using System;
using System.Collections.Generic;
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
            return this.__ToJson();
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
    }
}