using System;
using System.Reflection;
using Cinling.Lib.Enums;
using Cinling.Lib.Extensions;

namespace Cinling.Lib.Attributes {

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CanDictionaryPropertyAttribute : Attribute {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// 
        /// </summary>
        public CanDictionary ECanDictionary { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public CanDictionaryPropertyAttribute(string name) {
            Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eCanDictionary"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CanDictionaryPropertyAttribute(CanDictionary eCanDictionary) {
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
                    name = Name;
                    break;
            }
            return name;
        }
    }
}