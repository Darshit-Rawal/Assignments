using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EMS.BE
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
