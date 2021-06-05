namespace Cinling.Lib.Exceptions {
    
    /// <summary>
    /// 
    /// </summary>
    public class ApiException : BaseLibException {
        public ApiException() : base() {
            
        }

        public ApiException(string message) : base(message) {
            
        }
    }
}