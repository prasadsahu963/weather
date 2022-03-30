using System;

namespace Weather.ServiceLayer.ErrorCodes
{
    public class GenericErrorMessage : WeatherError
    {
        public GenericErrorMessage(string errorMessage, string errorCode, Exception ex = null)
            : base(errorCode, errorMessage,
                new ErrorLoggingDescriptor(ex, $"{errorMessage}"))
        {

        }
    }
}