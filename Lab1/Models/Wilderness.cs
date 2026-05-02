namespace Lab1
{
    public class Wilderness : Habitat
    {
        public Wilderness() : base("Wild") { }

        public override void AddAnimal(Animal a)
        {
            base.AddAnimal(a);
            a.SetWild(); // Тварина на волі автоматично щаслива
        }
        
        // Немає FeedAll/CleanAll

    }
}