namespace RoleWebApi.Security.API._Code.ExceptionHandling
{
    using System;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.IO;
    using RoleWebApi.Infrastructure.CrossCutting.Constants;
    using RoleWebApi.Infrastructure.CrossCutting.Exceptions.Domain;
    using RoleWebApi.Infrastructure.Transport.Common;

    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger<ApiExceptionFilter> _Logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _Logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            ApiError apiError = null;
            BaseResponse baseResponse = null;

            if (context.Exception is ApiException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as ApiException;
                context.Exception = null;
                apiError = new ApiError(ex.Message, Constants.TipoError.APP);
                apiError.errors = ex.Errors;

                context.HttpContext.Response.StatusCode = ex.StatusCode;

                _Logger.LogWarning($"Application thrown error: {ex.Message}", ex);
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access", Constants.TipoError.APP);
                context.HttpContext.Response.StatusCode = 401;
                _Logger.LogWarning("Unauthorized Access in Controller Filter.");
            }
            else if (context.Exception is DominioException)
            {
                var ex = context.Exception as DominioException;
                context.Exception = null;

                baseResponse = new BaseResponse();
                baseResponse.StateResponse.HasError = true;
                baseResponse.StateResponse.TipoError = Constants.TipoError.DOMINIO;
                baseResponse.StateResponse.MensajeError = ex.Message;

                context.ExceptionHandled = true;
            }
            else
            {
                // Unhandled errors
#if !DEBUG
                var msg = "An unhandled error occurred.";
                string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new ApiError(msg, Constants.TipoError.APP);
                apiError.detail = stack;

                context.HttpContext.Response.StatusCode = 500;

                string body;
                var position = context.HttpContext.Request.Body.Position;
                context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body))
                {
                    body = reader.ReadToEnd();
                    context.HttpContext.Request.Body.Seek(position, SeekOrigin.Begin);
                }

                var queryString = context.HttpContext.Request.QueryString.Value;

                // handle logging here
                //_Logger.LogError(new EventId(0), context.Exception, msg);
                //_Logger.LogError(context.Exception.GetBaseException(), "Error no manejado" + body + ", " + queryString);
                _Logger.LogError(context.Exception.GetBaseException().StackTrace, context.Exception);
            }

            // always return a JSON result
            if (baseResponse != null)
            {
                context.Result = new JsonResult(baseResponse);
            }
            else
            {
                context.Result = new JsonResult(apiError);
            }

            base.OnException(context);
        }
    }

    public class ApiActionFilter : ActionFilterAttribute
    {
        //private readonly ILogger _logger;
        private readonly IInfoRequest _infoRequest;

        public ApiActionFilter(IInfoRequest infoRequest)
        {
            //_logger = logger;
            _infoRequest = infoRequest;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //dynamic body;
            //var position = context.HttpContext.Request.Body.Position;
            //context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            //using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body))
            //{
            //    body = reader.ReadToEnd();
            //    context.HttpContext.Request.Body.Seek(position, SeekOrigin.Begin);
            //}
            // perform some business logic work
            _infoRequest.Body = context.HttpContext.Request.Body.ToString();
            _infoRequest.QueryString = context.HttpContext.Request.QueryString.ToString();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //var body = "";
            //using (StreamReader reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8))
            //{
            //    body = reader.ReadToEndAsync().Result;
            //}
            //TODO: log body content and response as well
            //_logger.LogDebug($"path: {context.HttpContext.Request.Path}");
        }
    }

    public class InfoRequest : IInfoRequest
    {
        public string Body { get; set; }
        public string QueryString { get; set; }
    }

    public interface IInfoRequest
    {
        string Body { get; set; }
        string QueryString { get; set; }
    }
}
