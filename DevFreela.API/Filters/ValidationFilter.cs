﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace DevFreela.API.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var messages = context.ModelState
                   .SelectMany(m => m.Value.Errors)
                   .Select(m => m.ErrorMessage)
                   .ToList();

                context.Result = new BadRequestObjectResult(messages);
            }
        }
    }
}
