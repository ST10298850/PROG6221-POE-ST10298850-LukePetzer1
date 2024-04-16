using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ST10298850_POE_LukePetzer.Classes.Ingredient;
using System.Xml.Linq;

namespace ST10298850_POE_LukePetzer.Classes
{
    // Class for representing a recipe
    internal class Recipe
    {
        // Private fields
        private string name;
        private Ingredient[] ingredients;
        private string[] stepsDescriptions;
        private double scaleAmount = 1;
        private int noOfIngredients;
        private int ingredientNoSteps;

        // Property for recipe name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property for number of ingredients
        public int NoOfIngredients
        {
            get { return noOfIngredients; }
            set { noOfIngredients = value; }
        }

        // Property for number of steps
        public int IngredientNoSteps
        {
            get { return ingredientNoSteps; }
            set { ingredientNoSteps = value; }
        }

        // Method to set ingredients
        public void SetIngredients(Ingredient[] ingredients)
        {
            this.ingredients = ingredients;
            this.NoOfIngredients = ingredients.Length; // Set the NoOfIngredients property
        }

        // Method to set steps descriptions
        public void SetStepsDescriptions(string[] stepsDescriptions)
        {
            this.stepsDescriptions = stepsDescriptions;
            this.IngredientNoSteps = stepsDescriptions.Length; // Set the IngredientNoSteps property
        }

        // Method to update recipe scale
        public void UpdateRecipeScale(double scaleAmount)
        {
            this.scaleAmount = scaleAmount;
            //foreach (Ingredient ingredient in ingredients)
            //{
            //    //ingredient.Quantity *= scaleAmount;
            //}
        }

        // Method to reset recipe scale
        public void ResettingOfRecipeScale()
        {
            scaleAmount = 1;
        }

        // Method to clear recipe
        public void clearRecipe()
        {
            ingredients = null; // Clear the ingredients array
            stepsDescriptions = null; // Clear the stepsDescriptions array
        }

        // Method to display full recipe
        public string DisplayRecipe()
        {
            String fullRecipeInformation = "";
            fullRecipeInformation += ("\n------Recipe Details:------");
            fullRecipeInformation += ("\n------" + this.name + ":------");
            fullRecipeInformation += ("\n\n------Ingredients:------");
            for (int step = 0; step < NoOfIngredients; step++)
            {
                fullRecipeInformation += ("\n" + ingredients[step].Name + " - " + ingredients[step].Quantity * scaleAmount + " " + ingredients[step].UnitOfMeasurement);
            }

            fullRecipeInformation += ("\n\n------Recipe Setps:------");

            for (int step = 0; step < IngredientNoSteps; step++)
            {
                fullRecipeInformation += ("\n" + stepsDescriptions[step]);
            }
            return fullRecipeInformation;
        }

    }
}
