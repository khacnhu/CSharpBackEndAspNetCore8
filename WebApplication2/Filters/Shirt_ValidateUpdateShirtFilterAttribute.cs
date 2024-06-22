using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication2.Models;

namespace WebApplication2.Filters
{
    public class Shirt_ValidateUpdateShirtFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (id.HasValue && shirt != null && id != shirt.ShirtId )
            {
                context.ModelState.AddModelError("SHIRT", "Shirt id is not the same id in url");
                var problemdetials = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemdetials);

            };


        }



    }
}
