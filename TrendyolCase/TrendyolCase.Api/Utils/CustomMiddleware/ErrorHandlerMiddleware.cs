using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TrendyolCase.Core.ApiModels;
using TrendyolCase.Core.Entities;
using TrendyolCase.Core.Interfaces;
using TrendyolCase.Core.Interfaces.Repositories;

namespace TrendyolCase.Api.Utils.CustomMiddleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private IExceptionRepository _exceptionRepository;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IExceptionRepository exceptionRepository)
        {
            try
            {
                _exceptionRepository = exceptionRepository;

                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// When there is an error in the system, it catches it with the middleware and makes the logging process.
        /// </summary>
        /// <returns>Error Message</returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ExceptionInfo exceptionInfo = new ExceptionInfo
            {
                Message = exception.Message,
                RequestPath = context.Request.Path,
                StackTrace = exception.StackTrace
            };

            _exceptionRepository.AddAsync(exceptionInfo);

            return context.Response.WriteAsync(new ExceptionInfoDto()
            {
                StatusCode = context.Response.StatusCode,
                Message = TrendyolCaseApiConstants.ResponseType.ErrorMessage
            }.ToString() ?? string.Empty);
        }
    }
}
