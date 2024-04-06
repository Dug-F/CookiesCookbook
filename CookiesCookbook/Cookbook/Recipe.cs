// See https://aka.ms/new-console-template for more information

namespace CookiesCookbook.Cookbook
{
    public class Recipe
    {
        private List<int> _ingredientIds = [];
        public int Count => _ingredientIds.Count;

        public void Add(int id)
        {
            _ingredientIds.Add(id);
        }

        public int? GetIngredientId(int id)
        {
            if (id > 0 && id <= _ingredientIds.Count)
            {
                return _ingredientIds[id - 1];
            }
            return null;
        }

        public List<int> GetAllIngredientIds()
        {
            return _ingredientIds;
        }

        public void PrintAllIngredientIds()
        {
             Console.WriteLine(string.Join(", ", _ingredientIds));
        }

        public override string ToString()
        {
            return string.Join(", ", _ingredientIds);
        }

    }

}










