namespace SmartCookbook.Models
{
    public class Ingredient
    {
        // properties

        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; } = 0;
        public string? Unit { get; set; }

        // nutritional information, per 100g
        public int Calories { get; set; } = 0;
        public double Fat { get; set; } = 0;
        public double Carbs { get; set; } = 0;
        public double Protein { get; set; } = 0;

        // constructor

        public Ingredient(string name, double quantity, string? unit, int calories, double fat, double carbs, double protein)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            Fat = fat;
            Carbs = carbs;
            Protein = protein;
        }

        public Ingredient()
        {
            Name = "";
            Unit = "";
        }
    }
}
