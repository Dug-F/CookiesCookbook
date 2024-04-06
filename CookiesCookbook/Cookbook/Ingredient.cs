// See https://aka.ms/new-console-template for more information

namespace CookiesCookbook.Cookbook
{
    public class Ingredient
    {
        public string Name { get; }
        public string Instruction { get; }

        public Ingredient(string name, string instruction)
        {
            Name = name;
            Instruction = instruction;
        }

        public void Print()
        {
            Console.WriteLine($"{Name}. {Instruction}");
        }

        public override string ToString()
        {
            return $"{Name}. {Instruction}";
        }
    }

}

