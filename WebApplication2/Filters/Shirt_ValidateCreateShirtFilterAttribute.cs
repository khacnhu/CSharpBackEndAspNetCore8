using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication2.Models;
using WebApplication2.Models.Repository;

namespace WebApplication2.Filters
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);


            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (shirt == null)
            {
                context.ModelState.AddModelError("SHIRT", "Shirt object is null");
                var problemdetials = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemdetials);
            } else
            {
                var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand,
                        shirt.Gender, shirt.Color, shirt.Size
                    );
                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("SHIRT", "Shirt object is existed");
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
