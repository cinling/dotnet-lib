using System;
using System.Reflection;
using Cinling.Lib.Enums;
using Cinling.Lib.Extensions;
using Cinling.Lib.Interfaces;

namespace Cinling.Lib.Attributes {

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CanDictionaryPropertyAttribute : Attribute, ICanDictionaryAttribute {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; } = "";
        
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

        public string ParseName(PropertyInfo prop) => this.ParseName(prop, Name);
    }
}