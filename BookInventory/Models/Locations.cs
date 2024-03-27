using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventory.Models
{
    public class Location
    {
        [Key]
        public int location_id { get; set; }
        public string name { get; set; }
    }
}
