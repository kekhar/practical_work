using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Shopper
    {
        [Key]
        public int ShopperID { get; set; }

        [Required(ErrorMessage = "Имя покупателя обязательно для заполнения")]
        public string ShopperName { get; set; }

        public bool Male { get; set; }

        [Required(ErrorMessage = "ID продукта обязателен для заполнения")]
        public int ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
