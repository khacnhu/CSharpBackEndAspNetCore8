using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication2.Models.Repository;

namespace WebApplication2.Filters
{
    public class Shirt_HandleUpdateExceptionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirtId = context.RouteData.Values["id"] as string;
        
            if (int.TryParse(shirtId, out var shirtIdNew))
            {
                if(!ShirtRepository.ShirtExisted(shirtIdNew)) 
                {
                    context.ModelState.AddModelError("SHIRT", "Shirt is not existed Huhuhu");
                    var problemdetials = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemdetials);
                }
            }
        }

    }
}
