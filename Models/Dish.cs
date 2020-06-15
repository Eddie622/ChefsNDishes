using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        public int ChefId { get; set; }

        public Chef Creator { get; set; }

        [Required]
        [MinLength(2)]
        public string DishName { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        [Range(1, 5)]
        public int Tastiness { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}