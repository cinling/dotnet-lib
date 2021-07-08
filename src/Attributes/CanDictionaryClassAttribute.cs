using System;
using System.Reflection;
using Cinling.Lib.Enums;
using Cinling.Lib.Extensions;

namespace Cinling.Lib.Attributes {

    /// <summary>
    /// ICanDictionary 的属性。用于字段在 ToDictionary() 和 SetByDictionary() 的时候转换字段名
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class CanDictionaryClassAttribute : Attribute {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop"></param>
        /// <returns></returns>
        public string ParseName(PropertyInfo prop) {
            string name;
            switch (ECanDictionary) {
                case CanDictionary.Underscore:
                    name = prop.Name.ToUnderscore();
                    break;
                case CanDictionary.UpperCamelCase:
                    name = prop.Name.ToUpperCamelCase();
                    break;
                case CanDictionary.LowerCamelCase:
                    name = prop.Name.ToLowerCamelCase();
                    break;;
                default:
                    throw new ArgumentOutOfRangeException(nameof(CanDictionary) + ":" + ECanDictionary);
            }
            return name;
        }
    }
}