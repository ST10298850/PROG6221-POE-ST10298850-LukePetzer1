using System;

namespace ST10298850_POE_LukePetzer.Classes
{
    // Class for representing an ingredient
    internal class Ingredient
    {
        // Private fields
        private string name;
        private double quantity;
        private string unitOfMeasurement;
        private double originalQuantity;

        // Constructor
        public Ingredient(string name, double quantity, string unitOfMeasurement)
        {
            this.name = name;
            this.quantity = quantity;
            this.unitOfMeasurement = unitOfMeasurement;
            this.originalQuantity = quantity;
        }

        // Property for ingredient name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property for ingredient quantity
        public double Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        // Property for ingredient unit of measurement
        public string UnitOfMeasurement
        {
            get { return unitOfMeasurement; }
            set { unitOfMeasurement = value; }
        }

        // Property for original ingredient quantity
        public double OriginalQuantity
        {
            get { return originalQuantity; }
        }

        // Method to reset quantity to the original value
        public void ResetQuantity()
        {
            this.quantity = originalQuantity;
        }
    }
}
//------------------------------------EndOfFile-------------------------------------------------
