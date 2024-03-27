using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventory.Models
{
    public class Genre
    {
        [Key]
        public int genre_id { get; set; }
        public string name { get; set; }
    }
}
