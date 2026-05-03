using System;
using Lab1;

namespace Lab1
{
    public static class AnimalFactory
{
    private static Dictionary<string, Func<string, Animal>> registry = new()
    {
        { "dog", name => new Dog(name) },
        { "owl", name => new Owl(name) },
        { "lizard", name => new Lizard(name) }
    };

    // Можливість додати новий тип без зміни існуючого коду
    public static void Register(string type, Func<string, Animal> creator)
    {
        registry[type.ToLower()] = creator;
    }

    public static Animal Create(string type, string name)
    {
        if (!registry.ContainsKey(type.ToLower()))
            throw new ArgumentException($"Unknown animal type: {type}");
        
        return registry[type.ToLower()](name);
    }

    public static IEnumerable<string> GetAvailableTypes() => registry.Keys;
}

}