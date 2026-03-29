using System;
using Lab_1;

namespace Lab_1
{
    public class Dog : Animal, IRunnable, IWalkable
    {
        public Dog(string name) : base(name) { }

        public ActionResult Run()
        {
            if (!CanBeActive())
                return ActionResult.Fail("Dog is hungry");

            return ActionResult.Ok($"{Name} runs");
        }

        public ActionResult Walk()
        {
            return ActionResult.Ok($"{Name} walks");
        }
    }
}