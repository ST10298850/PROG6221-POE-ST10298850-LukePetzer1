using NUnit.Framework;
using ST10298850_POE_LukePetzer.Classes;
using System.Collections.Generic;

namespace ST10298850_POE_LukePetzer.Classes
{
    [TestFixture]
    public class RecipeTests
    {
        private Recipe _recipe;

        [SetUp]
        public void Setup()
        {
            _recipe = new Recipe("Test Recipe");
            _recipe.Ingredients.Add(new RecipeIngredient("Ingredient1", 1, "unit", 100, "FoodGroup1"));
            _recipe.Ingredients.Add(new RecipeIngredient("Ingredient2", 2, "unit", 150, "FoodGroup2"));
        }

        [Test]
        public void CalculateTotalCalories_CaloriesLessThan300_DoesNotInvokeOnExceededCalories()
        {
            bool wasCalled = false;
            _recipe.OnExceededCalories += (message) => wasCalled = true;

            _recipe.CalculateTotalCalories();

            Assert.IsFalse(wasCalled);
        }

        [Test]
        public void CalculateTotalCalories_CaloriesGreaterThan300_InvokesOnExceededCalories()
        {
            bool wasCalled = false;
            _recipe.OnExceededCalories += (message) => wasCalled = true;

            _recipe.Ingredients.Add(new RecipeIngredient("Ingredient3", 3, "unit", 200, "FoodGroup3"));

            _recipe.CalculateTotalCalories();

            Assert.IsTrue(wasCalled);
        }

        [Test]
        public void TestCalculateTotalCalories()
        {
            // Act
            double totalCalories = _recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(250, totalCalories);
        }

        [Test]
        public void TestUpdateScale()
        {
            // Act
            _recipe.UpdateScale(2);

            // Assert
            Assert.AreEqual(2, _recipe.Ingredients[0].Quantity);
            Assert.AreEqual(4, _recipe.Ingredients[1].Quantity);
        }

        [Test]
        public void TestResetScale()
        {
            // Arrange
            _recipe.UpdateScale(2);

            // Act
            _recipe.ResetScale();

            // Assert
            Assert.AreEqual(1, _recipe.Ingredients[0].Quantity);
            Assert.AreEqual(2, _recipe.Ingredients[1].Quantity);
        }
    }
}
