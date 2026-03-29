using System;
using Lab_1;

namespace AnimalSimulation.Events
{
    public class AnimalDeathEventArgs : EventArgs
    {
        public AnimalDeathReason Reason { get; }

        public AnimalDeathEventArgs(AnimalDeathReason reason)
        {
            Reason = reason;
        }
    }
}