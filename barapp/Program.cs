using System;

namespace barapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var recipes = new RecipeBook(Console.ReadLine, Console.WriteLine);
            //Initialise the bartender and inject console inputs and outputs into it
            var bartender = new Bartender(Console.ReadLine, Console.WriteLine, recipes);
            while (true)
            {
                //support waiting for a person to ask for a drink!
                bartender.AskForDrink();
            }
        }
    }
}
