using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOList.Models
{
    public class Lists
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<ListItem> Items { get; set; }
    }
}
