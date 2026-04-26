using Lab1;

namespace Lab1
{
    public class Owl : Animal, IFlyable
    {
        public Owl(string name) : base(name) { }

        public ActionResult Fly()
        {
            if (!CanBeActive())
                return ActionResult.Fail("Owl is hungry");

            return ActionResult.Ok($"{Name} flies");
        }
    }
}