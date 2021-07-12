using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Dtos
{
    public class IngredientRead
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public uint Amount { get; set; } = 0;

        public Measure Measure { get; set; }
    }
}