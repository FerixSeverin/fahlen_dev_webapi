using System.Collections.Generic;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Dtos
{
    public class RecipeGroupReadWithIngredientRead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientReadWithMeasure> Ingredients { get; set; }
    }
}