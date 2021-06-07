using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOList.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public string text { get; set; }
        public bool checkedFlag { get; set; }
    }
}
