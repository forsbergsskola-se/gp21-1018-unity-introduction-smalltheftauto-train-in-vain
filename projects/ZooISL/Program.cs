using System;
using System.Linq;

namespace ZooISL
{
    public class Program
    {
        static void Main()
        {
            Zoo<Animal> animalZoo = new Zoo<Animal>();
            animalZoo.AddAnimal(new Salmon());
            animalZoo.AddAnimal(new Lion());
            animalZoo.AddAnimal(new Donkey());
            Console.WriteLine("This should be True: " + animalZoo.HasAnimal<Fish>());
        }
        
    }
    
    public class Zoo<TAnimal> where TAnimal : Animal
    {
        private int arraySize = 0;
        private TAnimal[] animals;

        public void AddAnimal(TAnimal animal)
        {
            Array.Resize(ref animals, ++arraySize);
            animals[arraySize - 1] = animal;
        }

        public bool HasAnimal<T>() where T : TAnimal
        {
            return animals.ToList().Any(x => x is T);
        }
    }

    public class Animal { }

    class Mammal : Animal { }

    class Bear : Mammal { }

    class Donkey : Mammal { }

    class Lion : Mammal { }

    class Fish : Animal { }

    class Salmon : Fish { }

    class Clownfish : Fish { }

    class Student { }
}
