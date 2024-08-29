namespace SmartCookbook.Models
{
    public class CookingStep
    {
        //properties
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; } = 0;
        public string? Unit { get; set; } = "";

        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        //constructor
        /*
        public CookingStep(string description, int duration, string unit)
        {
            Description = description;
            Duration = duration;
            Unit = unit;
        }
        */
    }
}
