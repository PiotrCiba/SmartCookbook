using System.ComponentModel.DataAnnotations;

namespace SmartCookbook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public int Author {  get; set; }
        public bool Private { get; set; }

        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required List<string> Ingredients { get; set; }
        public required List<string> Steps { get; set; }
    }
}
