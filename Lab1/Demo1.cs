using System;
using Lab_1;

namespace Lab_1
{
    public static class Demo1
    {
        public static void Run()
        {
            var owner = new Owner("John");

            var dog = AnimalFactory.Create("dog", "Rex");

            owner.AddAnimal(dog);

            // підписка на події
            dog.StateChanged += (s, e) =>
            {
                Console.WriteLine($"{dog.Name} state: {e.State}");
            };

            dog.Died += (s, e) =>
            {
                Console.WriteLine($"{dog.Name} died: {e.Reason}");
            };

            Console.WriteLine("=== DEMO 1 START ===");

            Console.WriteLine(dog.Feed().Message);

            CalendarService.Instance.AdvanceTime(TimeSpan.FromHours(9));

            dog.CheckLife();

            Console.WriteLine("=== DEMO 1 END ===");
        }
    }
}