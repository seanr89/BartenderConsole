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
            _recipes = new Dictionary<string, Action>{
                {"beer", ServeBeer},
                {"juice", ServeJuice}
            };
        }

        private void ServeJuice()
        {
            throw new NotImplementedException();
        }

        private void ServeBeer()
        {
            throw new NotImplementedException();
        }

        public void MakeDrink(string drinkName)
        {

        }

        public IEnumerable<string> GetAvailableDrinkNames()
        {
            return _recipes.Keys;
        }
    }
}