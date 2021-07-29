using System.Collections.Generic;

namespace fahlen_dev_webapi.Dtos
{
    public class RecipeReadWithRecipeGroups
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Favorite { get; set; } = false;

        public string Description { get; set; }

        public List<RecipeGroupReadWithIngredientRead> RecipeGroups { get; set; }

        public List<MeasureRead> Measures { get; set; }
    }
}