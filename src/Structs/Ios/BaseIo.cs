using System.Collections.Generic;
using Cinling.Lib.Structs.Vos;

namespace Cinling.Lib.Structs.Ios {
    
    /// <summary>
    /// Basic input parameter object. Generally used for interface request and protocol data transmission
    /// 基础输入参数对象。一般用于接口请求、协议数据发送
    /// </summary>
    public class BaseIo : BaseVo {
        /// <summary>
        /// Extended data to be sent 
        /// 需要发送的扩展数据
        /// </summary>
        private readonly Dictionary<string, object> __extParams = new ();

        /// <summary>
        /// 设置扩展参数
        /// </summary>
        /// <param name="params"></param>
        public void SetExtendParams(Dictionary<string, object> @params) {
            __extParams.Clear();
            foreach (var (key, value) in @params) {
                SetExtendParam(key, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public void SetExtendParam(string key, object value) {
            __extParams[key] = value;
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