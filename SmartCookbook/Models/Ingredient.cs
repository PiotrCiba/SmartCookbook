namespace SmartCookbook.Models
{
    public class Ingredient
    {
        // properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Unit { get; set; }

        // nutritional information, per 100g
        public int? Calories { get; set; } = 0;
        public double? Fat { get; set; } = 0;
        public double? Carbs { get; set; } = 0;
        public double? Protein { get; set; } = 0;

        // constructor

        public Ingredient(string name, string? unit, int? calories, double? fat, double? carbs, double? protein)
        {
            Name = name;
            Unit = unit ?? "";
            Calories = calories ?? 0;
            Fat = fat ?? 0;
            Carbs = carbs ?? 0;
            Protein = protein ?? 0;
        }

        public Ingredient()
        {
            Name = "";
            Unit = "";
        }
    }
}
