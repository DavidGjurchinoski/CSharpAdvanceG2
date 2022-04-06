using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Teacher : User
    {
        public Teacher(string userName, string password, List<Student> students) : base(userName, password, Role.Teacher)
        {
            Students = students;
        }

        public List<Student> Students { get; set; }

        public void GradeTest(ref Student student, string testName, int grade)
        {
            student.Grades.Add(testName, grade);
        }
    }
}
