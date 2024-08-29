using System.ComponentModel;

namespace SmartCookbook.Models
{
    public class Ingredient
    {
        // properties

        public int Id { get; set; }
        [DisplayName("Ingredient")]
        public string Name { get; set; }

        // nutritional information, per 100g
        [DisplayName("Calories")]
        public int? Calories { get; set; } = 0;
        [DisplayName("Protein")]
        public double? Protein { get; set; } = 0;
        [DisplayName("Fat")]
        public double? Fat { get; set; } = 0;
        [DisplayName("Carbs")]
        public double? Carbs { get; set; } = 0;
        public List<IngredientInstance> IngredientInstances { get; set; } = new List<IngredientInstance>();

        // constructor

        /*
        public Ingredient(string name, int calories = 0, double protein = 0, double fat = 0, double carbs = 0)
        {
            Name = name;
            Calories = calories;
            Protein = protein;
            Fat = fat;
            Carbs = carbs;
        }

        */
    }
}
