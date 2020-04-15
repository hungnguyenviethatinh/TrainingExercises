using System;
using Week1_OOP_Exercise4.Core;
using Week1_OOP_Exercise4.Models;

namespace Week1_OOP_Exercise4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cat[] cats = new Cat[3];
            Dog[] dogs = new Dog[3];
            Frog[] frogs = new Frog[3];
            Kitten[] kittens = new Kitten[3];
            Tomcat[] tomcats = new Tomcat[3];

            cats[0] = new Cat("Cat 0", 1, Sex.Male);
            cats[1] = new Cat("Cat 1", 2, Sex.Female);
            cats[2] = new Cat("Cat 2", 3, Sex.Male);

            dogs[0] = new Dog("Dog 0", 4, Sex.Male);
            dogs[1] = new Dog("Dog 0", 5, Sex.Female);
            dogs[2] = new Dog("Dog 0", 6, Sex.Male);

            frogs[0] = new Frog("Frog 0", 7, Sex.Male);
            frogs[1] = new Frog("Frog 1", 8, Sex.Female);
            frogs[2] = new Frog("Frog 2", 9, Sex.Male);

            kittens[0] = new Kitten("Kitten 0", 10);
            kittens[1] = new Kitten("Kitten 1", 11);
            kittens[2] = new Kitten("Kitten 2", 12);

            tomcats[0] = new Tomcat("Tomcat 0", 13);
            tomcats[1] = new Tomcat("Tomcat 1", 14);
            tomcats[2] = new Tomcat("Tomcat 2", 15);

            Console.WriteLine($"Average age of cats: {CalculateAgeAvg(cats)}");
            Console.WriteLine($"Average age of dogs: {CalculateAgeAvg(dogs)}");
            Console.WriteLine($"Average age of frogs: {CalculateAgeAvg(frogs)}");
            Console.WriteLine($"Average age of kittens: {CalculateAgeAvg(kittens)}");
            Console.WriteLine($"Average age of tomcats: {CalculateAgeAvg(tomcats)}");

            Console.ReadLine();
        }

        static float CalculateAgeAvg(Animal[] animals)
        {
            int count = animals.Length;
            float total = 0;
            foreach (var animal in animals)
            {
                total += animal.GetAge();
            }

            return (total / count);
        }
    }
}
