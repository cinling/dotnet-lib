using System;
using System.Reflection;
using Cinling.Lib.Enums;
using Cinling.Lib.Extensions;
using Cinling.Lib.Interfaces;

namespace Cinling.Lib.Attributes {

    /// <summary>
    /// ICanDictionary 的属性。用于字段在 ToDictionary() 和 SetByDictionary() 的时候转换字段名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CanDictionaryClassAttribute : Attribute, ICanDictionaryAttribute {
        /// <summary>
        /// 
        /// </summary>
        public CanDictionary ECanDictionary { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eCanDictionary"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CanDictionaryClassAttribute(CanDictionary eCanDictionary) {
            ECanDictionary = eCanDictionary;
        }
    }
}