 namespace TaxiManager9000.Domain.Entities
{
    public class Car : BaseEntety
    {
        public Car(string model, string licaLicensePlate, DateTime licensePlateExpieryDate, List<Driver> asignedDrivers)
        {
            //Id = -1;
            Model = model;
            LicaLicensePlate = licaLicensePlate;
            LicensePlateExpieryDate = licensePlateExpieryDate;
            AsignedDrivers = asignedDrivers;
        }

        //public int Id { get; set; }

        public string Model { get; set; }

        public string LicaLicensePlate { get; set; }

        public DateTime LicensePlateExpieryDate { get; set; }

        public List<Driver> AsignedDrivers { get; set; }

    }
}
