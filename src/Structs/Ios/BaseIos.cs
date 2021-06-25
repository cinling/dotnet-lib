using System.Collections.Generic;
using Cinling.Lib.Structs.Vos;

namespace Cinling.Lib.Structs.Ios {
    
    /// <summary>
    /// Basic input parameter object. Generally used for interface request and protocol data transmission
    /// 基础输入参数对象。一般用于接口请求、协议数据发送
    /// </summary>
    public class BaseIos : BaseVo {
        private readonly Dictionary<string, object> extParams = new ();

        /// <summary>
        /// 设置扩展参数
        /// </summary>
        /// <param name="params"></param>
        public void SetExtParams(Dictionary<string, object> @params) {
            extParams.Clear();
            foreach (var param in @params) {
                AddExtParams(param.Key, param.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddExtParams(string key, object value) {
            return extParams.TryAdd(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new Dictionary<string, object> ToDict() {
            var dict = base.ToDict();
            foreach (var pair in this.extParams) {
                dict.TryAdd(pair.Key, pair.Value);
            }
            return dict;
        }
    }
}