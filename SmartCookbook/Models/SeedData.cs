//using AspNetCore;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Data;
using SmartCookbook.Data.Migrations;
using System;

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

            if (context.Recipes.Any())
            {
                logger.LogInformation("SeedData: Database already seeded");
                return;
            }

            logger.LogInformation("SeedData: Seeding database");

            /*context.AddRange(

                new Recipe()
                {
                    Author = "1",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Chicken Alfredo",
                    ImagePath = "alfredo.jpg",
                    Description = "A creamy pasta dish with chicken",
                    Ingredients = new List<IngredientInstance>
                    {
                        new (new ("Fettuccine", 371, 1.5, 75, 13 ), 100, "g" ),
                        new (new ("Chicken Breast", 165, 3.6, 0, 31), 100, "g" ),
                        new (new ("Heavy Cream", 340, 36, 3, 2), 100, "g"),
                        new (new ("Parmesan", 431, 29, 4, 38), 50, "g"),
                        new (new ("Garlic", 149, 0.5, 33, 6), 1, "clove")
                    },
                    Steps = new List<CookingStep>
                    {
                        new ("Cook the fettuccine in a large pot of boiling salted water until al dente", 10, "minutes" ),
                        new ("Season the chicken with salt and pepper and cook in a skillet until browned", 5, "minutes"),
                        new ("Add the garlic and cook for 1 minute", 1, "minute"),
                        new ("Add the cream and cheese and cook until thickened", 5, "minutes"),
                        new ("Toss the pasta with the sauce and serve", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "2",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Spaghetti Carbonara",
                    ImagePath = "carbonara.jpg",
                    Description = "A classic Italian pasta dish with a creamy egg-based sauce and pancetta.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Spaghetti", 371, 1.5, 75, 13), 100, "g"),
                        new IngredientInstance(new Ingredient("Pancetta", 393, 37, 0, 18), 50, "g"),
                        new IngredientInstance(new Ingredient("Eggs", 155, 11, 1, 13), 2, "large"),
                        new IngredientInstance(new Ingredient("Parmesan", 431, 29, 4, 38), 50, "g"),
                        new IngredientInstance(new Ingredient("Black Pepper", 251, 3.3, 64, 10), 1, "tsp")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Cook the spaghetti in salted water until al dente", 10, "minutes"),
                        new CookingStep("Fry the pancetta until crisp", 5, "minutes"),
                        new CookingStep("Beat the eggs with Parmesan and pepper", 1, "minute"),
                        new CookingStep("Drain the pasta and toss with pancetta and egg mixture", 2, "minutes"),
                        new CookingStep("Serve immediately", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "3",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Beef Tacos",
                    ImagePath = "tacos.jpg",
                    Description = "Mexican-style beef tacos with fresh toppings.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Ground Beef", 250, 20, 0, 26), 200, "g"),
                        new IngredientInstance(new Ingredient("Taco Seasoning", 300, 12, 50, 8), 2, "tbsp"),
                        new IngredientInstance(new Ingredient("Tortillas", 218, 4.5, 30, 5), 4, "pieces"),
                        new IngredientInstance(new Ingredient("Lettuce", 15, 0.2, 3, 1), 50, "g"),
                        new IngredientInstance(new Ingredient("Cheddar Cheese", 403, 33, 1, 25), 50, "g"),
                        new IngredientInstance(new Ingredient("Tomatoes", 18, 0.2, 4, 1), 1, "medium")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Cook the ground beef in a skillet until browned", 8, "minutes"),
                        new CookingStep("Stir in taco seasoning and a bit of water, simmer until thickened", 5, "minutes"),
                        new CookingStep("Warm the tortillas in a dry skillet or microwave", 2, "minutes"),
                        new CookingStep("Assemble tacos with beef, lettuce, cheese, and diced tomatoes", 3, "minutes"),
                        new CookingStep("Serve immediately", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "1",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Tomato Basil Soup",
                    ImagePath = "tomato_soup.jpg",
                    Description = "A creamy tomato soup with fresh basil.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Tomatoes", 18, 0.2, 4, 1), 500, "g"),
                        new IngredientInstance(new Ingredient("Onion", 40, 0.1, 9, 1), 1, "medium"),
                        new IngredientInstance(new Ingredient("Garlic", 149, 0.5, 33, 6), 2, "cloves"),
                        new IngredientInstance(new Ingredient("Vegetable Broth", 15, 0, 2, 0), 500, "ml"),
                        new IngredientInstance(new Ingredient("Heavy Cream", 340, 36, 3, 2), 100, "ml"),
                        new IngredientInstance(new Ingredient("Fresh Basil", 23, 0.6, 1, 3), 20, "g")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Sauté the chopped onion and garlic until soft", 5, "minutes"),
                        new CookingStep("Add the tomatoes and broth, bring to a boil", 10, "minutes"),
                        new CookingStep("Simmer for 20 minutes", 20, "minutes"),
                        new CookingStep("Blend the soup until smooth", 2, "minutes"),
                        new CookingStep("Stir in the cream and chopped basil", 5, "minutes"),
                        new CookingStep("Serve hot", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "2",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Chocolate Chip Cookies",
                    ImagePath = "cookies.jpg",
                    Description = "Classic chocolate chip cookies with a crispy edge and chewy center.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("All-Purpose Flour", 364, 1, 76, 10), 200, "g"),
                        new IngredientInstance(new Ingredient("Butter", 717, 81, 1, 1), 100, "g"),
                        new IngredientInstance(new Ingredient("Brown Sugar", 380, 0, 98, 0), 100, "g"),
                        new IngredientInstance(new Ingredient("Granulated Sugar", 387, 0, 100, 0), 50, "g"),
                        new IngredientInstance(new Ingredient("Eggs", 155, 11, 1, 13), 1, "large"),
                        new IngredientInstance(new Ingredient("Chocolate Chips", 497, 25, 61, 5), 150, "g"),
                        new IngredientInstance(new Ingredient("Vanilla Extract", 288, 0, 12, 0), 1, "tsp")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Preheat oven to 180°C (350°F)", 5, "minutes"),
                        new CookingStep("Cream the butter and sugars together until light and fluffy", 3, "minutes"),
                        new CookingStep("Beat in the egg and vanilla extract", 2, "minutes"),
                        new CookingStep("Gradually mix in the flour", 2, "minutes"),
                        new CookingStep("Stir in the chocolate chips", 1, "minute"),
                        new CookingStep("Drop spoonfuls of dough onto a baking sheet", 3, "minutes"),
                        new CookingStep("Bake until golden brown", 10, "minutes"),
                        new CookingStep("Cool on a wire rack", 10, "minutes")
                    }
                },

                new Recipe()
                {
                    Author = "4",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Caesar Salad",
                    ImagePath = "caesar_salad.jpg",
                    Description = "A crisp salad with romaine, croutons, and a creamy Caesar dressing.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Romaine Lettuce", 17, 0.3, 3, 1), 200, "g"),
                        new IngredientInstance(new Ingredient("Croutons", 407, 12, 62, 8), 50, "g"),
                        new IngredientInstance(new Ingredient("Parmesan", 431, 29, 4, 38), 30, "g"),
                        new IngredientInstance(new Ingredient("Caesar Dressing", 350, 35, 2, 3), 50, "ml"),
                        new IngredientInstance(new Ingredient("Anchovy Fillets", 131, 6, 0, 20), 2, "fillets")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Chop the romaine lettuce and place in a large bowl", 3, "minutes"),
                        new CookingStep("Toss the lettuce with Caesar dressing", 2, "minutes"),
                        new CookingStep("Add croutons and Parmesan cheese", 1, "minute"),
                        new CookingStep("Top with anchovy fillets", 1, "minute"),
                        new CookingStep("Serve chilled", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "3",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Grilled Salmon",
                    ImagePath = "grilled_salmon.jpg",
                    Description = "A simple and delicious grilled salmon with lemon and herbs.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Salmon Fillet", 206, 13, 0, 22), 200, "g"),
                        new IngredientInstance(new Ingredient("Olive Oil", 884, 100, 0, 0), 1, "tbsp"),
                        new IngredientInstance(new Ingredient("Lemon", 29, 0.3, 9, 1), 1, "slice"),
                        new IngredientInstance(new Ingredient("Garlic", 149, 0.5, 33, 6), 1, "clove"),


                 new IngredientInstance(new Ingredient("Fresh Dill", 43, 1.1, 8, 4), 5, "g")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Preheat the grill to medium-high heat", 5, "minutes"),
                        new CookingStep("Brush the salmon with olive oil and season with salt and pepper", 2, "minutes"),
                        new CookingStep("Grill the salmon for 4-5 minutes per side", 10, "minutes"),
                        new CookingStep("Squeeze lemon juice over the salmon", 1, "minute"),
                        new CookingStep("Garnish with chopped dill and minced garlic", 1, "minute"),
                        new CookingStep("Serve hot", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "1",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Vegetable Stir-Fry",
                    ImagePath = "stir_fry.jpg",
                    Description = "A quick and healthy vegetable stir-fry with a soy sauce glaze.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Broccoli", 34, 0.4, 7, 3), 100, "g"),
                        new IngredientInstance(new Ingredient("Carrots", 41, 0.2, 10, 1), 50, "g"),
                        new IngredientInstance(new Ingredient("Bell Peppers", 31, 0.3, 6, 1), 50, "g"),
                        new IngredientInstance(new Ingredient("Soy Sauce", 53, 0.6, 8, 5), 2, "tbsp"),
                        new IngredientInstance(new Ingredient("Ginger", 80, 0.8, 18, 2), 1, "tsp"),
                        new IngredientInstance(new Ingredient("Garlic", 149, 0.5, 33, 6), 2, "cloves")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Heat a wok over high heat and add a bit of oil", 2, "minutes"),
                        new CookingStep("Add the minced garlic and ginger, stir-fry for 30 seconds", 1, "minute"),
                        new CookingStep("Add the vegetables and stir-fry until tender-crisp", 5, "minutes"),
                        new CookingStep("Stir in the soy sauce and cook for another minute", 1, "minute"),
                        new CookingStep("Serve hot over rice or noodles", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "2",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Margherita Pizza",
                    ImagePath = "margherita_pizza.jpg",
                    Description = "A simple and classic pizza topped with tomatoes, mozzarella, and basil.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Pizza Dough", 266, 2.9, 52, 8), 1, "ball"),
                        new IngredientInstance(new Ingredient("Tomato Sauce", 29, 0.2, 7, 1), 100, "g"),
                        new IngredientInstance(new Ingredient("Mozzarella Cheese", 280, 17, 3, 28), 100, "g"),
                        new IngredientInstance(new Ingredient("Tomatoes", 18, 0.2, 4, 1), 1, "medium"),
                        new IngredientInstance(new Ingredient("Fresh Basil", 23, 0.6, 1, 3), 10, "g")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Preheat oven to 220°C (425°F)", 5, "minutes"),
                        new CookingStep("Roll out the pizza dough on a floured surface", 3, "minutes"),
                        new CookingStep("Spread tomato sauce over the dough", 2, "minutes"),
                        new CookingStep("Top with sliced tomatoes and mozzarella cheese", 3, "minutes"),
                        new CookingStep("Bake until the crust is golden and the cheese is bubbly", 12, "minutes"),
                        new CookingStep("Garnish with fresh basil leaves", 1, "minute"),
                        new CookingStep("Serve hot", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "4",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Blueberry Pancakes",
                    ImagePath = "blueberry_pancakes.jpg",
                    Description = "Fluffy pancakes filled with fresh blueberries.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("All-Purpose Flour", 364, 1, 76, 10), 200, "g"),
                        new IngredientInstance(new Ingredient("Milk", 42, 1, 5, 3), 200, "ml"),
                        new IngredientInstance(new Ingredient("Eggs", 155, 11, 1, 13), 1, "large"),
                        new IngredientInstance(new Ingredient("Butter", 717, 81, 1, 1), 50, "g"),
                        new IngredientInstance(new Ingredient("Blueberries", 57, 0.3, 14, 1), 100, "g"),
                        new IngredientInstance(new Ingredient("Baking Powder", 53, 0, 28, 0), 1, "tsp")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Mix the flour, baking powder, and a pinch of salt", 2, "minutes"),
                        new CookingStep("Whisk in the milk and egg until smooth", 2, "minutes"),
                        new CookingStep("Stir in the melted butter", 1, "minute"),
                        new CookingStep("Fold in the blueberries", 1, "minute"),
                        new CookingStep("Heat a skillet over medium heat and add a bit of butter", 2, "minutes"),
                        new CookingStep("Pour batter into the skillet and cook until bubbles form", 2, "minutes"),
                        new CookingStep("Flip and cook until golden brown", 2, "minutes"),
                        new CookingStep("Serve with maple syrup", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "3",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Garlic Bread",
                    ImagePath = "garlic_bread.jpg",
                    Description = "A crispy baguette topped with garlic butter.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Baguette", 250, 1.3, 50, 9), 1, "loaf"),
                        new IngredientInstance(new Ingredient("Butter", 717, 81, 1, 1), 100, "g"),
                        new IngredientInstance(new Ingredient("Garlic", 149, 0.5, 33, 6), 3, "cloves"),
                        new IngredientInstance(new Ingredient("Parsley", 36, 0.8, 6, 3), 10, "g"),
                        new IngredientInstance(new Ingredient("Parmesan", 431, 29, 4, 38), 30, "g")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Preheat oven to 180°C (350°F)", 5, "minutes"),
                        new CookingStep("Mix the softened butter with minced garlic and chopped parsley", 2, "minutes"),
                        new CookingStep("Slice the baguette and spread the garlic butter on each piece", 3, "minutes"),
                        new CookingStep("Sprinkle with Parmesan cheese", 1, "minute"),
                        new CookingStep("Bake until golden and crispy", 10, "minutes"),
                        new CookingStep("Serve warm", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "1",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Chicken Stir-Fry",
                    ImagePath = "chicken_stir_fry.jpg",
                    Description = "A quick and easy chicken stir-fry with vegetables.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Chicken Breast", 165, 3.6, 0, 31), 200, "g"),
                        new IngredientInstance(new Ingredient("Broccoli", 34, 0.4, 7, 3), 100, "g"),
                        new IngredientInstance(new Ingredient("Carrots", 41, 0.2, 10, 1), 50, "g"),
                        new IngredientInstance(new Ingredient("Soy Sauce", 53, 0.6, 8, 5), 2, "tbsp"),
                        new IngredientInstance(new Ingredient("Ginger", 80, 0.8, 18, 2), 1, "tsp"),
                        new IngredientInstance(new Ingredient("Garlic", 149, 0.5, 33, 6), 2, "cloves")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Heat a wok over high heat and add a bit of oil", 2, "minutes"),
                        new CookingStep("Add the minced garlic and ginger, stir-fry for 30 seconds", 1, "minute"),
                        new CookingStep("Add the chicken and stir-fry until browned", 5, "minutes"),
                        new CookingStep("Add the vegetables and stir-fry until tender-crisp",

                5, "minutes"),
                        new CookingStep("Stir in the soy sauce and cook for another minute", 1, "minute"),
                        new CookingStep("Serve hot over rice", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "2",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Lemonade",
                    ImagePath = "lemonade.jpg",
                    Description = "A refreshing homemade lemonade.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Lemons", 29, 0.3, 9, 1), 4, "pieces"),
                        new IngredientInstance(new Ingredient("Sugar", 387, 0, 100, 0), 100, "g"),
                        new IngredientInstance(new Ingredient("Water", 0, 0, 0, 0), 1, "liter"),
                        new IngredientInstance(new Ingredient("Mint Leaves", 44, 0.6, 9, 4), 5, "g")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Juice the lemons and strain the juice", 5, "minutes"),
                        new CookingStep("Dissolve the sugar in a bit of hot water", 2, "minutes"),
                        new CookingStep("Combine the lemon juice, sugar syrup, and cold water", 2, "minutes"),
                        new CookingStep("Stir well and chill in the refrigerator", 30, "minutes"),
                        new CookingStep("Serve over ice with mint leaves", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "4",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Banana Bread",
                    ImagePath = "banana_bread.jpg",
                    Description = "Moist and flavorful banana bread with walnuts.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("All-Purpose Flour", 364, 1, 76, 10), 200, "g"),
                        new IngredientInstance(new Ingredient("Bananas", 89, 0.3, 23, 1), 3, "medium"),
                        new IngredientInstance(new Ingredient("Butter", 717, 81, 1, 1), 100, "g"),
                        new IngredientInstance(new Ingredient("Brown Sugar", 380, 0, 98, 0), 100, "g"),
                        new IngredientInstance(new Ingredient("Eggs", 155, 11, 1, 13), 2, "large"),
                        new IngredientInstance(new Ingredient("Walnuts", 654, 65, 14, 15), 50, "g"),
                        new IngredientInstance(new Ingredient("Baking Soda", 0, 0, 0, 0), 1, "tsp")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Preheat oven to 175°C (350°F)", 5, "minutes"),
                        new CookingStep("Mash the bananas in a bowl", 2, "minutes"),
                        new CookingStep("Cream the butter and sugar together", 3, "minutes"),
                        new CookingStep("Beat in the eggs and mashed bananas", 2, "minutes"),
                        new CookingStep("Mix in the flour, baking soda, and chopped walnuts", 3, "minutes"),
                        new CookingStep("Pour the batter into a greased loaf pan", 2, "minutes"),
                        new CookingStep("Bake until a toothpick comes out clean", 60, "minutes"),
                        new CookingStep("Cool before slicing", 20, "minutes")
                    }
                },

                new Recipe()
                {
                    Author = "3",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Mango Smoothie",
                    ImagePath = "mango_smoothie.jpg",
                    Description = "A creamy and tropical mango smoothie.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Mangoes", 60, 0.4, 15, 1), 2, "medium"),
                        new IngredientInstance(new Ingredient("Yogurt", 59, 3.3, 7, 10), 200, "g"),
                        new IngredientInstance(new Ingredient("Honey", 304, 0, 82, 0), 2, "tbsp"),
                        new IngredientInstance(new Ingredient("Milk", 42, 1, 5, 3), 100, "ml"),
                        new IngredientInstance(new Ingredient("Ice Cubes", 0, 0, 0, 0), 5, "pieces")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Peel and chop the mangoes", 5, "minutes"),
                        new CookingStep("Blend the mangoes, yogurt, honey, and milk until smooth", 2, "minutes"),
                        new CookingStep("Add ice cubes and blend again", 1, "minute"),
                        new CookingStep("Serve cold", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "4",
                    Private = true,
                    UploadDate = DateTime.Now,
                    Name = "Secret Family Chili",
                    ImagePath = "chili.jpg",
                    Description = "A hearty and spicy chili with beans and ground beef.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Ground Beef", 250, 20, 0, 26), 500, "g"),
                        new IngredientInstance(new Ingredient("Kidney Beans", 127, 0.5, 23, 8), 400, "g"),
                        new IngredientInstance(new Ingredient("Tomato Sauce", 29, 0.2, 7, 1), 200, "g"),
                        new IngredientInstance(new Ingredient("Onion", 40, 0.1, 9, 1), 1, "medium"),
                        new IngredientInstance(new Ingredient("Chili Powder", 282, 14, 49, 13), 2, "tbsp"),
                        new IngredientInstance(new Ingredient("Garlic", 149, 0.5, 33, 6), 2, "cloves"),
                        new IngredientInstance(new Ingredient("Cumin", 375, 22, 44, 18), 1, "tsp")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Cook the ground beef in a large pot until browned", 8, "minutes"),
                        new CookingStep("Add the chopped onion and minced garlic, sauté until soft", 5, "minutes"),
                        new CookingStep("Stir in the chili powder and cumin", 2, "minutes"),
                        new CookingStep("Add the tomato sauce and beans, simmer for 30 minutes", 30, "minutes"),
                        new CookingStep("Serve hot with toppings of your choice", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "1",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Grilled Cheese Sandwich",
                    ImagePath = "grilled_cheese.jpg",
                    Description = "A classic grilled cheese sandwich with melted cheddar.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Bread", 265, 3.2, 49, 9), 2, "slices"),
                        new IngredientInstance(new Ingredient("Cheddar Cheese", 403, 33, 1, 25), 50, "g"),
                        new IngredientInstance(new Ingredient("Butter", 717, 81, 1, 1), 20, "g")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Butter the outside of each bread slice", 2, "minutes"),
                        new CookingStep("Place the cheese between the bread slices", 1, "minute"),
                        new CookingStep("Heat a skillet over medium heat", 2, "minutes"),
                        new CookingStep("Grill the sandwich until golden brown and the cheese is melted", 5, "minutes"),
                        new CookingStep("Serve hot", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "2",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Egg Fried Rice",
                    ImagePath = "egg_fried_rice.jpg",
                    Description = "A simple and tasty fried rice with eggs and vegetables.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Cooked Rice", 130, 0.3, 28, 2), 200, "g"),
                        new IngredientInstance(new Ingredient("Eggs", 155, 11, 1, 13), 2, "large"),
                        new IngredientInstance(new Ingredient("Carrots", 41, 0.2, 10, 1), 50, "g"),
                        new IngredientInstance(new Ingredient("Peas", 81, 0.4, 14, 5), 50, "g"),
                        new IngredientInstance(new Ingredient("Soy Sauce", 53, 0.6, 8, 5), 2, "tbsp"),
                        new IngredientInstance(new Ingredient("Green Onions", 32, 0.2, 7, 1), 2, "stalks")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Heat a bit of oil in a wok and scramble the eggs", 3, "minutes"),
                        new CookingStep("Add the chopped carrots and peas, stir-fry until tender", 5, "minutes"),
                        new CookingStep("Add the cooked rice and soy sauce, stir well", 2, "minutes"),
                        new CookingStep("Mix in the chopped green onions", 1, "minute"),
                        new CookingStep("Serve hot", 1, "minute")
                    }
                },

                new Recipe()
                {
                    Author = "3",
                    Private = false,
                    UploadDate = DateTime.Now,
                    Name = "Fruit Salad",
                    ImagePath = "fruit_salad.jpg",
                    Description = "A refreshing fruit salad with a honey-lime dressing.",
                    Ingredients = new List<IngredientInstance>
                    {
                        new IngredientInstance(new Ingredient("Strawberries", 32, 0.3, 8, 1), 100, "g"),
                        new IngredientInstance(new Ingredient("Blueberries", 57, 0.3, 14, 1), 100, "g"),
                        new IngredientInstance(new Ingredient("Kiwi", 61, 0.5, 15, 1), 2, "pieces"),
                        new IngredientInstance(new Ingredient("Mangoes", 60, 0.4, 15, 1), 1, "medium"),
                        new IngredientInstance(new Ingredient("Honey", 304, 0, 82, 0), 1, "tbsp"),
                        new IngredientInstance(new Ingredient("Lime Juice", 30, 0.2, 11, 1), 1, "tbsp"),
                        new IngredientInstance(new Ingredient("Mint Leaves", 44, 0.6, 9, 4), 5, "g")
                    },
                    Steps = new List<CookingStep>
                    {
                        new CookingStep("Chop the strawberries, kiwi, and mango into bite-sized pieces", 5, "minutes"),
                        new CookingStep("Mix the fruits in a large bowl", 2, "minutes"),
                        new CookingStep("Whisk together the honey and lime juice", 1, "minute"),
                        new CookingStep("Pour the dressing over the fruit and toss gently", 2, "minutes"),
                        new CookingStep("Garnish with mint leaves and serve", 1, "minute")
                    }
                }

            );*/
            
            

            context.SaveChanges();
        };
    }
}

