using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Student : User
    {
        public Student(string userName, string password) : base(userName, password, Role.Student)
        {
        }

        //If the student has multiple test done we can keep track of them with a dictionary
        public Dictionary<string, int> Grades {get; set;}
    }
}
