using System;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ChefsDishes.Models
{
    public class DishWrapper
    {
        public Dish FormModel {get; set; }

        public List<Chef> AllChefs {get; set; }
    }
}