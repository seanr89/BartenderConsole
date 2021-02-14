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

        /// <summary>
        /// Controls the data/console input for clients drinks order
        /// </summary>
        public void AskForDrink()
        {
            //Provide information of what the client can order
            _outputProvider($"What do you want to drink? ({string.Join(", ", _recipeBook.GetAvailableDrinkNames())})");

            var drink = _inputProvider() ?? string.Empty;
            //Check reciper book and if not available tell the client
            if (!_recipeBook.GetAvailableDrinkNames().Contains(drink))
            {
                _outputProvider($"Sorry we don't serve {drink} here");
                return;
            }
            //Get the respective recipe the follow its instructions!
            _recipeBook.GetRecipe(drink)();
        }
    }
}