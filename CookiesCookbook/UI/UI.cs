// See https://aka.ms/new-console-template for more information

namespace CookiesCookbook.IO
{
    public static class UI
    {
        public static string ReadInput(string prompt)
        {
            Console.WriteLine(prompt);
            string? input;
            do
            {
                input = Console.ReadLine();
            } while (input == null);
            return input;
        }
    }

}







