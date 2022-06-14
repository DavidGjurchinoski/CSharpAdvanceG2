namespace TimeTracking.Domain.Entities
{
    public class User : BaseEntity
    {
        private const int VALID_USERNAME_LENGHT = 5;
        private const int VALID_PASSWORD_LENGHT = 6;
        private const int VALID_NAME_LENGHT = 2;
        private const int VALID_MIN_AGE = 18;
        private const int VALID_MAX_AGE = 120;


        //public User(int id, string firstName, string lastName, int age, string username, string passwrod) : base(id)
        //{
        //    Id = id;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Age = age;
        //    Username = username;
        //    Passwrod = passwrod;
        //}

        public User(string firstName, string lastName, int age, string username, string password) : base()
        {
            ValidateNameInput(firstName);
            FirstName = firstName;

            ValidateNameInput(lastName);
            LastName = lastName;

            if(age < VALID_MIN_AGE || age > VALID_MAX_AGE)
            {
                throw new Exception("Not in valid age group!");
            }
            Age = age;

            if (username.Length < VALID_USERNAME_LENGHT)
            {
                throw new Exception($"Username should be more then {VALID_USERNAME_LENGHT}");
            }

            if (username.Length < VALID_USERNAME_LENGHT)
            {
                throw new Exception($"Password should be more then {VALID_USERNAME_LENGHT}");
            }
            Username = username;

            ValidatePassword(password);
            Passwrod = password;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Username { get; set; }

        public string Passwrod { get; set; }

        private void ValidatePassword(string password)
        {
            //if (password.Length < VALID_PASSWORD_LENGHT)
            //{
            //    throw new Exception($"Password should be more then {VALID_PASSWORD_LENGHT}");
            //}

            bool hasCapital = false;
            bool hasNum = false;

            //foreach (char c in password)
            //{
            //    if (char.IsUpper(c))
            //    {
            //        hasCapital = true;
            //    }

            //    if (char.IsDigit(c))
            //    {
            //        hasNum = true;
            //    }
            //}

            if (!hasCapital)
            {
                //throw new Exception("Password should have atleast one capital leater!");
            }

            if (!hasNum)
            {
                //throw new Exception("Password should have atleast one number!");
            }
        }

        private void ValidateNameInput(string input)
        {
            if(input.Length < VALID_NAME_LENGHT)
            {
                throw new Exception("First and Last Name should not be shorter then two chars!");
            }

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    //throw new Exception("First and Last Name should not contain numbers!");
                }
            }
        }
    }
}
