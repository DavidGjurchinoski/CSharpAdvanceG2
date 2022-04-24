using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntety
    {


        public Driver(string firstName, int lastName, Shift shift, Car car, string license, DateTime licenseExpieryDate)
        {
            //Id = -1;
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            Car = car;
            License = license;
            LicenseExpieryDate = licenseExpieryDate;
        }

        //public int Id { get; set; }

        public string FirstName { get; set; }

        public int LastName { get; set; }

        public Shift Shift { get; set; }

        public Car Car { get; set; }

        public string License { get; set; }

        public DateTime LicenseExpieryDate { get; set; }

    }
}
