using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ST10298850_POE_LukePetzer.Classes;

namespace ST10298850_POE.Tests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void TestCalculateTotalCalories()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new RecipeIngredient("Ingredient 1", 100, "g", 200, "Food Group 1"));
            recipe.Ingredients.Add(new RecipeIngredient("Ingredient 2", 200, "g", 300, "Food Group 2"));

            // Act
            double totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(500, totalCalories);
        }

        [TestMethod]
        public void TestUpdateScale()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new RecipeIngredient("Ingredient 1", 100, "g", 200, "Food Group 1"));
            recipe.Ingredients.Add(new RecipeIngredient("Ingredient 2", 200, "g", 300, "Food Group 2"));

            // Act
            recipe.UpdateScale(2);

            // Assert
            Assert.AreEqual(200, recipe.Ingredients[0].Quantity);
            Assert.AreEqual(400, recipe.Ingredients[1].Quantity);
        }

        [TestMethod]
        public void TestResetScale()
        {
            // Arrange
            var recipe = new Recipe("Test Recipe");
            recipe.Ingredients.Add(new RecipeIngredient("Ingredient 1", 100, "g", 200, "Food Group 1"));
            recipe.Ingredients.Add(new RecipeIngredient("Ingredient 2", 200, "g", 300, "Food Group 2"));
            recipe.UpdateScale(2);

            // Act
            recipe.ResetScale();

            // Assert
            Assert.AreEqual(100, recipe.Ingredients[0].Quantity);
            Assert.AreEqual(200, recipe.Ingredients[1].Quantity);
        }
    }
}

