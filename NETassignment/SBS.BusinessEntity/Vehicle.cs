using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntity
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Display(Name = "Registration Date")]
        public System.DateTime RegistrationDate { get; set; }
        [Display(Name = "Chassis Number")]
        public long ChassisNumber { get; set; }
        public int CustomerId { get; set; }

        //Navigation Properties
        public virtual Customer Customer { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
