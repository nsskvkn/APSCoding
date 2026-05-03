using System;
using Lab1;

namespace Lab1
{
    public static class Demo1
    {
        public static void Run()
        {
            var petShop = new PetShop("Happy Paws");

            var owl = AnimalFactory.Create("owl", "Luna");

            petShop.AddAnimal(owl);

            owl.StateChanged += (s, e) =>
            {
                Console.WriteLine($"{owl.Name} state: {e.State}");
            };

            owl.Died += (s, e) =>
            {
                Console.WriteLine($"{owl.Name} died: {e.Reason}");
            };

            Console.WriteLine("=== DEMO 1 START ===");

            Console.WriteLine(owl.Feed().Message);

            petShop.CleanAll();

            CalendarService.Instance.AdvanceTime(TimeSpan.FromHours(9));

            owl.CheckLife();

            Console.WriteLine("=== DEMO 1 END ===");
        }
    }
}