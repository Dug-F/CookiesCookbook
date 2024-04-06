// See https://aka.ms/new-console-template for more information

using CookiesCookbook.Cookbook;

namespace CookiesCookbook.IO
{
    public interface IRecipeStore
    {
        List<Recipe> Read(string fileName);
        void Write(string fileName, List<Recipe> recipes);
    }

}













