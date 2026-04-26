using System;
using System.Collections.Generic;

namespace Lab1;

public static class Demo2
{
    private static Owner owner = new Owner("Player");
    private static List<Animal> animals = new();

    public static void Run()
    {
        Console.WriteLine("=== DEMO 2 (MENU) ===");

        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Create animal");
            Console.WriteLine("2. Feed all");
            Console.WriteLine("3. Clean all");
            Console.WriteLine("4. Advance time");
            Console.WriteLine("5. Show animals");
            Console.WriteLine("6. Exit");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateAnimal();
                    break;

                case "2":
                    owner.FeedAll();
                    Console.WriteLine("All animals fed");
                    break;

                case "3":
                    owner.CleanAll();
                    Console.WriteLine("All animals cleaned");
                    break;

                case "4":
                    CalendarService.Instance.AdvanceTime(TimeSpan.FromHours(9));
                    foreach (var a in animals)
                        a.CheckLife();

                    Console.WriteLine("Time advanced");
                    break;

                case "5":
                    ShowAnimals();
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }

    private static void CreateAnimal()
    {
        Console.WriteLine("Enter type (dog/owl/lizard):");
        string type = Console.ReadLine();

        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();

        var animal = AnimalFactory.Create(type, name);

        animal.StateChanged += (s, e) =>
        {
            Console.WriteLine($"{animal.Name}: {e.State}");
        };

        animal.Died += (s, e) =>
        {
            Console.WriteLine($"{animal.Name} died: {e.Reason}");
        };

        owner.AddAnimal(animal);
        animals.Add(animal);

        Console.WriteLine("Animal created");
    }

    private static void ShowAnimals()
    {
        foreach (var a in animals)
        {
            Console.WriteLine($"{a.Name} | Alive: {a.IsAlive}");
        }
    }
}