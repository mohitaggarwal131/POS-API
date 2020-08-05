using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Utility;
using Utility.CustomException;

namespace POSApi.GlobalErrorHandling
{
    public class ExceptionMiddleware
    {
        #region Private Fields

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        #endregion

        #region Public Methods

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="next">RequestDelegate instance</param>
        /// <param name="logger">logger instance ExceptionMiddleware</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// handle the global exception
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// If an exception occur, log the exception and send a error response.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception.Message);
            _logger.LogError(exception.GetType().ToString());
            _logger.LogError(exception.StackTrace);

            context.Response.ContentType = Constants.ApplicationJson;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorModel()
            {
                StatusCode = context.Response.StatusCode,
                ErrorCause = Constants.InternalServerError
            }.ToString());
        }
        #endregion
    }
}
