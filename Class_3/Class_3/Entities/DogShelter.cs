using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class DogShelter
    {

        public static List<Dog> ListOfDogs = new List<Dog>()
        {
            new Dog(1, "Sparky", "Red"),
            new Dog(-1, "Sparky", "Red"),
            new Dog(1, "", "Red")

        };

        public static void PrintAll()
        {

            ListOfDogs.ForEach(dog => Console.WriteLine($"Dog Name: {dog.Name}, Dog Id: {dog.Id}, Dog Color: {dog.Color}"));

        }

    }
}
