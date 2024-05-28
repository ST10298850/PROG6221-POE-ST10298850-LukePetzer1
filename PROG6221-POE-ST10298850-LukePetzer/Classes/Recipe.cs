using System;
using System.Text;

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
            this.NoOfIngredients = ingredients.Length;
        }

        // Method to set steps descriptions
        public void SetStepsDescriptions(string[] stepsDescriptions)
        {
            this.stepsDescriptions = stepsDescriptions;
            this.IngredientNoSteps = stepsDescriptions.Length;
        }

        // Method to update recipe scale
        public void UpdateRecipeScale(double scaleAmount)
        {
            this.scaleAmount = scaleAmount;
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity * scaleAmount;
            }
        }

        // Method to reset recipe scale
        public void ResettingOfRecipeScale()
        {
            this.scaleAmount = 1;
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        // Method to clear recipe
        public void ClearRecipe()
        {
            ingredients = null;
            stepsDescriptions = null;
        }

        // Method to display full recipe
        public string DisplayRecipe()
        {
            StringBuilder fullRecipeInformation = new StringBuilder();
            fullRecipeInformation.Append("\n------Recipe Details:------\n");
            fullRecipeInformation.Append($"{this.name}:\n\n------Ingredients:------\n");

            for (int i = 0; i < NoOfIngredients; i++)
            {
                fullRecipeInformation.Append($"{ingredients[i].Name} - {ingredients[i].Quantity} {ingredients[i].UnitOfMeasurement}\n");
            }

            fullRecipeInformation.Append("\n------Recipe Steps:------\n");

            for (int i = 0; i < IngredientNoSteps; i++)
            {
                fullRecipeInformation.Append($"Step {i + 1}: {stepsDescriptions[i]}\n");
            }
            return fullRecipeInformation.ToString();
        }
    }
}
//------------------------------------EndOfFile-------------------------------------------------
