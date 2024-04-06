// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CookiesCookbook.Cookbook
{
    public class IngredientList
    {
        private List<Ingredient> _ingredients;
        public int Count => _ingredients.Count;

        public IngredientList(Ingredient[]? initialIngredients = null)
        {
            _ingredients = [];
            if (initialIngredients != null)
            {
                _ingredients.AddRange(initialIngredients);
            }
        }

        public void Add(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public Ingredient Get(int id)
        {
            if (id < 1 || id > Count)
            {
                throw new ArgumentOutOfRangeException($"No valid ingredient found for {id}");
            }
            return _ingredients[id - 1];
        }

        public void PrintMenu()
        {
            for (int i = 0; i < _ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_ingredients[i].Name}");
            }
        }

    }

}

