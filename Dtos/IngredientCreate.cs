using System.ComponentModel.DataAnnotations;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Dtos
{
    public class IngredientCreate
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public uint Amount { get; set; } = 0;

        [Required]
        public int MeasureId { get; set; }

        [Required]
        public int RecipeGroupId { get; set; }
    }
}