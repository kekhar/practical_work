using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Products.Models
{
    public static class ProductsAdd
    {
        public static int GetProductIDFromInput(string productIDText)
        {
            return int.Parse(productIDText);
        }

        public static string GetProductNameFromInput(string productNameText)
        {
            return productNameText;
        }

        public static string GetCategoryFromInput(string categoryText)
        {
            return categoryText;
        }

        public static decimal GetPriceFromInput(string priceText)
        {
            return decimal.Parse(priceText, CultureInfo.CurrentCulture);
        }

        public static DateTime GetArrivalDateFromInput(DateTime? selectedDate)
        {
            if (selectedDate.HasValue)
            {
                return selectedDate.Value;
            }
            else
            {
                return DateTime.Now.Date;
            }
        }
    }
}
