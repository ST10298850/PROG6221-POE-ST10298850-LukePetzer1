using ST10298850_POE_LukePetzer.Classes;
using System;

namespace ST10298850_POE
{
    // Main program class
    class Program
    {
        // Declare a static instance of the Recipe class
        private static Recipe recipe = new Recipe();

        // Main method
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Recipe App!");

            Console.WriteLine("Please enter a name for your recipe.");
            recipe.Name = Console.ReadLine();

            recipe.SetIngredients(GetIngredientsFromUser());
            recipe.SetStepsDescriptions(GetStepsDescriptionsFromUser());

            DisplayFullRecipe();

            bool loopContinue = true;
            while (loopContinue)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("0. Change recipe scale");
                Console.WriteLine("1. Reset recipe scale");
                Console.WriteLine("2. Make a new Recipe");
                Console.WriteLine("3. Display recipe");
                Console.WriteLine("4. Exit program");

                if (!int.TryParse(Console.ReadLine(), out int switchChoice))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 4.");
                    continue;
                }

                switch (switchChoice)
                {
                    case 0:
                        ChangeRecipeSize();
                        DisplayFullRecipe();
                        break;
                    case 1:
                        ResettingOfRecipeScale();
                        DisplayFullRecipe();
                        break;
                    case 2:
                        if (ConfirmRecipeDeletion())
                        {
                            recipe.Name = string.Empty;
                            recipe.ClearRecipe();
                            Console.WriteLine("Please enter a name for your new recipe.");
                            recipe.Name = Console.ReadLine();
                            recipe.SetIngredients(GetIngredientsFromUser());
                            recipe.SetStepsDescriptions(GetStepsDescriptionsFromUser());
                            DisplayFullRecipe();
                        }
                        break;
                    case 3:
                        DisplayFullRecipe();
                        break;
                    case 4:
                        loopContinue = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 0 and 4.");
                        break;
                }
            }
        }

        // Method to get ingredients from user input
        private static Ingredient[] GetIngredientsFromUser()
        {
            Console.WriteLine("Please indicate how many ingredients this recipe contains.");
            if (!int.TryParse(Console.ReadLine(), out int noOfIngredients))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return GetIngredientsFromUser();
            }

            Ingredient[] ingredients = new Ingredient[noOfIngredients];

            for (int i = 0; i < noOfIngredients; i++)
            {
                Console.WriteLine("Please indicate the name of the ingredient.");
                string ingredientName = Console.ReadLine();

                Console.WriteLine("Please indicate the quantity of the ingredient.");
                if (!double.TryParse(Console.ReadLine(), out double ingredientQuantity))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    i--;
                    continue;
                }

                Console.WriteLine("Please indicate the unit of measurement of the ingredient.");
                string ingredientUnitOfMeasurement = Console.ReadLine();

                ingredients[i] = new Ingredient(ingredientName, ingredientQuantity, ingredientUnitOfMeasurement);
            }

            return ingredients;
        }

        // Method to get steps descriptions from user input
        private static string[] GetStepsDescriptionsFromUser()
        {
            Console.WriteLine("Please indicate the number of steps the recipe contains.");
            if (!int.TryParse(Console.ReadLine(), out int ingredientNoSteps))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return GetStepsDescriptionsFromUser();
            }

            string[] stepsDescriptions = new string[ingredientNoSteps];

            for (int j = 0; j < ingredientNoSteps; j++)
            {
                Console.WriteLine($"Please provide a description of step {j + 1}");
                stepsDescriptions[j] = Console.ReadLine();
            }

            return stepsDescriptions;
        }

        // Method to display full recipe
        private static void DisplayFullRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(recipe.DisplayRecipe());
            Console.ResetColor();
        }

        // Method to change recipe size
        public static void ChangeRecipeSize()
        {
            Console.WriteLine("Please indicate to what scale you would like to change the recipe:");
            Console.WriteLine("Enter 0.5 for half, 2 for double, or 3 for triple.");

            if (!double.TryParse(Console.ReadLine(), out double scaleAmount) || (scaleAmount != 0.5 && scaleAmount != 2 && scaleAmount != 3))
            {
                Console.WriteLine("Invalid input. Please enter 0.5, 2, or 3.");
                return;
            }

            recipe.UpdateRecipeScale(scaleAmount);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Recipe scaled by a factor of {scaleAmount}.");
            Console.ResetColor();
        }

        // Method to reset recipe scale
        public static void ResettingOfRecipeScale()
        {
            recipe.ResettingOfRecipeScale();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipe scale reset to the original.");
            Console.ResetColor();
        }

        private static bool ConfirmRecipeDeletion()
        {
            Console.WriteLine("Please confirm you would like to delete the existing recipe.");
            Console.WriteLine("Enter 'yes' to confirm or 'no' to cancel.");

            string userInputConfirmation = Console.ReadLine().ToLower();

            if (userInputConfirmation == "yes")
            {
                recipe.ClearRecipe();
                return true;
            }
            else if (userInputConfirmation == "no")
            {
                Console.WriteLine("Operation cancelled. Recipe not cleared.");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'yes' to confirm or 'no' to cancel.");
                return ConfirmRecipeDeletion();
            }
        }
    }
}
//------------------------------------EndOfFile-------------------------------------------------

