using BuchnerDi.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace BuchnerDi_Tests.Utilities
{
    public class PlayerInterfaceTestTool : IPlayerInterface
    {
        private Queue<string> Tells { get; set; }
        private Queue<string> Asks { get; set; }

        public PlayerInterfaceTestTool()
        {
            Asks = new Queue<string>();
            Tells = new Queue<string>();
        }
        public void Tell(string message)
        {
            Tells.Enqueue(message);
        }

        public string NextTell()
        {
            return Tells.Dequeue();
        }

        public string Ask(string message)
        {
            return Asks.Dequeue();
        }

        public void AddFuturePlayerInput(string message)
        {
            Asks.Enqueue(message);
        }
    }
}
