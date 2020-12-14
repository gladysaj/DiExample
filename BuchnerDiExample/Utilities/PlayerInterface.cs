using BuchnerDi.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BuchnerDi.Utilities
{
    public class PlayerInterface : IPlayerInterface
    {
        public void Tell(string message)
        {
            Console.WriteLine(message);
        }

        public string Ask(string message)
        {
            Console.WriteLine(message);
            
            return Console.ReadLine();
        }
    }
}
