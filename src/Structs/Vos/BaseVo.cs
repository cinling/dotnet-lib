using System;
using System.Collections.Generic;
using System.Text.Json;
using Cinling.Lib.Interfaces;

namespace Cinling.Lib.Structs.Vos {
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseVo : IDisposable, IToDictionary {

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
        /// <returns></returns>
        public Dictionary<string, object> ToDictionary() {
            return this.__ToDictionary();
        }
    }
}