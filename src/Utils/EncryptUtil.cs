using System;
using System.Text;

namespace Cinling.Lib.Utils {
    
    /// <summary>
    /// Encryption tool
    /// 加密工具
    /// </summary>
    [Obsolete("Replace with Cinling.Lib.Helpers.EncryptHelper")]
    public static class EncryptUtil {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string sha1(string content) {
            byte[] cleanBytes = Encoding.Default.GetBytes(content);
            byte[] hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string sha512(string content) {
            byte[] cleanBytes = Encoding.Default.GetBytes(content);
            byte[] hashedBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}