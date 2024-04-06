// See https://aka.ms/new-console-template for more information

using CookiesCookbook.Cookbook;

namespace CookiesCookbook.IO
{
    public class RecipeStoreText : IRecipeStore
    {
        private StringsTextualRepository _repository;
        public RecipeStoreText(StringsTextualRepository repository)
        {
            _repository = repository;
        }
        public List<Recipe> Read(string fileName)
        {
            List<string> recipeStrings;
            try 
            {
                recipeStrings = _repository.Read(fileName);
            } catch (FileNotFoundException)
            {
                return [];
            }

            List<Recipe> recipes = [];
            foreach (string recipeString in recipeStrings)
            {
                Recipe recipe = new();
                foreach (string indexString in recipeString.Split(", "))
                {
                    if (int.TryParse(indexString, out var index))
                    {
                        recipe.Add(index);
                    }
                }

                if (recipe.Count > 0)
                {
                    recipes.Add(recipe);
                }
            }
            return recipes;
        }

        public void Write(string fileName, List<Recipe> recipes)
        {
            List<string> recipeStrings = [];

            // convert each recipe to a string of indexes and then write them to the repository
            foreach (Recipe recipe in recipes)
            {
                recipeStrings.Add(recipe.ToString());
            }
            _repository.Write(fileName, recipeStrings);
        }
    }

}













