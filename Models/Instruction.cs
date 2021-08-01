using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Models
{
  public class Instruction : BaseEntity
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int Order { get; set; }

    [MaxLength(2000)]
    public string Text { get; set; }

    [Required]
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
  }
}