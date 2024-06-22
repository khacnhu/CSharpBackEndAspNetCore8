using System.ComponentModel.DataAnnotations;
using WebApplication2.Models.Validations;

namespace WebApplication2.Models
{
    public class Shirt
    {

        public int ShirtId { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Color { get; set; }

        [Shirt_EnumCorrectSizingAtribute]
        public int? Size { get; set; }
       
        [Required]        
        public string? Gender { get; set; }

        public double Price { get; set; }

    }
}
