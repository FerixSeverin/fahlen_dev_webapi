using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Dtos
{
    public class RecipeGroupCreate
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public int RecipeId { get; set; }
    }
}