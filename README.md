# PROG6221-POE-ST10298850-LukePetzer

## PROG6221 POE

# Recipe App

Greetings from the Recipe App! This program allows you to easily create, edit, and organize your recipes. With features such as scaling recipes, resetting scales, displaying complete recipe details, and calculating total calories, you can manage your culinary creations with ease.

## Prerequisites

Please ensure that Visual Studio is installed and functioning on your computer.

## Getting Started

1. Clone the repository to your local machine using the following command:
    ```sh
    git clone https://github.com/ST10298850/PROG6221-POE-ST10298850-LukePetzer1.git
    ```

2. Open the solution file (ST10298850_POE.sln) in Visual Studio.

3. Build the solution to compile the software.

4. Once the solution is built successfully, you can run the application by pressing F5 or clicking on the "Start" button in Visual Studio.

## Usage

### Adding a Recipe

When you launch the application, you will be prompted to add the name of your recipe, ingredients, and step descriptions. Follow the on-screen directions to enter the necessary data.

### Features

- **Add New Recipe:** Enter the name, ingredients (with quantities, units, calories, and food groups), and steps for your recipe.
- **Display All Recipes:** View a list of all recipes sorted alphabetically.
- **Select and Display Recipe:** Choose a recipe to view its details, including total calories and ingredient list.
- **Scale a Recipe:** Adjust the ingredient quantities based on a scaling factor (e.g., 0.5 for half, 2 for double).
- **Reset Recipe Scale:** Reset the ingredient quantities to their original values.
- **Calorie Calculation:** Automatically calculate and display the total calories for a recipe.
- **300-Calorie Alert:** Receive an alert if the total calories for a recipe exceed 300.

### Unit Tests

Unit tests are included to ensure the correct calculation of total calories. To run the unit tests:
1. Open the Test Explorer in Visual Studio.
2. Run all tests to verify that the application behaves as expected.

### Additional Information

- **Colored Display:** Recipe names are displayed in green for better visibility.
- **Sample Data:** The application includes sample recipes for testing purposes.

## Updates

1. Added sample data for testing purposes.
2. Implemented a delegate event to alert when calories exceed 300.
3. Improved recipe display with alphabetical sorting and colored text.
4. Added comprehensive unit tests for calorie calculation.
5. Refactored code for better readability and added comments.

## Conclusion

This Recipe App provides a user-friendly interface for managing recipes, including advanced features like scaling and calorie alerts. Follow the instructions above to set up and use the application effectively. Enjoy organizing your culinary creations!
