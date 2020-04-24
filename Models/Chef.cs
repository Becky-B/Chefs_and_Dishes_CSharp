using System;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}
        [Required(ErrorMessage="First name is required")]
        public string FirstName {get; set; }
        [Required(ErrorMessage="Last name is required")]
        public string LastName {get; set;}
        [Required(ErrorMessage="Date of Birth is required")]
        public DateTime BDay {get; set; }
        [NotMapped]
        public int Age 
            {
                get
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - BDay.Year;
                    if(BDay.Date > today.AddYears(-age)) age--;
                    return age;
                }
            }    
            
        public List<Dish> CreatedDishs {get; set; }
        public DateTime CreatedAt {get; set; } = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }
}