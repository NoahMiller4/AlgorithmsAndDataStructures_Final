
// Algo Final Project -- Noah Miller

// creating dictionary for ingredients, along with their calories
Dictionary<string, int> ingredients = new Dictionary<string, int>
{
  { "Bread", 66 },

  { "Ham", 72 },
  { "Bologna", 57 },
  { "Chicken", 17 },
  { "Corned Beef", 53 },
  { "Salami", 40 },

  { "Cheese, American", 104 },
  { "Cheese, Cheddar", 113 },
  { "Cheese, Havarti", 105 },

  { "Mayonnaise", 94 },
  { "Mustard", 10 },
  { "Butter", 102 },
  { "Garlic Aioli", 100 },
  { "Sriracha", 15 },
  { "Dressing, Ranch", 73 },
  { "Dressing, 1000 Island", 59 },

  { "Lettuce", 5 },
  { "Tomato", 4 },
  { "Cucumber", 4 },
  { "Banana Pepper", 10 },
  { "Green Pepper", 3 },
  { "Red Onion", 6 },
  { "Spinach", 7 },
  { "Avocado", 64 }
};

// Ask User for min/max calories, and if they want to exclude ingredients
Console.WriteLine("Enter the minimum number of calories you would like in your sandwich:");
int minCalories = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the maximum number of calories you would like in your sandwich:");
int maxCalories = int.Parse(Console.ReadLine());

Console.WriteLine("Do you want to exclude any ingredients? (Separate multiple ingredients with commas)");

string exclude = Console.ReadLine();
// must store the input in a string array, split by commas to store all excluded 
// ingredients entered in the input
string[] excludedIngredients = exclude.Split(',');

Console.WriteLine();

// Validate calorie range, min cals can not be greater than max 
if (minCalories > maxCalories)
{
    Console.WriteLine("Minimum calories can't be greater than maximum calories.");
}
else
{
    // if calorie count is ok, start removing items from excludedIngredients input
    foreach (string ingredient in excludedIngredients)
    {
        ingredients.Remove(ingredient.Trim());
    }

    // must check to make sure bread is not excluded, check to see if ingredients doesn't
    // contain bread
    if (!ingredients.ContainsKey("Bread") || !ingredients.ContainsKey("Bread".ToLower()) || !ingredients.ContainsKey("Bread".ToUpper()))
    {
        Console.WriteLine("Sandwiches must include Bread.");
    }
    else
    {

    }
}