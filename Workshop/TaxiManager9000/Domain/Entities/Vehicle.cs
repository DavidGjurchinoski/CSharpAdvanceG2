using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public Vehicle(string model, string licaLicensePlate, DateTime licensePlateExpieryDate, List<Driver>? drivers = null)
        {
            Model = model;
            LicensePlate = licaLicensePlate;
            LicensePlateExpieryDate = licensePlateExpieryDate;

            AssignedDrivers = drivers ?? new List<Driver>();
        }

        public string Model { get; set; }

        public string LicensePlate { get; set; }

        public DateTime LicensePlateExpieryDate { get; set; }

        public List<Driver> AssignedDrivers { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} - {Model} with License Plate {LicensePlate} and utilized {PercentOfShiftsCovered()}%";
        }

        private decimal PercentOfShiftsCovered()
        {
            int numberOfShifts = Enum.GetValues<Shift>().Length;
            int numberOfUtilizedShifts = 0;

            foreach (var shift in Enum.GetValues<Shift>())
            {
                numberOfUtilizedShifts = AssignedDrivers.Any(x => x.Shift == shift) ? numberOfUtilizedShifts + 1 : numberOfUtilizedShifts;
            }

            return (numberOfUtilizedShifts / numberOfShifts) * 100m;
        }
    }
}
