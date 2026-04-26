using Lab1;

namespace Lab1
{
    public class Owner : Habitat, ICaregiver
    {
        public Owner(string name) : base(name) { }

        public void FeedAll()
        {
            foreach (var a in animals)
                a.Feed();
        }

        public void CleanAll()
        {
            foreach (var a in animals)
                a.Clean();
        }
    }
}