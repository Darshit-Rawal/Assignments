using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.BusinessEntity
{
    public class Appointment
    {
        public int Id { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Dealer")]
        public int DealerId { get; set; }
        [Display(Name = "Mechanic")]
        public int MachanicId { get; set; }
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Display(Name = "Appointment Date")]
        public System.DateTime AppointmentDate { get; set; }
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        public int Status { get; set; }
        public int UpdatedBy { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Customer Customer1 { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        public virtual Service Service { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
