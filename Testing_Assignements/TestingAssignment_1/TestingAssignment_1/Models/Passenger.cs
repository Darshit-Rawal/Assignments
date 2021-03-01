using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAssignment_1.Models
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }

    }
}