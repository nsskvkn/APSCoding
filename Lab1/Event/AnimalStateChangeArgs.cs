using System;
using Lab_1;

namespace AnimalSimulation.Events
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