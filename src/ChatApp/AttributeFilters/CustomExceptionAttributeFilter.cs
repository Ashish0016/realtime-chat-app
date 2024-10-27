using Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ChatApp.AttributeFilters
{
    public class CustomExceptionAttributeFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "appliaction/json";

            switch (context.Exception)
            {
                case BadRequestException badRequest:
                    context.HttpContext.Response.StatusCode = badRequest.StatusCode;
                    context.Result = new JsonResult(new
                    {
                        message = badRequest.Message
                    });
                    break;

                case NotFoundException NotFound:
                    context.HttpContext.Response.StatusCode = NotFound.StatusCode;
                    context.Result = new JsonResult(new
                    {
                        message = NotFound.Message
                    });
                    break;

                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Result = new JsonResult(new
                    {
                        message = "An unexpected error occoured."
                    });
                    break;
            }
        }
    }
}
