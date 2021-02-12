using System;

namespace barapp
{
    public class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        public Bartender(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }

        public void AskForDrink()
        {
            _outputProvider("What do you want to drink? (beer, juice)");
        }
    }
}