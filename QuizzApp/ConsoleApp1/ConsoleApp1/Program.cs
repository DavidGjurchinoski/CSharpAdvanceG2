using Entities;
using System;

List<User> users = new List<User>();

List<Student> studentsG1 = new List<Student>()
{
    new Student("student1","student1"),
    new Student("student2","student2"),
    new Student("student3","student3")
};

List<Student> studentsG2 = new List<Student>()
{
    new Student("student4","student4"),
    new Student("student5","student5"),
    new Student("student5","student5"),
};

Teacher teacher1 = new Teacher("teacher1", "teacher1", studentsG1);
Teacher teacher2 = new Teacher("teacher2", "teacher2", studentsG2);

users.Add(teacher1);
users.Add(teacher2);

AddStudentsGroupToUserList(studentsG1,in users);
AddStudentsGroupToUserList(studentsG2,in users);

while(true)
{
    User currentUser = LogIn(users); 

    switch (currentUser.Role)
    {
        case Role.Student:
            StudentMenu();
            break;
        case Role.Teacher:
            //TeacherMenu(currentUser);
            break;
        default:
            Console.WriteLine("No user found with that username!");
            break;
    }

};

static void TeacherMenu(Teacher teacher)
{
    Console.WriteLine($"\nHello teacher: {teacher.UserName}");

    do
    {
        Console.ForegroundColor = ConsoleColor.Green;

        teacher.St

    } while (Console.ReadKey().Key != ConsoleKey.Enter);

}

void StudentMenu()
{
    throw new NotImplementedException();
}

static User LogIn(List<User> users)
{

    Console.WriteLine("Enter your username:");
    string username = Console.ReadLine();

    User userFound = null;

    try
    {
        userFound = users.Single(user => user.UserName == username);

        Console.WriteLine($"Hello {username}. Please Enter you password:");

        for (int i = 0; i < 3; i++)
        {
            string password = Console.ReadLine();

            if (userFound.Password.Equals(password)) return userFound;

            if (i == 2) throw new Exception($"{userFound.UserName} you failed the password 3 times. Shuting down...");

            Console.WriteLine($"You have {3 - i} chances left!");
        }

    }
    catch (Exception ex)
    {
        if (userFound == null)
        {
            Console.WriteLine(ex.Message);
        }
        else
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
    }

    return null;
}

static void AddStudentsGroupToUserList(List<Student> students,in List<User> users)
{
    //students.ForEach(student => users.Add(student)); <--- dali ima nacin ref da go polnime so lambda expresion

    foreach (Student student in students)
    {
        users.Add(student);
    }
}