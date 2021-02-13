using System;
using System.Linq;

namespace barapp
{
    public class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private readonly RecipeBook _recipeBook;
        public Bartender(Func<string> inputProvider, Action<string> outputProvider, RecipeBook recipeBook)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            _recipeBook = recipeBook;
        }

        public void AskForDrink()
        {
            _outputProvider($"What do you want to drink? ({string.Join(", ", _recipeBook.GetAvailableDrinkNames())})");

            var drink = _inputProvider() ?? string.Empty;

            if (!_recipeBook.GetAvailableDrinkNames().Contains(drink))
            {
                _outputProvider($"Sorry we don't serve {drink} here");
                return;
            }

            _recipeBook.GetRecipe(drink)();
        }
    }
}