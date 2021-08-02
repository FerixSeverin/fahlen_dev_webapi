using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Dtos
{
  public class InstructionCreate
  {
    [Required]
    public int Order { get; set; }

    [MaxLength(2000)]
    public string Text { get; set; }

    [Required]
    public int RecipeId { get; set; }
  }
}