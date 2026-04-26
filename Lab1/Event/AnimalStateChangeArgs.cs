using System;
using Lab1;

namespace Lab1
{
    public class AnimalStateChangeArgs : EventArgs
    {
        public AnimalState State { get; }

        public AnimalStateChangeArgs(AnimalState state)
        {
            State = state;
        }
    }
}