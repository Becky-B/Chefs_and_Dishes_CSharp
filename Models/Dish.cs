using System;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get; set; }
        [Required(ErrorMessage="Dish Name is Required")]
        public string DishName {get; set; }
        [Required(ErrorMessage="Number of Caloires is Required")]
        [Range(1,Double.PositiveInfinity, ErrorMessage="Calories Must Be More Than 0")]
        public int Calories {get; set; }
        [Required(ErrorMessage="Tastiness Rank is Required")]
        public int Tastiness {get; set; }
        public string Description {get; set;}
        
        [Display(Name = "Chef")]
        [Required(ErrorMessage="Chef of Dish is Required")]
        public int ChefId {get; set; }
        public Chef Creator {get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set; } = DateTime.Now;
    }
}