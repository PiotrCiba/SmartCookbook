using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Models;

namespace SmartCookbook.Data
{
    public class ApplicationDbContext : IdentityDbContext<SmartCookbookUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Add a DbSet for each entity you need to keep track of in the database
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CookingStep> CookingSteps { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SmartCookbook.Models.IngredientInstance> IngredientInstance { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IngredientInstance>()
                .HasOne(ii => ii.Ingredient)
                .WithMany(i => i.IngredientInstances)
                .HasForeignKey(ii => ii.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Recipe>()
                .HasMany(r => r.Ingredients)
                .WithOne(ii => ii.Recipe)
                .HasForeignKey(ii => ii.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Recipe>()
                .HasMany(r => r.Steps)
                .WithOne(s => s.Recipe)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Recipe>()
                .HasMany(r => r.Ratings)
                .WithOne(ra => ra.Recipe)
                .HasForeignKey(ra => ra.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Recipe>()
                .HasMany(r => r.Comments)
                .WithOne(c => c.Recipe)
                .HasForeignKey(c => c.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
