using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Dog
    {
        public const int MIN_NAME_LENGHT = 2;

        public const int VALID_ID_START_NUMBER = 0;

        public Dog(int id, string name, string color)
        {
            Id = id;
            Name = name;
            Color = color;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public void Bark()
        {
            Console.WriteLine("Bark Bark!");
        }

        public static bool Validate(Dog dog)
        {
            if(dog.Id < VALID_ID_START_NUMBER)
            {
                Console.WriteLine("The id is Invalid");
                
                return false;
            }

            if (dog.Name.Length < MIN_NAME_LENGHT)
            {
                Console.WriteLine("The Name is Invalid");

                return false;
            }

            if (string.IsNullOrEmpty(dog.Color))
            {
                Console.WriteLine("You need to have a color for your dog");

                return false;
            }

            return true;
        }
    }
}
