using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team.SurveyApp.Exceptions;

namespace Team.SurveyApp.Api.Filters
{
    public class ExceptionSerializationFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var code = context.Exception switch
            {
                EntryNotFoundException _ => 404,
                InvalidOperationException _ => 400,
                _ => 500
            };

            context.Result = new JsonResult(new
            {
                message = context.Exception.Message,
            })
            {
                StatusCode = code
            };
        }
    }
}
