using BuchnerDi.Utilities;
using System;

namespace BuchnerDi
{
    class Program
    {
        static void Main(string[] args)
        {
            var pi = new PlayerInterface();
            var app = new Setup(pi)
                            .AskForAmountOfPlayers();
        }
    }
}
