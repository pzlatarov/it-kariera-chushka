using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Models
{
    public enum ProductType
    {
        Food = 0,
        Domestic = 1,
        Health = 2,
        Cosmetic = 3,
        Other = 4
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
