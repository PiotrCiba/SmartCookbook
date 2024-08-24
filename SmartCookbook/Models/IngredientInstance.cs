namespace SmartCookbook.Models
{
    public class IngredientInstance
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public IngredientInstance(Ingredient ingredient, double quantity, string unit)
        {
            Ingredient = ingredient;
            Quantity = quantity;
            Unit = unit;
        }

        public IngredientInstance()
        {
            Ingredient = new Ingredient();
            Quantity = 0;
            Unit = "";
        }
    }
}
