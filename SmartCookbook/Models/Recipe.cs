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
        public string? ImagePath { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<Ingredient>? Ingredients { get; set; }
        public List<CookingStep>? Steps { get; set; }

        //constructor
        public Recipe(int author, bool isPrivate, DateTime uploadDate, string name, string imagePath, string description, List<Ingredient>? ingredients, List<CookingStep>? steps)
        {
            Author = author;
            Private = isPrivate;
            UploadDate = uploadDate;
            Name = name;
            ImagePath = imagePath;
            Description = description;
            Ingredients = ingredients;
            Steps = steps;
        }

        public Recipe()
        {
            Author = 0;
            Private = false;
            UploadDate = DateTime.Now;
            Name = "";
            ImagePath = "";
            Description = "";
            Ingredients = new List<Ingredient>();
            Steps = new List<CookingStep>();
        }

    }
}
