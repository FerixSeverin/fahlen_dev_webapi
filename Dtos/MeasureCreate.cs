using System.ComponentModel.DataAnnotations;

namespace fahlen_dev_webapi.Dtos
{
    public class MeasureCreate
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Symbol { get; set; }
    }
}