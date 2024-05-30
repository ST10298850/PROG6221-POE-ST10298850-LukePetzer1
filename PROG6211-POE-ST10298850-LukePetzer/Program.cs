using ST10298850_POE_LukePetzer.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ST10298850_POE
{
    class Program
    {
        // List to store all recipes
        private static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            // Initialize sample data
            PopulateSampleData();

            // Main loop for the menu
            while (true)
            {
                Console.Clear();

                // Display menu options
                Console.WriteLine("1. Add a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select and display a recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset a recipe scale");
                Console.WriteLine("6. Information about food groups:");
                Console.WriteLine("7. Exit");

                int choice;
                // Read and parse user input
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                // Execute corresponding actions based on user choice
                switch (choice)
                {
                    case 1:
                        AddNewRecipe();
                        Console.ReadLine();
                        break;
                    case 2:
                        DisplayAllRecipes();
                        Console.ReadLine();
                        break;
                    case 3:
                        DisplayAllRecipeNames();
                        SelectAndDisplayRecipe();
                        Console.ReadLine();
                        break;
                    case 4:
                        DisplayAllRecipeNames();
                        ScaleSelectedRecipe();
                        Console.ReadLine();
                        break;
                    case 5:
                        DisplayAllRecipeNames();
                        ResetSelectedRecipeScale();
                        Console.ReadLine();
                        break;
                    case 6:
                        DisplayFoodGroupsInfo();
                        Console.ReadLine();
                        break;
                    case 7:
                        // Confirm exit
                        Console.WriteLine("Are you sure you want to exit? (yes/no)");
                        string response = Console.ReadLine();
                        if (response.ToLower() == "yes")
                        {
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }
            }
        }

        // Method to initialize sample data
        private static void PopulateSampleData()
        {
            var recipe1 = new Recipe("Spaghetti Bolognese");
            recipe1.Ingredients.Add(new RecipeIngredient("Spaghetti", 200, "g", 300, "Grains"));
            recipe1.Ingredients.Add(new RecipeIngredient("Minced Beef", 250, "g", 500, "Protein"));
            recipe1.Ingredients.Add(new RecipeIngredient("Tomato Sauce", 150, "ml", 80, "Vegetable"));
            recipe1.Steps.Add("Boil spaghetti.");
            recipe1.Steps.Add("Cook minced beef until brown.");
            recipe1.Steps.Add("Add tomato sauce and simmer for 10 minutes.");
            recipes.Add(recipe1);

            var recipe2 = new Recipe("Caesar Salad");
            recipe2.Ingredients.Add(new RecipeIngredient("Romaine Lettuce", 100, "g", 20, "Vegetable"));
            recipe2.Ingredients.Add(new RecipeIngredient("Croutons", 50, "g", 200, "Grains"));
            recipe2.Ingredients.Add(new RecipeIngredient("Caesar Dressing", 30, "ml", 150, "Dairy"));
            recipe2.Steps.Add("Chop the romaine lettuce.");
            recipe2.Steps.Add("Add croutons and Caesar dressing.");
            recipes.Add(recipe2);

            var recipe3 = new Recipe("Pancakes");
            recipe3.Ingredients.Add(new RecipeIngredient("Flour", 200, "g", 730, "Grains"));
            recipe3.Ingredients.Add(new RecipeIngredient("Milk", 300, "ml", 150, "Dairy"));
            recipe3.Ingredients.Add(new RecipeIngredient("Egg", 2, "pcs", 140, "Protein"));
            recipe3.Steps.Add("Mix flour, milk, and eggs.");
            recipe3.Steps.Add("Pour batter onto a hot griddle.");
            recipe3.Steps.Add("Cook until golden brown on both sides.");
            recipes.Add(recipe3);
        }

        // Method to add a new recipe
        public static void AddNewRecipe()
        {
            Console.WriteLine("Enter the name of the recipe:");
            string name = Console.ReadLine();
            Recipe recipe = new Recipe(name);
            recipe.OnExceededCalories += HandleExceededCalories; // Subscribe to the event

            Console.WriteLine("Enter the number of ingredients:");
            recipe.Ingredients.AddRange(GetIngredientsFromUser());

            Console.WriteLine("Enter the number of steps:");
            recipe.Steps.AddRange(GetStepsFromUser());

            recipes.Add(recipe);
        }

        // Method to get ingredients from the user
        private static List<RecipeIngredient> GetIngredientsFromUser()
        {
            List<RecipeIngredient> ingredients = new List<RecipeIngredient>();

            int count;
            if (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return ingredients;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Ingredient {i + 1} name:");
                string name = Console.ReadLine();

                Console.WriteLine("Quantity:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine("Unit:");
                string unit = Console.ReadLine();

                Console.WriteLine("Calories:");
                double calories = double.Parse(Console.ReadLine());

                Console.WriteLine("Select a food group:");
                Console.WriteLine("1. Starchy Foods");
                Console.WriteLine("2. Vegetables and Fruits");
                Console.WriteLine("3. Dry Beans, Peas, Lentils, and Soya");
                Console.WriteLine("4. Chicken, Fish, Meat, and Eggs");
                Console.WriteLine("5. Milk and Dairy Products");
                Console.WriteLine("6. Fats and Oils");
                Console.WriteLine("7. Water");

                string foodGroup;
                switch (Console.ReadLine())
                {
                    case "1":
                        foodGroup = "Starchy Foods";
                        break;
                    case "2":
                        foodGroup = "Vegetables and Fruits";
                        break;
                    case "3":
                        foodGroup = "Dry Beans, Peas, Lentils, and Soya";
                        break;
                    case "4":
                        foodGroup = "Chicken, Fish, Meat, and Eggs";
                        break;
                    case "5":
                        foodGroup = "Milk and Dairy Products";
                        break;
                    case "6":
                        foodGroup = "Fats and Oils";
                        break;
                    case "7":
                        foodGroup = "Water";
                        break;
                    default:
                        Console.WriteLine("Invalid option. Defaulting to 'Starchy Foods'.");
                        foodGroup = "Starchy Foods";
                        break;
                }

                ingredients.Add(new RecipeIngredient(name, quantity, unit, calories, foodGroup));
            }

            return ingredients;
        }

        // Method to display information about food groups
        private static void DisplayFoodGroupsInfo()
        {
            Console.WriteLine("Information about food groups:");
            Console.WriteLine();

            Console.WriteLine("1. Starchy Foods:");
            Console.WriteLine("- Pap");
            Console.WriteLine("- Samp");
            Console.WriteLine("- Brown rice");
            Console.WriteLine("- Potatoes");
            Console.WriteLine("- Whole wheat bread");
            Console.WriteLine("- Whole wheat pasta");
            Console.WriteLine();

            Console.WriteLine("2. Vegetables and Fruits:");
            Console.WriteLine("- Apple, Pear, Peach, Orange, Mango");
            Console.WriteLine("- Cabbage, Pumpkin, Carrots, Spinach, Broccoli, Cauliflower, Tomato");
            Console.WriteLine();

            Console.WriteLine("3. Dry Beans, Peas, Lentils, and Soya:");
            Console.WriteLine("- Chickpeas");
            Console.WriteLine("- Kidney beans");
            Console.WriteLine("- Green peas");
            Console.WriteLine("- Black beans");
            Console.WriteLine("- Soy beans");
            Console.WriteLine("- Split peas");
            Console.WriteLine();

            Console.WriteLine("4. Chicken, Fish, Meat, and Eggs:");
            Console.WriteLine("- Skinless chicken");
            Console.WriteLine("- Lean meat");
            Console.WriteLine("- Mince");
            Console.WriteLine("- Canned fish");
            Console.WriteLine("- Frozen fish");
            Console.WriteLine();

            Console.WriteLine("5. Milk and Dairy Products:");
            Console.WriteLine("- Low fat milk");
            Console.WriteLine("- Cottage cheese");
            Console.WriteLine("- Plain yoghurt");
            Console.WriteLine("- Amasi");
            Console.WriteLine();

            Console.WriteLine("6. Fats and Oils:");
            Console.WriteLine("- Avocado");
            Console.WriteLine("- Olive oil");
            Console.WriteLine("- Nuts and seeds");
            Console.WriteLine("- Flax seed");
            Console.WriteLine();

            Console.WriteLine("7. Water:");
            Console.WriteLine("- Drink 6 to 8 glasses of water daily.");
            Console.WriteLine();
        }

        // Method to display all recipe names
        private static void DisplayAllRecipeNames()
        {
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All recipe names (sorted alphabetically):");
            Console.ResetColor();

            foreach (var recipe in sortedRecipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        // Method to get steps from the user
        private static List<String> GetStepsFromUser()
        {
            List<String> steps = new List<String>();

            int count;
            if (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                return steps;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Step {i + 1}:");
                steps.Add(Console.ReadLine());
            }

            return steps;
        }

        // Method to display all recipes
        private static void DisplayAllRecipes()
        {
            var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All recipes (sorted alphabetically):");
            Console.ResetColor();

            foreach (var recipe in sortedRecipes)
            {
                double totalCalories = recipe.Ingredients.Sum(i => i.Calories);
                if (totalCalories > 300)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(recipe.Display());
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // Method to select and display a specific recipe
        private static void SelectAndDisplayRecipe()
        {
            Console.WriteLine("Existing recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }

            Console.WriteLine("Enter the name of the recipe to display:");
            string name = Console.ReadLine();

            Recipe selectedRecipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe != null)
            {
                selectedRecipe.OnExceededCalories += HandleExceededCalories;
                Console.WriteLine(selectedRecipe.Display());
                selectedRecipe.CalculateTotalCalories();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to scale a selected recipe
        private static void ScaleSelectedRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to scale:");
            string name = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                Console.WriteLine("Enter the scale factor (0.5 for half, 2 for double, 3 for triple):");
                double scaleAmount = double.Parse(Console.ReadLine());

                recipe.UpdateScale(scaleAmount);
                Console.WriteLine("Recipe scaled successfully.");
                Console.WriteLine(recipe.Display());
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Method to reset the scale of a selected recipe
        private static void ResetSelectedRecipeScale()
        {
            Console.WriteLine("Enter the name of the recipe to reset the scale:");
            string name = Console.ReadLine();

            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (recipe != null)
            {
                recipe.ResetScale();
                Console.WriteLine("Recipe scale reset successfully.");
                Console.WriteLine(recipe.Display());
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Event handler for exceeded calories event
        private static void HandleExceededCalories(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine("High calorie intake can lead to weight gain, high blood pressure, and other health issues. Please consider this when preparing your meals.");
            Console.ResetColor();
        }
    }
}

//----------------------------------------------------------------------------------------REFERENCES--------------------------------------------------------------------------------------------
//C# Tutorial (C Sharp). (n.d.). Retrieved May 27, 2024, from https://www.w3schools.com/cs/index.php 

//Chand, M. (2023, April 2). How to create a list in C#? Retrieved May 28, 2024, from https://www.c-sharpcorner.com/UploadFile/mahesh/create-a-list-in-C-Sharp/

//Sort a list alphabetically. (2021, February). Stack Overflow. Retrieved May 29, 2024, from https://stackoverflow.com/questions/6965337/sort-a-list-alphabetically

//----------------------------------------------------------------------------------------REFERENCES--------------------------------------------------------------------------------------------


// Method to display full recipe
//private static void DisplayFullRecipe()
//{
//    Console.ForegroundColor = ConsoleColor.Yellow;
//    Console.WriteLine(recipe.DisplayRecipe());
//    Console.ResetColor();
//}

//Method to change recipe size
//public static void ChangeRecipeSize()
//{
//    Console.WriteLine("Please indicate to what scale you would like to change the recipe:");
//    Console.WriteLine("Enter 0.5 for half, 2 for double, or 3 for triple.");

//    if (!double.TryParse(Console.ReadLine(), out double scaleAmount) || (scaleAmount != 0.5 && scaleAmount != 2 && scaleAmount != 3))
//    {
//        Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3.");
//        return;
//    }

//    recipe.UpdateRecipeScale(scaleAmount);
//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine($"Recipe scaled by a factor of {scaleAmount}.");
//    Console.ResetColor();
//}

//Method to reset recipe scale
//public static void ResettingOfRecipeScale()
//{
//    recipe.ResettingOfRecipeScale();
//    Console.ForegroundColor = ConsoleColor.Green;
//    Console.WriteLine("Recipe scale reset to the original.");
//    Console.ResetColor();
//}

//private static bool ConfirmRecipeDeletion()
//{
//    Console.WriteLine("Please confirm you would like to delete the existing recipe.");
//    Console.WriteLine("Enter 'yes' to confirm or 'no' to cancel.");

//    string userInputConfirmation = Console.ReadLine().ToLower();

//    if (userInputConfirmation == "yes")
//    {
//        recipe.ClearRecipe();
//        return true;
//    }
//    else if (userInputConfirmation == "no")
//    {
//        Console.WriteLine("Operation cancelled. Recipe not cleared.");
//        return false;
//    }
//    else
//    {
//        Console.WriteLine("Invalid input. Please enter 'yes' to confirm or 'no' to cancel.");
//        return ConfirmRecipeDeletion();
//    }
//}
//------------------------------------EndOfFile------------------------------------------------ -

