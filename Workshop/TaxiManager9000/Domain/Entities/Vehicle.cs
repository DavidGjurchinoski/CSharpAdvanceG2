 namespace TaxiManager9000.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public Vehicle(string model, string licaLicensePlate, DateTime licensePlateExpieryDate)
        {
            Model = model;
            LicensePlate = licaLicensePlate;
            LicensePlateExpieryDate = licensePlateExpieryDate;
            //AsignedDrivers = asignedDrivers;

            AssignedDrivers = new();
        }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public DateTime LicensePlateExpieryDate { get; set; }

        public List<Driver> AssignedDrivers { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - {Model} with License Plate {LicensePlate} and utilized [Percentage of shifts covered]%";
        }
    }
}
