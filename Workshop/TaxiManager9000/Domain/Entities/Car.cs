using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiManager9000.Domain.Entities
{
    public class Car
    {
        public Car(int id, string model, string licaLicensePlate, DateTime licensePlateExpieryDate, Driver asignedDrivers)
        {
            Id = id;
            Model = model;
            LicaLicensePlate = licaLicensePlate;
            LicensePlateExpieryDate = licensePlateExpieryDate;
            AsignedDrivers = asignedDrivers;
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public string LicaLicensePlate { get; set; }

        public DateTime LicensePlateExpieryDate { get; set; }

        public Driver AsignedDrivers { get; set; }

    }
}
