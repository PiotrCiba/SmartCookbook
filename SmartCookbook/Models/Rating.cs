namespace SmartCookbook.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int UserId { get; set; }
        public int Value { get; set; }

        /*
        public Rating(int recipeId, int userId, int value)
        {
            RecipeId = recipeId;
            UserId = userId;
            Value = value;
        }
        */
    }
}
