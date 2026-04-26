using System.Collections.Generic;
using Lab1;

namespace Lab1
{
    public abstract class Habitat
    {
        protected List<Animal> animals = new();

        public string Name { get; }

        protected Habitat(string name)
        {
            Name = name;
        }

        public virtual void AddAnimal(Animal a)
        {
            animals.Add(a);
        }

        public IEnumerable<Animal> GetAnimals() => animals;
    }
}