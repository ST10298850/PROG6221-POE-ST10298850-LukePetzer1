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
        }
