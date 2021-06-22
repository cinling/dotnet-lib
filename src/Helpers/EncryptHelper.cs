namespace Cinling.Lib.Helpers {
    using System;
    using System.Text;

    
    /// <summary>
    /// Encryption tool
    /// 加密工具
    /// </summary>
    public static class EncryptHelper {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Sha1(string content) {
            var cleanBytes = Encoding.Default.GetBytes(content);
            var hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string Sha512(string content) {
            var cleanBytes = Encoding.Default.GetBytes(content);
            var hashedBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }
    }
}