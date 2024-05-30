using System;

namespace ST10298850_POE_LukePetzer.Classes
{
    public class RecipeIngredient
    {

        public RecipeIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Unit = unit; // Changed from unitOfMeasurement to Unit
            this.OriginalQuantity = quantity;
            this.Calories = calories;
            this.FoodGroup = foodGroup;
        }

        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } // Changed from UnitOfMeasurement to Unit
        public double OriginalQuantity { get; private set; } // Added private set to allow setting in constructor
        public double Calories { get; set; }
        public string FoodGroup { get; set; }

        public void ResetQuantity()
        {
            this.Quantity = OriginalQuantity; // Changed from quantity to Quantity
        }
    }

}
//------------------------------------EndOfFile-------------------------------------------------