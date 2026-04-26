using Lab1;

namespace Lab1
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