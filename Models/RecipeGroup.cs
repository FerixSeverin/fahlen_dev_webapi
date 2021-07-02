using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Models
{
    public class RecipeGroup : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public Recipe Recipe { get; set; }
    }
}