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
        [DisplayName("Fat")]
        public double? Fat { get; set; } = 0;
        [DisplayName("Carbs")]
        public double? Carbs { get; set; } = 0;
        [DisplayName("Protein")]
        public double? Protein { get; set; } = 0;

        // constructor

        public Ingredient(string name, int? calories, double? fat, double? carbs, double? protein)
        {
            Name = name;
            Calories = calories ?? 0;
            Fat = fat ?? 0;
            Carbs = carbs ?? 0;
            Protein = protein ?? 0;
        }

        public Ingredient()
        {
            Name = "";
        }
    }
}
