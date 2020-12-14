using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace BuchnerDi.Interfaces
{
    public interface IPlayerInterface
    {
        void Tell(string message);
        string Ask(string message);
    }
}
