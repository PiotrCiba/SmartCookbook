using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCookbook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Author {  get; set; }
        public bool Private { get; set; }

        [Display(Name = "Upload Date")]
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }
        public required string Name { get; set; }

        [Display(Name = "Image Path")]
        public string? ImagePath { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<IngredientInstance>? Ingredients { get; set; }
        public List<CookingStep>? Steps { get; set; }
        public List<Rating>? Ratings { get; set; } = new List<Rating>();
        public List<Comment>? Comments { get; set; } = new List<Comment>();

        //constructor
        public Recipe(string author, bool isPrivate, DateTime uploadDate, string name, string imagePath, string description, List<IngredientInstance>? ingredients, List<CookingStep>? steps)
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
            Author = "";
            Private = false;
            UploadDate = DateTime.Now;
            Name = "";
            ImagePath = "";
            Description = "";
            Ingredients = new List<IngredientInstance>();
            Steps = new List<CookingStep>();
        }

    }
}
