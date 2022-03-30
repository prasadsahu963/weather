namespace Weather.ServiceLayer.ErrorCodes
{
    public class WeatherError
    {
        /// <summary>
        /// Gets the Error Code associated with this Error.
        /// </summary>
        public string Code { get; protected set; }

        /// <summary>
        /// Gets the Error Message to display to the users.
        /// </summary>
        public string Message { get; protected set; }

        /// <summary>
        /// Gets the Logging Descriptor associated with this error. Useful for logging purposes.
        /// </summary>
        public ErrorLoggingDescriptor LoggingDescriptor { get; }

        /// <summary>
        /// Initializes the Error item.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="loggingDescriptor"></param>
        public WeatherError(string code, string message, ErrorLoggingDescriptor loggingDescriptor = null)
        {
            if (message.Length > 70)
            {
                var messageList = message.Split('|');
                messageList[0] = messageList[0].Length > 70 ? string.Concat(messageList[0].Substring(0, 70), "...") : messageList[0];
                message = string.Concat(messageList[0].Trim(), " | ", messageList[1].Trim());
            }
            Code = code;
            Message = message;
            LoggingDescriptor = loggingDescriptor;
        }

    }
}
