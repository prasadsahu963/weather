using System;
using System.Text.Json.Serialization;

namespace Weather.ServiceLayer.ErrorCodes
{
    public class ErrorLoggingDescriptor
    {
        [JsonIgnore]
        public Exception Exception { get; protected set; }

        public string ErrorMessage { get; }

        /// <summary>
        /// Initializes a new instance of the Error Logging Descriptor.
        /// </summary>
        /// <param name="messageTemplate"></param>
        /// <param name="values"></param>
        public ErrorLoggingDescriptor(string messageTemplate, params object[] values)
            : this(null, messageTemplate, values)
        {

        }

        public ErrorLoggingDescriptor(Exception ex, string messageTemplate, params object[] values)
        {
            Exception = ex;
            ErrorMessage = string.Format(messageTemplate, values);
        }

        public ErrorLoggingDescriptor(string message, Exception ex = null)
        {
            Exception = ex;
            ErrorMessage = message;
        }
    }
}
