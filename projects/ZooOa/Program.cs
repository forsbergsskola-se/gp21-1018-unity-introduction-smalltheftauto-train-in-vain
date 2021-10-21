using System;
using System.Collections.Generic;

namespace ZooOa
{
    class Animal { }

    class Mammal : Animal { }

    class Bear : Mammal { }

    class Donkey : Mammal { }

    class Lion : Mammal { }

    class Fish : Animal { }

    class Salmon : Fish { }

    class Clownfish : Fish { }

    class Student { }




    class Zoo<TAnimal> where TAnimal : Animal
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(TAnimal animal)
        {
            animals.Add(animal);
        }


        public bool HasAnimal<TSearchAnimal>() where TSearchAnimal : TAnimal
        {
            foreach (Animal animal in animals)
            {
                if (animal is TSearchAnimal)
                    return true;
            }

            return false;
        }
    }
    
    
    class Program
    {
        static void Main()
        {
            
        }
    }
}
