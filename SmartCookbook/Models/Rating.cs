namespace SmartCookbook.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int RatingValue { get; set; }
        public string Comment { get; set; }

    }
}
