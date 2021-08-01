using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Models
{
  public class InstructionRead
  {
    public int Id { get; set; }

    public int Order { get; set; }

    public string Text { get; set; }
  }
}