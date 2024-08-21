//using AspNetCore;
using Microsoft.EntityFrameworkCore;
using SmartCookbook.Data;

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
            context.Recipes.AddRange(
                //recipes
                new Recipe
                {
                    Author = 1,
                    Name = "Spaghetti Carbonara",
                    Description = "A classic Italian pasta dish",
                    Ingredients = new ()
                    {
                        new("Spaghetti", "g", 220, 1.3, 43.2, 8.1),
                        new("Egg", null, 68, 4.8, 0.6, 5.5),
                        new("Pancetta", "g", 226, 18.3, 0.0, 14.1), 
                        new("Parmesan", "g", 431, 29.2, 3.4, 38.5), 
                        new("Black Pepper", "g", 255, 3.3, 64.8, 10.4), 
                    },
                    Quantity = new()
                    {
                        100,
                        2,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new ("Cook the spaghetti in a large pot of boiling salted water until al dente", 10, "min"),
                        new ("In a large bowl, whisk together the eggs, pancetta, parmesan, and black pepper", 5, "min"),
                        new ("Drain the spaghetti and add it to the egg mixture", 2, "min"),
                        new ("Toss the spaghetti until it is coated with the egg mixture", 1, "min")
                    }
                },
                new Recipe
                {
                    Author = 2,
                    Name = "Chicken Alfredo",
                    Description = "A creamy pasta dish with chicken",
                    Ingredients = new()
                    {
                        new("Fettuccine", "g", 210, 1.3, 41.2, 7.3),
                        new("Chicken Breast", "g", 165, 3.6, 0.0, 31.0),
                        new("Heavy Cream", "g", 345, 36.0, 2.0, 2.0),
                        new("Parmesan", "g", 431, 29.2, 3.4, 38.5),
                        new("Garlic", "g", 149, 0.5, 33.1, 6.3),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("Cook the fettuccine in a large pot of boiling salted water until al dente", 10, "min"),
                        new("Season the chicken with salt and pepper and cook in a skillet until browned", 10, "min"),
                        new("Add the garlic and cook for 1 minute", 1, "min"),
                        new("Add the heavy cream and parmesan and bring to a simmer", 5, "min"),
                        new("Add the cooked fettuccine and chicken to the sauce and toss to combine", 2, "min")
                    }
                },
                new Recipe
                {
                    Author = 3,
                    Name = "Chocolate Chip Cookies",
                    Description = "A classic cookie recipe",
                    Ingredients = new()
                    {
                        new("Flour", "g", 364, 1.2, 76.3, 10.3),
                        new("Butter", "g", 717, 81.1, 0.0, 0.9),
                        new("Sugar", "g", 387, 0.0, 99.8, 0.0),
                        new("Brown Sugar", "g", 380, 0.0, 98.0, 0.0),
                        new("Egg", null, 68, 4.8, 0.6, 5.5),
                        new("Vanilla Extract", "g", 288, 0.0, 14.0, 0.0),
                        new("Baking Soda", "g", 0, 0.0, 0.0, 0.0),
                        new("Salt", "g", 0, 0.0, 0.0, 0.0),
                        new("Chocolate Chips", "g", 499, 27.0, 60.0, 6.0),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100,
                        100,
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("Preheat the oven to 350°F", 0, "min"),
                        new("Cream the butter and sugars together until light and fluffy", 5, "min"),
                        new("Add the egg and vanilla and mix until combined", 2, "min"),
                        new("Add the flour, baking soda, and salt and mix until combined", 2, "min"),
                        new("Fold in the chocolate chips", 1, "min"),
                        new("Scoop the dough onto a baking sheet and bake for 10-12 minutes", 10, "min")
                    }
                },
                new Recipe
                {
                    Author = 3,
                    Name = "Caesar Salad",
                    Description = "A classic salad with romaine lettuce, croutons, and parmesan cheese",
                    Ingredients = new()
                    {
                        new("Romaine Lettuce", "g", 17, 0.3, 3.3, 1.2),
                        new("Croutons", "g", 122, 1.0, 23.0, 4.0),
                        new("Parmesan", "g", 431, 29.2, 3.4, 38.5),
                        new("Caesar Dressing", "g", 425, 45.0, 2.0, 1.0),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("Tear the lettuce into bite-sized pieces and place in a large bowl", 5, "min"),
                        new("Add the croutons and parmesan to the bowl", 2, "min"),
                        new("Add the dressing and toss to combine", 1, "min")
                    }
                },
                new Recipe
                {
                    Author = 3,
                    Name = "Margarita Pizza",
                    Description = "A classic pizza with tomato sauce, mozzarella, and basil",
                    Ingredients = new()
                    {
                        new("Pizza Dough", "g", 288, 0.0, 58.0, 9.0),
                        new("Tomato Sauce", "g", 82, 0.0, 17.0, 3.0),
                        new("Mozzarella", "g", 300, 22.0, 2.0, 24.0),
                        new("Basil", "g", 23, 0.0, 4.0, 3.0),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("Preheat the oven to 500°F", 0, "min"),
                        new("Roll out the dough on a floured surface", 5, "min"),
                        new("Spread the tomato sauce on the dough", 2, "min"),
                        new("Top with the mozzarella and basil", 1, "min"),
                        new("Bake for 10-12 minutes, until the crust is golden brown", 10, "min")
                    }
                },
                new Recipe
                {
                    Author = 1,
                    Name = "Chicken Noodle Soup",
                    Description = "A classic soup with chicken, noodles, and vegetables",
                    Ingredients = new()
                    {
                        new("Chicken Breast", "g", 165, 3.6, 0.0, 31.0),
                        new("Carrots", "g", 41, 0.2, 9.6, 0.9),
                        new("Celery", "g", 16, 0.2, 3.0, 0.7),
                        new("Onion", "g", 40, 0.1, 9.3, 1.2),
                        new("Garlic", "g", 149, 0.5, 33.1, 6.3),
                        new("Chicken Broth", "g", 86, 0.0, 0.0, 0.0),
                        new("Egg Noodles", "g", 138, 1.0, 26.0, 5.0),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("Season the chicken with salt and pepper and cook in a skillet until browned", 10, "min"),
                        new("Add the carrots, celery, onion, and garlic and cook for 5 minutes", 5, "min"),
                        new("Add the chicken broth and bring to a simmer", 5, "min"),
                        new("Add the egg noodles and cook until tender", 10, "min")
                    }
                },
                new Recipe
                {
                    Author = 2,
                    Name = "Pancakes",
                    Description = "A classic breakfast recipe",
                    Ingredients = new()
                    {
                        new("Flour", "g", 364, 1.2, 76.3, 10.3),
                        new("Sugar", "g", 387, 0.0, 99.8, 0.0),
                        new("Baking Powder", "g", 0, 0.0, 0.0, 0.0),
                        new("Salt", "g", 0, 0.0, 0.0, 0.0),
                        new("Milk", "g", 42, 0.1, 5.0, 3.3),
                        new("Egg", null, 68, 4.8, 0.6, 5.5),
                        new("Butter", "g", 717, 81.1, 0.0, 0.9),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("In a large bowl, whisk together the flour, sugar, baking powder, and salt", 5, "min"),
                        new("In a separate bowl, whisk together the milk, egg, and melted butter", 2, "min"),
                        new("Add the wet ingredients to the dry ingredients and mix until just combined", 2, "min"),
                        new("Heat a griddle or skillet over medium heat and grease with butter", 1, "min"),
                        new("Pour 1/4 cup of batter onto the griddle and cook until bubbles form on the surface", 2, "min"),
                        new("Flip the pancake and cook for another 1-2 minutes, until golden brown", 2, "min")
                    }
                },
                new Recipe
                {
                    Author = 1,
                    Name = "Guacamole",
                    Description = "A classic dip made with avocados, tomatoes, and onions",
                    Ingredients = new()
                    {
                        new("Avocado", "g", 160, 14.7, 8.5, 2.0),
                        new("Tomato", "g", 18, 0.2, 3.9, 0.9),
                        new("Onion", "g", 40, 0.1, 9.3, 1.2),
                        new("Lime", "g", 30, 0.2, 10.5, 0.6),
                        new("Cilantro", "g", 23, 0.5, 3.7, 2.1),
                        new("Garlic", "g", 149, 0.5, 33.1, 6.3),
                        new("Salt", "g", 0, 0.0, 0.0, 0.0),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("Cut the avocados in half and remove the pit", 5, "min"),
                        new("Scoop the flesh into a bowl and mash with a fork", 2, "min"),
                        new("Add the tomato, onion, lime juice, cilantro, garlic, and salt", 2, "min"),
                        new("Mix until well combined", 1, "min")
                    }
                },
                new Recipe
                {
                    Author = 2,
                    Name = "Tacos",
                    Description = "A classic Mexican dish with seasoned meat, lettuce, and cheese",
                    Ingredients = new()
                    {
                        new("Ground Beef", "g", 250, 20.0, 0.0, 18.0),
                        new("Taco Seasoning", "g", 0, 0.0, 0.0, 0.0),
                        new("Taco Shells", "g", 480, 19.0, 66.0, 6.0),
                        new("Lettuce", "g", 15, 0.2, 2.9, 1.4),
                        new("Tomato", "g", 18, 0.2, 3.9, 0.9),
                        new("Cheddar Cheese", "g", 402, 33.0, 1.3, 25.0),
                    },
                    Quantity = new()
                    {
                        100,
                        100,
                        100,
                        100,
                        100,
                        100
                    },
                    Steps = new()
                    {
                        new("Cook the ground beef in a skillet over medium heat until browned", 10, "min"),
                        new("Add the taco seasoning and cook for 5 minutes", 5, "min"),
                        new("Heat the taco shells in the oven according to package instructions", 5, "min"),
                        new("Fill the taco shells with the beef, lettuce, tomato, and cheese", 2, "min")
                    }
                }


            );
            context.SaveChanges();
        };
    }
}

