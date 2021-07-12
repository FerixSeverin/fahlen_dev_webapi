namespace fahlen_dev_webapi.Dtos
{
    public class RecipeRead
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Favorite { get; set; } = false;

        public string Description { get; set; }
    }
}