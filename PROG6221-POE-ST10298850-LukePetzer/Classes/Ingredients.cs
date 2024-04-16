using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10298850_POE_LukePetzer.Classes
{
    // Class for representing an ingredient
    internal class Ingredient
    {
        // Private fields
        private string name;
        private double quantity;
        private string unitOfMeasurement;
        private double scaleAmount;

        // Constructor
        public Ingredient(string name, double quantity, string unitOfMeasurement)
        {
            this.name = name;
            this.quantity = quantity;
            this.unitOfMeasurement = unitOfMeasurement;
        }

       

    }
}

