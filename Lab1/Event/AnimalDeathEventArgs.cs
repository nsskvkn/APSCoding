using System;
using Lab1;

namespace Lab1
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