using Lab_1;

namespace Lab_1
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