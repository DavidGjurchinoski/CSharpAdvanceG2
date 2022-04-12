using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class InvalidUserExeption : Exception
    {
        public InvalidUserExeption(string? message) : base(message)
        {

            Console.WriteLine("Invalid input for the user!");

            Console.WriteLine(message);

        }
    }
}
