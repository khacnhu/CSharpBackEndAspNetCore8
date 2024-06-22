using Microsoft.AspNetCore.Mvc;
using WebApplication2.Filters;
using WebApplication2.Models;
using WebApplication2.Models.Repository;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("/api/{controller}")]
    public class ShirtController : ControllerBase
    {

        [HttpGet]
        public List<Shirt> GetShirts()
        {
            return ShirtRepository.ListShirts();
            }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtFilter]
        public IActionResult GetDetailShirt(int id)
        {
            return Ok(ShirtRepository.getShirtById(id));
        
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetDetailShirt), 
                new {id  = shirt.ShirtId}, shirt);
        }


        [HttpPut("{id}")]
        [Shirt_ValidateCreateShirtFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionFilter]
        public IActionResult UpdateShirt(int id,[FromBody] Shirt shirt) {
            ShirtRepository.UpdateShirt(shirt);

            return Ok("update successfully");
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtFilter]
        public IActionResult DeleteShirt(int id)
        {
            ShirtRepository.DeleteShirt(id);
            return Ok("Delete Successully");
        }

    }
}
