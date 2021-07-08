using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cinling.Lib.Extensions {
    
    public static class StringExtensions {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUnderscore(this string value) {
            return Regex.Replace(value, "([A-Z])", "_$1").ToLower().TrimStart('_');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUpperCamelCase(this string value) {
            var str = value.ToLowerCamelCase();
            return str[..1].ToUpper() + str[1..];
        }

        public static string ToLowerCamelCase(this string value) {
           return Regex.Replace(value, "_([a-z])", evaluator => evaluator.Value.ToUpper()).Replace("_", "");
        }
    }
}