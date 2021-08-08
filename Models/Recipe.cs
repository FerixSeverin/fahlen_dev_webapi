using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace fahlen_dev_webapi.Models
{
    public class Recipe : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        public bool Favorite { get; set; } = false;

        [MaxLength(1000)]
        public string Description { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public List<RecipeGroup> RecipeGroups { get; set; }
        public List<Instruction> Instructions { get; set; }
    }
}