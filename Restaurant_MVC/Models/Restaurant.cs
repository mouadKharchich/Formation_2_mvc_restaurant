using System.ComponentModel.DataAnnotations;

namespace Restaurant_MVC.Models
{
    public class Restaurant
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "nom de restaurant est obligatoire")]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string Description { get; set; }

    }
}
