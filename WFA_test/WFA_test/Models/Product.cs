using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_test.Models
{
    class Product
    {
        public String ProductName { set; get; }
        public Decimal Price { set; get; }
        public bool Active { set; get; }
        public Product() { }
        public Product(String proname, Decimal price, bool active)
        {
            this.ProductName = proname;
            this.Price = price;
            this.Active = active;
        }
    }
}
