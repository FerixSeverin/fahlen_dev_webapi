using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fahlen_dev_webapi.Models;
using Microsoft.AspNetCore.Identity;

namespace fahlen_dev_webapi.Dtos
{
    public class RecipeCreate
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public bool Favorite { get; set; } = false;

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}