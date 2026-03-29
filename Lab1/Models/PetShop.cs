using Lab_1;

namespace Lab_1
{
    public class PetShop : Habitat, ICaregiver
    {
        public PetShop(string name) : base(name) { }

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