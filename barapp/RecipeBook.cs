using System;
using System.Collections.Generic;

namespace barapp
{
    public class RecipeBook
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        private readonly Dictionary<string, Action> _recipes;

        public RecipeBook(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            _recipes = new Dictionary<string, Action>{
                {"beer", ServeBeer},
                {"juice", ServeJuice},
                {"old fashioned", ServeOldFashioned}
            };
        }

        public Action GetRecipe(string drinkName)
        {
            return _recipes[drinkName];
        }

        /// <summary>
        /// Provide a collection of available drinks
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAvailableDrinkNames()
        {
            return _recipes.Keys;
        }

        #region Private Methods

        /// <summary>
        /// Supporting alcohol age checks
        /// </summary>
        /// <param name="age"></param>
        /// <param name="drink"></param>
        private void HandleAgeCheck(int age, string drink)
        {
            if (age >= 18)
            {
                _outputProvider($"Here you go with your {drink}!");
                return;
            }
            _outputProvider("Sorry but you are not old enough for alcohol!");
        }

        private void HandleInvalidAge()
        {
            _outputProvider("Sorry I don't understand that age");
        }

        private void ServeOldFashioned()
        {
            _outputProvider("How old are you?");
            if (!int.TryParse(_inputProvider(), out var age))
            {
                HandleInvalidAge();
                return;
            }
            HandleAgeCheck(age, "old fashioned");
        }

        private void ServeJuice()
        {
            _outputProvider("Here is a nice Juice!");
        }

        private void ServeBeer()
        {
            _outputProvider("How old are you?");
            if (!int.TryParse(_inputProvider(), out var age))
            {
                HandleInvalidAge();
                return;
            }
            HandleAgeCheck(age, "beer");
        }

        #endregion
    }
}