using BuchnerDi.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BuchnerDi.Constants;

namespace BuchnerDi
{
    public class Setup
    {
        private IPlayerInterface _playerInterface;
        private int _amountOfPlayers;

        public Setup(IPlayerInterface playerInterface) { _playerInterface = playerInterface; }

        public Setup AskForAmountOfPlayers()
        {
            // Console.WriteLine("How many players will be playing the game?");
            // var response = Console.ReadLine();
            var reponse = _playerInterface.Ask(PlayerInterfaceQuestions.AskAmountOfPlayers);
            int amount;

            if (
                !Int32.TryParse(reponse, out amount)
                || amount < 1
                || amount > 6
                )
            {
                _playerInterface.Tell(PlayerInterfaceQuestions.MustEnterAValidNumber);

                return AskForAmountOfPlayers();
            }
            else
            {
                _amountOfPlayers = amount;
            }

            return this;
        }
    }
}
