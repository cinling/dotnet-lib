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
            var str = ToCamelCase(value);
            return str[..1].ToUpper() + str[1..];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToLowerCamelCase(this string value) {
            var str = ToCamelCase(value);
            return str[..1].ToLower() + str[1..];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string ToCamelCase(string value) {
            return Regex.Replace(value, "_([a-z])", evaluator => evaluator.Value.ToUpper()).Replace("_", "");
        }
    }
}