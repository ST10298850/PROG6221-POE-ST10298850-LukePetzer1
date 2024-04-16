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

        

    }
}
