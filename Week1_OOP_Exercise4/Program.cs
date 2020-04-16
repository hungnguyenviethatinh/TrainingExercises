using System;
using Week1_OOP_Exercise4.Core;
using Week1_OOP_Exercise4.Models;

namespace Week1_OOP_Exercise4
{
    static class Program
    {
        static void Main()
        {
            Animal[] animals = new Animal[15];

            animals[0] = new Cat("Cat 0", 1, Sex.Male);
            animals[1] = new Cat("Cat 1", 2, Sex.Female);
            animals[2] = new Cat("Cat 2", 3, Sex.Male);

            animals[3] = new Dog("Dog 0", 4, Sex.Male);
            animals[4] = new Dog("Dog 0", 5, Sex.Female);
            animals[5] = new Dog("Dog 0", 6, Sex.Male);

            animals[6] = new Frog("Frog 0", 7, Sex.Male);
            animals[7] = new Frog("Frog 1", 8, Sex.Female);
            animals[8] = new Frog("Frog 2", 9, Sex.Male);

            animals[9] = new Kitten("Kitten 0", 10);
            animals[10] = new Kitten("Kitten 1", 11);
            animals[11] = new Kitten("Kitten 2", 12);

            animals[12] = new Tomcat("Tomcat 0", 13);
            animals[13] = new Tomcat("Tomcat 1", 14);
            animals[14] = new Tomcat("Tomcat 2", 15);

            CalculateAgeAvg(animals);
            IdentifyAnimal(animals);

            Console.ReadLine();
        }

        static void CalculateAgeAvg(Animal[] animals)
        {
            int numberOfCats = 0;
            int numberOfDogs = 0;
            int numberOfFrogs = 0;
            float totalCatAge = 0;
            float totalDogAge = 0;
            float totalFrogAge = 0;

            foreach (var animal in animals)
            {
                AnimalType animalType = Animal.Identify(animal);
                switch (animalType)
                {
                    case AnimalType.Cat:
                        numberOfCats++;
                        totalCatAge += animal.GetAge();
                        break;
                    case AnimalType.Dog:
                        numberOfDogs++;
                        totalDogAge += animal.GetAge();
                        break;
                    case AnimalType.Frog:
                        numberOfFrogs++;
                        totalFrogAge += animal.GetAge();
                        break;
                }
            }

            Console.WriteLine($"Average age of cats: {totalCatAge / numberOfCats}");
            Console.WriteLine($"Average age of dogs: {totalDogAge / numberOfDogs}");
            Console.WriteLine($"Average age of frogs: {totalFrogAge / numberOfFrogs}");
        }

        static void IdentifyAnimal(Animal[] animals)
        {
            foreach (var animal in animals)
            {
                AnimalType animalType = Animal.Identify(animal);
                switch (animalType)
                {
                    case AnimalType.Cat:
                        Console.WriteLine($"{animal.GetName()} is a cat.");
                        break;
                    case AnimalType.Dog:
                        Console.WriteLine($"{animal.GetName()} is a dog.");
                        break;
                    case AnimalType.Frog:
                        Console.WriteLine($"{animal.GetName()} is a frog.");
                        break;
                    default:
                        Console.WriteLine($"{animal.GetName()} is undefined.");
                        break;
                }
            }
        }
    }
}
