namespace SmartCookbook.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
        public int CommenterId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        
        /*
        public Comment(int recipeId, int author, string content, DateTime date)
        {
            RecipeId = recipeId;
            CommenterId = author;
            Content = content;
            Date = date;
        }

        public Comment()
        {
            RecipeId = 0;
            CommenterId = 0;
            Content = "";
            Date = DateTime.Now;
        }
        
        */
    }
}
