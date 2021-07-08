using System;
using Cinling.Lib.Enums;

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
        public CanDictionary CanDictionary { get; }

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
        /// <param name="canDictionary"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CanDictionaryPropertyAttribute(CanDictionary canDictionary) {
            CanDictionary = canDictionary;
        }
    }
}