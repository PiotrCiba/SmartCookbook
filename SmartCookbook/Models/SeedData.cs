//using AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartCookbook.Data;
using System;
using System.Drawing.Text;
using System.Linq;

namespace SmartCookbook.Models;

public class SeedData
{
    //initialize the database with some test data
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<SeedData>>();
        using (var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
                        
            logger.LogInformation("SeedData: Seeding database");
            context.Recipes.AddRange(
                new Recipe
                {
                    Author = 1,
                    Private = false,
                    UploadDate = DateTime.Parse("2021-01-01"),
                    Name = "Spaghetti Carbonara",
                    ImagePath = "spaghetti.jpg",
                    Description = "A classic Italian pasta dish",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient("Spaghetti", 100, "g", 371, 1.3, 75, 13),
                        new Ingredient("Egg", 1, "", 155, 11, 1.1, 13),
                        new Ingredient("Pancetta", 50, "g", 226, 18, 0, 15),
                        new Ingredient("Parmesan", 50, "g", 431, 29, 4, 38),
                        new Ingredient("Black Pepper", 1, "tsp", 255, 3.3, 64, 10)
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Boil water in a large pot", 5, "min"),
                        new CookingStep("Cook pancetta in a pan", 5, "min"),
                        new CookingStep("Cook spaghetti in boiling water", 10, "min"),
                        new CookingStep("Mix egg, cheese, and pepper in a bowl", 5, "min"),
                        new CookingStep("Drain spaghetti and mix with egg mixture", 5, "min"),
                        new CookingStep("Serve with pancetta on top", 0, "")
                    }
                },
                new Recipe
                {
                    Author = 2,
                    Private = false,
                    UploadDate = DateTime.Parse("2021-01-02"),
                    Name = "Chicken Curry",
                    ImagePath = "curry.jpg",
                    Description = "A spicy Indian dish",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient("Chicken", 200, "g", 239, 14, 0, 27),
                        new Ingredient("Onion", 1, "", 40, 0.1, 9, 1.1),
                        new Ingredient("Tomato", 1, "", 18, 0.2, 3.9, 0.9),
                        new Ingredient("Curry Powder", 1, "tbsp", 325, 7.9, 58, 14),
                        new Ingredient("Coconut Milk", 200, "ml", 230, 24, 3.3, 2.3)
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Cook onion in a pan", 5, "min"),
                        new CookingStep("Add chicken and curry powder", 10, "min"),
                        new CookingStep("Add tomato and coconut milk", 10, "min"),
                        new CookingStep("Simmer until chicken is cooked", 15, "min"),
                        new CookingStep("Serve with rice", 0, "")
                    }
                },
                new Recipe
                {
                    Author = 3,
                    Private = false,
                    UploadDate = DateTime.Parse("2021-01-03"),
                    Name = "Chocolate Cake",
                    ImagePath = "cake.jpg",
                    Description = "A rich and decadent dessert",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient("Flour", 200, "g", 364, 1.2, 76, 10),
                        new Ingredient("Sugar", 200, "g", 387, 0, 100, 0),
                        new Ingredient("Butter", 200, "g", 717, 81, 0, 1),
                        new Ingredient("Egg", 4, "", 155, 11, 1.1, 13),
                        new Ingredient("Cocoa Powder", 50, "g", 228, 14, 57, 20)
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Mix butter and sugar", 5, "min"),
                        new CookingStep("Add eggs one at a time", 5, "min"),
                        new CookingStep("Fold in flour and cocoa powder", 5, "min"),
                        new CookingStep("Bake in oven at 180°C", 30, "min"),
                        new CookingStep("Cool and serve", 0, "")
                    }
                },
                new Recipe
                {
                    Author = 4,
                    Private = false,
                    UploadDate = DateTime.Parse("2021-01-04"),
                    Name = "Greek Salad",
                    ImagePath = "salad.jpg",
                    Description = "A light and refreshing salad",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient("Lettuce", 100, "g", 15, 0.2, 2.9, 1.4),
                        new Ingredient("Tomato", 1, "", 18, 0.2, 3.9, 0.9),
                        new Ingredient("Cucumber", 0.5, "", 15, 0.1, 3.6, 0.7),
                        new Ingredient("Feta Cheese", 50, "g", 264, 21, 4.1, 14),
                        new Ingredient("Olives", 10, "", 115, 11, 6, 0.8)
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Chop lettuce, tomato, and cucumber", 5, "min"),
                        new CookingStep("Mix with feta cheese and olives", 5, "min"),
                        new CookingStep("Drizzle with olive oil and vinegar", 1, "min"),
                        new CookingStep("Season with salt and pepper", 0, ""),
                        new CookingStep("Serve chilled", 0, "")
                    }
                },
                new Recipe
                {
                    Author = 5,
                    Private = false,
                    UploadDate = DateTime.Parse("2021-01-05"),
                    Name = "Vegetable Stir-Fry",
                    ImagePath = "stirfry.jpg",
                    Description = "A quick and healthy meal",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient("Broccoli", 100, "g", 34, 0.4, 7, 2.8),
                        new Ingredient("Carrot", 1, "", 41, 0.2, 10, 0.9),
                        new Ingredient("Bell Pepper", 1, "", 31, 0.3, 6, 1),
                        new Ingredient("Soy Sauce", 1, "tbsp", 8, 0, 1.3, 0.9),
                        new Ingredient("Rice", 100, "g", 130, 0.3, 28, 2.7)
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Stir-fry vegetables in a pan", 10, "min"),
                        new CookingStep("Add soy sauce and cook until tender", 5, "min"),
                        new CookingStep("Serve over rice", 0, "")
                    }
                },
                new Recipe
                {
                    Author = 6,
                    Private = false,
                    UploadDate = DateTime.Parse("2021-01-06"),
                    Name = "Tiramisu",
                    ImagePath = "tiramisu.jpg",
                    Description = "A classic Italian dessert",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient("Ladyfingers", 200, "g", 371, 1.3, 75, 13),
                        new Ingredient("Espresso", 1, "cup", 2, 0, 0.7, 0.3),
                        new Ingredient("Mascarpone", 250, "g", 429, 43, 4.1, 5.3),
                        new Ingredient("Egg", 2, "", 155, 11, 1.1, 13),
                        new Ingredient("Cocoa Powder", 2, "tbsp", 228, 14, 57, 20)
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Dip ladyfingers in espresso", 5, "min"),
                        new CookingStep("Layer with mascarpone mixture", 5, "min"),
                        new CookingStep("Repeat layers", 5, "min"),
                        new CookingStep("Chill in refrigerator", 2, "hr"),
                        new CookingStep("Dust with cocoa powder before serving", 0, "")
                    }
                },
                new Recipe
                {
                    Author = 7,
                    Private = false,
                    UploadDate = DateTime.Parse("2021-01-07"),
                    Name = "Pancakes",
                    ImagePath = "pancakes.jpg",
                    Description = "A classic breakfast treat",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient("Flour", 200, "g", 364, 1.2, 76, 10),
                        new Ingredient("Milk", 200, "ml", 42, 1, 5, 3),
                        new Ingredient("Egg", 1, "", 155, 11, 1.1, 13),
                        new Ingredient("Butter", 50, "g", 717, 81, 0, 1),
                        new Ingredient("Maple Syrup", 2, "tbsp", 52, 0, 13, 0)
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Mix flour, milk, and egg in a bowl", 5, "min"),
                        new CookingStep("Melt butter in a pan", 1, "min"),
                        new CookingStep("Pour batter into pan and cook until golden", 5, "min"),
                        new CookingStep("Serve with maple syrup", 0, "")
                    }
                }
                );
            context.SaveChanges();
        };
    }
}

