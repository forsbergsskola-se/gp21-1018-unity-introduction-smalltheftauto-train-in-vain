using System;

namespace ZooID
{
    class Program
    {
        static void Main()
        {
            {
                Zoo<Fish> fishZoo = new Zoo<Fish>();
                fishZoo.AddAnimal(new Fish()); // OKAY
                fishZoo.AddAnimal(new Clownfish()); // OKAY
            }
        }
    }
    class Animal 
    {
            
    }

    class Mammal : Animal
    {
        
    }

    class Bear : Mammal
    {
        
    }

    class Donkey : Mammal
    {
        
    }

    class Lion : Mammal
    {
        
    }

    class Fish : Animal
    {
        
    }

    class Salmon : Fish
    {
        
    }

    class Clownfish : Fish
    {
        
    }

    class Student 
    {
        
    }

    class Zoo <T>  where T : Animal {
        public Animal[] animals;
        private int arraysize = 0;

        public void AddAnimal(T Animal) 
        { 
            Array.Resize(ref animals, ++arraysize); 
                
        }
        
    }
}
