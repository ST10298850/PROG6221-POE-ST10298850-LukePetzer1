using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ST10298850_POE_LukePetzer.Classes;


namespace ST10298850_POE_LukePetzer.Classes
{
    // Class for representing a recipe

    public delegate void ExceededCaloriesHandler(string message);
    internal class Recipe
    {
        // Private fields
        public string Name { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        private double scaleAmount = 1;

        // Property for recipe name



        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<RecipeIngredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(RecipeIngredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(String step)
        {
            Steps.Add(step);
        }

        public void UpdateScale(double scale)
        {
            scaleAmount = scale;
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity * scaleAmount;
            }
        }
        public void ResetScale()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
            scaleAmount = 1;
        }

        public event ExceededCaloriesHandler OnExceededCalories;

        public double CalculateTotalCalories()
        {
            double totalCalories = Ingredients.Sum(ingredient => ingredient.Calories * ingredient.Quantity / ingredient.OriginalQuantity);
            if (totalCalories > 300)
            {
                OnExceededCalories?.Invoke("Warning: Total calories exceed 300!");
            }
            return totalCalories;
        }




        public string Display()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Recipe: {Name}");
            sb.AppendLine(new string('-', 20));
            sb.AppendLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.Unit} ({ingredient.Calories} calories) [{ingredient.FoodGroup}]");
            }
            sb.AppendLine(new string('-', 20));
            sb.AppendLine("Steps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {Steps[i]}");
            }
            sb.AppendLine(new string('-', 20));
            sb.AppendLine($"Total Calories: {CalculateTotalCalories()}");
            return sb.ToString();
        }


        // Property for number of ingredients


        //// Property for number of steps
        //public int IngredientNoSteps
        //{
        //    get { return ingredientNoSteps; }
        //    set { ingredientNoSteps = value; }
        //}

        //// Method to set ingredients
        //public void SetIngredients(Ingredient[] ingredients)
        //{
        //    this.ingredients = ingredients;
        //    this.NoOfIngredients = ingredients.Length;
        //}

        //// Method to set steps descriptions
        //public void SetStepsDescriptions(string[] stepsDescriptions)
        //{
        //    this.stepsDescriptions = stepsDescriptions;
        //    this.IngredientNoSteps = stepsDescriptions.Length;
        //}

        //// Method to update recipe scale
        //public void UpdateRecipeScale(double scaleAmount)
        //{
        //    this.scaleAmount = scaleAmount;
        //    foreach (Ingredient ingredient in ingredients)
        //    {
        //        ingredient.Quantity = ingredient.OriginalQuantity * scaleAmount;
        //    }
        //}

        //// Method to reset recipe scale
        //public void ResettingOfRecipeScale()
        //{
        //    this.scaleAmount = 1;
        //    foreach (Ingredient ingredient in ingredients)
        //    {
        //        ingredient.ResetQuantity();
        //    }
        //}

        //// Method to clear recipe
        //public void ClearRecipe()
        //{
        //    ingredients = null;
        //    stepsDescriptions = null;
        //}

        //// Method to display full recipe
        //public string DisplayRecipe()
        //{
        //    StringBuilder fullRecipeInformation = new StringBuilder();
        //    fullRecipeInformation.Append("\n------Recipe Details:------\n");
        //    fullRecipeInformation.Append($"{this.name}:\n\n------Ingredients:------\n");

        //    for (int i = 0; i < NoOfIngredients; i++)
        //    {
        //        fullRecipeInformation.Append($"{ingredients[i].Name} - {ingredients[i].Quantity} {ingredients[i].UnitOfMeasurement}\n");
        //    }

        //    fullRecipeInformation.Append("\n------Recipe Steps:------\n");

        //    for (int i = 0; i < IngredientNoSteps; i++)
        //    {
        //        fullRecipeInformation.Append($"Step {i + 1}: {stepsDescriptions[i]}\n");
        //    }
        //    return fullRecipeInformation.ToString();
        //}
    }
}
//------------------------------------EndOfFile-------------------------------------------------
