using System;
using System.Net;

namespace Utility.CustomException
{
    public class CustomException : Exception
    {
        /// <summary>
        /// get or set error detail model
        /// </summary>
        public ErrorModel ErrorDetails { get; set; }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="statusCode">HttpStatusCode</param>
        /// <param name="message">message</param>
        public CustomException(HttpStatusCode statusCode, string message) : base(message)
        {
            ErrorDetails = new ErrorModel()
            {
                StatusCode = (int)statusCode,
                ErrorCause = message
            };
        }
    }
}
