using System;
using Lab_1;

namespace Lab_1
{
    public static class AnimalFactory
    {
        private static Dictionary<string, Func<string, Animal>> map = new()
        {
            { "dog", name => new Dog(name) },
            { "owl", name => new Owl(name) },
            { "lizard", name => new Lizard(name) }
        };

        public static Animal Create(string type, string name)
        {
            return map[type.ToLower()](name);
        }
    }
}