using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Models
{
    public class Measure : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Symbol { get; set; }
    }
}