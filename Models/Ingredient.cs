using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Models
{
    public class Ingredient : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public uint Amount { get; set; } = 0;

        [Required]
        public int MeasureId { get; set; }
        public Measure Measure { get; set; }

        [Required]
        public int RecipeGroupId { get; set; }
        public RecipeGroup RecipeGroup { get; set; }
    }
}