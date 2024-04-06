// See https://aka.ms/new-console-template for more information

using CookiesCookbook.Cookbook;
using CookiesCookbook.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;

namespace CookiesCookbook
{
    class Program
    {
        private static readonly Ingredient[] initialIngredients = [
                new Ingredient("Wheat flour", "Sieve. Add to other ingredients."),
                new Ingredient("Coconut flour", "Sieve. Add to other ingredients."),
                new Ingredient("Butter", "Melt on low heat. Add to other ingredients."),
                new Ingredient("Chocolate", "Melt in a water bath. Add to other ingredients."),
                new Ingredient("Sugar", "Add to other ingredients."),
                new Ingredient("Cardamom", "Take half a teaspoon. Add to other ingredients."),
                new Ingredient("Cinnamon", "Take half a teaspoon. Add to other ingredients."),
                new Ingredient("Cocoa powder", "Add to other ingredients."),
                ];

        private IngredientList ingredients = new(initialIngredients);
        private readonly string fileName = "recipes.txt";

        private StringsTextualRepository repository = new();
        private RecipeStoreText store;
        private Recipes recipes = new();

        public Program()
        {
            store = new(repository);
        }

        public void Main(string[] args)
        {
            GetStoredRecipes(fileName, recipes);
            PrintRecipes(recipes.GetAllRecipes(), ingredients);

            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
            ingredients.PrintMenu();

            int? id;
            Recipe recipe = new();
            do
            {
                id = InputIngredientId();
                if (id == null)
                {
                    break;
                }
                recipe.Add((int)id);


            } while (id != null);

            if (recipe.Count > 0)
            {
                recipes.Add(recipe);

                store.Write(fileName, recipes.GetAllRecipes());
            }

            Console.ReadLine();

        }

        /// <summary>
        /// Get ingredient id input from user
        /// </summary>
        /// <returns>valid ingredient id entered by the user, otherwise null</returns>
        private int? InputIngredientId()
        {
            string? input = UI.ReadInput("Add an ingredient by its ID or type anything else if finsihed. ");
            bool isInputNumeric = int.TryParse(input, out int id);
            if (!isInputNumeric || id < 1 || id > ingredients.Count)
            {
                return null;
            }
            return id;
        }

        /// <summary>
        /// Get receipes from file store<br/>Note: receipes is update in-place
        /// </summary>
        /// <param name="fileName">name of file store</param>
        /// <param name="recipes">receipes object to be populated</param>
        private void GetStoredRecipes(string fileName, Recipes recipes)
        {
            List<Recipe> storedRecipes = store.Read(fileName);
            foreach (Recipe storedRecipe in storedRecipes)
            {
                recipes.Add(storedRecipe);
            }
        }

        /// <summary>
        /// Print all recipes in recipes object
        /// </summary>
        /// <param name="recipes">object containing the recipes to be printed</param>
        /// <param name="ingredients">reference object allow conversion of ingredient id to ingredient description</param>
        private void PrintRecipes(List<Recipe> recipes, IngredientList ingredients)
        {
            if (recipes.Count > 0)
            {
                Console.WriteLine("Existing recipes are:\n");
            }

            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"***** {i + 1} *****");

                foreach (int id in recipes[i].GetAllIngredientIds())
                {
                    Console.WriteLine(ingredients.Get(id).ToString());
                }

                Console.WriteLine();
            }
        }
    }

}












