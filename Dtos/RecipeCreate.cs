using System.ComponentModel.DataAnnotations;
using fahlen_dev_webapi.Models;

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

        [Required]
        public int AccountId { get; set; }
    }
}