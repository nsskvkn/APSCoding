using Lab_1;

namespace Lab_1
{
    public class Lizard : Animal, ICrawlable
    {
        public Lizard(string name) : base(name) { }

        public ActionResult Crawl()
        {
            return ActionResult.Ok($"{Name} crawls");
        }
    }
}