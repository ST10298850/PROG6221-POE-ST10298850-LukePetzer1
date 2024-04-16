// See https://aka.ms/new-console-template for more information
using ST10298850_POE_LukePetzer.Classes;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ST10298850_POE
{
    // Main program class
    class Program
    {
        // Declare a static instance of the Recipe class
        private static Recipe Recipe = new Recipe();

        // Main method
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Welcome to the Recipe App!");

            // Retrieve the values entered by the user
            Console.WriteLine("Please enter a name for your recipe.");
            Recipe.Name = Console.ReadLine();
            Recipe.SetIngredients(getIngredientFromUser());
            Recipe.SetStepsDescriptions(getStepsDescriptionsFromUser());
            DisplayFullRecipe();


            bool loopContinue = true;
            // Loop to continue displaying options until user chooses to exit
            while (loopContinue)
            {
                // Prompt user for choice
                Console.WriteLine("Please select what option you would like to enter.");
                Console.WriteLine("\n 0. - To change the recipe scale. \n 1. - To reset the recipe scale back to the orignal. \n 2. Make a new Recipe.\n3. Display recipe \n 4. Exit program.");
                int switchChoice = int.Parse(Console.ReadLine());

                // Switch statement to handle user choice
                switch (switchChoice)
                {
                    case 0:
                        changeRecipeSize();
                        DisplayFullRecipe();
                        break;
                    case 1:
                        resettingOfRecipeScale();
                        DisplayFullRecipe();
                        break;
                    case 2:
                        Recipe.clearRecipe();
                        Console.WriteLine("Please enter a name for your recipe.");
                        Recipe.Name = Console.ReadLine();
                        Recipe.SetIngredients(getIngredientFromUser());
                        Recipe.SetStepsDescriptions(getStepsDescriptionsFromUser());
                        break;
                    case 3:
                        DisplayFullRecipe();
                        break;
                    case 4:
                        loopContinue = false;
                        break;
                    default:
                        loopContinue = true;
                        break;
                }
                if (loopContinue)
                    Console.WriteLine("Please enter a valid choice.");
            }
        }        // Method to get ingredients from user input
        private static Ingredient[] getIngredientFromUser()
        {
            Console.WriteLine("Please indicate how many ingredients this recipe contains.");
            int noOfIngredients = int.Parse(Console.ReadLine());

            Ingredient[] ingredients = new Ingredient[noOfIngredients];

            for (int i = 0; i < noOfIngredients; i++)
            {
                Console.WriteLine("Please indicate the name of the ingredient.");
                string ingredientName = Console.ReadLine();
                Console.WriteLine("Please indicate the quantity of the ingredient.");
                double ingredientQuantity = double.Parse(Console.ReadLine());
                Console.WriteLine("Please indicate the unit of measurement of the ingredient.");
                string ingredientUnitofMeasurement = Console.ReadLine();

                ingredients[i] = new Ingredient(ingredientName, ingredientQuantity, ingredientUnitofMeasurement);
            }

            return ingredients;
        }

        // Method to get steps descriptions from user input
        private static string[] getStepsDescriptionsFromUser()
        {
            Console.WriteLine("Please indicate the number of steps the recipe contains.");
            int ingredientNoSteps = int.Parse(Console.ReadLine());

            string[] stepsDescriptions = new string[ingredientNoSteps];

            for (int j = 0; j < ingredientNoSteps; j++)
            {
                Console.WriteLine($"Please provide a description of step {j + 1}");
                stepsDescriptions[j] = Console.ReadLine();
            }

            return stepsDescriptions;
        }

    }
