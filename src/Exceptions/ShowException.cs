namespace Cinling.Lib.Exceptions {
    /// <summary>
    /// The exception that can show the message to the user 
    /// </summary>
    public class ShowException : BaseLibException {

        /// <summary>
        /// Throw with message
        /// </summary>
        /// <param name="message"></param>
        public ShowException(string message) : base(message) {
            
        }
    }
}