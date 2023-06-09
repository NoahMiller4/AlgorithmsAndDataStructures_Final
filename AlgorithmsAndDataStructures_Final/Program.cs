
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
    // Create a copy of the ingredients dictionary
    Dictionary<string, int> availableIngredients = new Dictionary<string, int>(ingredients);

    // Remove the excluded ingredients from the availableIngredients dictionary
    foreach (string ingredient in excludedIngredients)
    {
        string trimmedIngredient = ingredient.Trim();
        if (availableIngredients.ContainsKey(trimmedIngredient))
        {
            availableIngredients.Remove(trimmedIngredient);
        }
    }

    // Check if "Bread" is present in availableIngredients dictionary
    if (!availableIngredients.ContainsKey("Bread"))
    {
        Console.WriteLine("Sandwiches must include Bread.");
    }
    else
    {
        // Create a sandwich in the given calorie range
        List<string> sandwich = makeSandwich(availableIngredients, minCalories, maxCalories);

        if (sandwich.Count == 0)
        {
            Console.WriteLine("Unable to create a sandwich within the calorie range.");
        }
        else
        {
            Console.WriteLine("Making your sandwich");
            Console.WriteLine();

            // console write each ingredient and its calorie count
            foreach (string ingredient in sandwich)
            {
                Console.WriteLine("Adding " + ingredient + " (" + ingredients[ingredient] + " calories)");
            }

            // create total calories and use sum to calculate the total as to not use iteration to count everything.
            int totalCalories = sandwich.Sum(ingredient => ingredients[ingredient]);

            Console.WriteLine();
            Console.WriteLine("Your sandwich, with " + totalCalories + " calories, is ready. Enjoy!");
        }
    }
}

// Function to make a sandwich within the given calorie range, set makeSandwich to list<string>
// to return a list of strings, and add inputs as parameters
List<string> makeSandwich(Dictionary<string, int> ingredients, int minCalories, int maxCalories)
{
    // create an empty list to store sandwich ingredients
    List<string> sandwich = new List<string>();
    // initialize int variable to 0 so you can add values from sandwich ingredients
    int currentCalories = 0;

    // Check if "Bread" is present in ingredients dictionary
    if (ingredients.ContainsKey("Bread"))
    {
        // Add two slices of bread to sandwich and append calories from list
        sandwich.Add("Bread");
        sandwich.Add("Bread");
        currentCalories += ingredients["Bread"] * 2;

        // Remove "Bread" from available ingredients
        ingredients.Remove("Bread");
    }

    // creating a list of ingredients that does not contain bread
    List<string> availableIngredients = new List<string>(ingredients.Keys);

    // initialize variable fro index of ingredient
    int ingredientIndex = 0;

    // iterate through until reaching the maximum calorie count or no more available ingredients
    // if ingredients run out, print total
    while (currentCalories < maxCalories && availableIngredients.Count > 0)
    {
        // create ingredient string of available ingredients at index 0
        string ingredient = availableIngredients[ingredientIndex];

        // Check if adding the ingredient goes over maximum calorie count
        if (currentCalories + ingredients[ingredient] > maxCalories)
        {
            // Move to the next ingredient with modulus of list index length
            ingredientIndex = (ingredientIndex + 1) % availableIngredients.Count;
            continue;
        }

        // Add the ingredient to the sandwich and append calories
        sandwich.Add(ingredient);
        currentCalories += ingredients[ingredient];

        // Move to the next ingredient
        ingredientIndex = (ingredientIndex + 1) % availableIngredients.Count;
    }

    // return sandwich list of ingredients
    return sandwich;
}
    