using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication2.Models.Repository;

namespace WebApplication2.Filters
{
    public class Shirt_ValidateShirtFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirtId = context.ActionArguments["id"] as int?;


            if (shirtId.HasValue)
            {
                if (shirtId.Value < 0)
                {
                    context.ModelState.AddModelError("ShirtId", "ShirtId is ininvalid");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                } else if (!ShirtRepository.ShirtExisted(shirtId.Value))
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt does not existed");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);

                }
             
            }    



        }


    }
}
