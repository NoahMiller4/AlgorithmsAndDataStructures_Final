
// Algo Final Project -- Noah Miller

// creating dictionary for ingredients, along with their calories. set dictionary values as string, and int.
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
    if (!ingredients.ContainsKey("Bread") || 
        !ingredients.ContainsKey("Bread".ToLower()) || 
        !ingredients.ContainsKey("Bread".ToUpper())
        )
    {
        Console.WriteLine("Sandwiches must include Bread.");
    }
    else
    {

    }
}


// Function to make a sandwich within the given calorie range, set makeSandwich to list<string>
// to return a list of strings, and add inputs as paramaters
List<string> makeSandwich(Dictionary<string, int> ingredients, int minCalories, int maxCalories)
{
    // create an empty list to store sandwich ingredients
    List<string> sandwich = new List<string>();
    // initialize int variable to 0 so you can add values from sandwich ingredients
    int currentCalories = 0;

    // Add two slices of bread to sandwich and append calories from list
    sandwich.Add("Bread");
    sandwich.Add("Bread");
    currentCalories += ingredients["Bread"] * 2;

    // Iterate through the available ingredients/variables in variable list
    foreach (var ingredientVar in ingredients)
    {
        // access ingredients and calories through key and value of dictionary
        // link: https://www.tutorialsteacher.com/csharp/csharp-dictionary
        string ingredient = ingredientVar.Key;
        int calories = ingredientVar.Value;

        // add continue in loop to skip if the ingredient is bread, which is automatically added
        // or if it exceeds the maximum calories
        if (ingredient == "Bread" || currentCalories + calories > maxCalories)
            continue;

        // check to see if the added ingredient is not adjacent to itself
        // check to see if sandwich list has at least two items, compare last two items to added ingredient,
        // if value returns true, then item cannot be added, if so continue on and find another ingredient
        // set variable for sandwich count to stop redundancy
        int sandwichCount = sandwich.Count;
        if (sandwichCount >= 2 && sandwich[sandwichCount - 1] == ingredient && sandwich[sandwichCount - 2] == ingredient)
            continue;

        // if all validation is met, add ingredients to sandwich list, and append calories to current
        sandwich.Add(ingredient);
        currentCalories += calories;

        // Check if the calorie range is met, and end the iteration if so
        if (currentCalories >= minCalories && currentCalories <= maxCalories)
            break;
    }

    // return sandwich list of ingredients
    return sandwich;
}