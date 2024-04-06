// See https://aka.ms/new-console-template for more information

using CookiesCookbook.InputOutput;
using System.Reflection.Metadata.Ecma335;

namespace CookiesCookbook.Cookbook
{
    public class Recipes
    {
        private List<Recipe> RecipesList = [];

        public void Add(Recipe recipe)
        {
            RecipesList.Add(recipe);
        }

        public Recipe? GetRecipe(int id)
        {
            if (id > 0 && id <= RecipesList.Count)
            {
                return RecipesList[id - 1];
            }
            return null;
        }

        public List<Recipe> GetAllRecipes()
        {
            return RecipesList;
        }

    }

}










