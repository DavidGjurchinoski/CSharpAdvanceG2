using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {

        public Driver(string firstName, string lastName, Shift shift, string license, DateTime licenseExpieryDate, Vehicle? car = null)
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

        public string LastName { get; set; }

        public Shift Shift { get; set; }

        public Vehicle Car { get; set; }

        public string License { get; set; }

        public DateTime LicenseExpieryDate { get; set; }

        public void AssignCar(Vehicle vehicle)
        {
            Car = vehicle;
        }

        public override string ToString()
        {
            return $"{ FirstName } Driving in the { Shift } shift with a { Car?.Model ?? "Has no" } car.";
        }

        public string PrintForManager()
        {
            return $"Driver { FirstName } with license { License } expiering on { LicenseExpieryDate }";
        }

    }
}
