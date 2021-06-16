using System;

namespace Cinling.Lib.Exceptions {

    /// <summary>
    /// Base Exception form Cinling.Lib
    /// </summary>
    public class BaseLibException : Exception {
        
        public BaseLibException() {
        }
        
        public BaseLibException(string message) : base(message) {
        }
    }
}