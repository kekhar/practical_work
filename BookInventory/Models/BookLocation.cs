using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventory.Models
{
    public class BookLocation
    {
        [Key]
        public int book_location_id { get; set; }
        public int book_id { get; set; }
        public int location_id { get; set; }
        public int quantity { get; set; }
    }
}
