using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeHolder.Models
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name ="RecipeName")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        [Display(Name="Category of Food")]
        public string Category { get; set; }
        [Required]
        [Range (0,1000)]
        public int Servings { get; set; }
    }
}
