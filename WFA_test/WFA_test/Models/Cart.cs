using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_test.Models
{
    class Cart
    {
        public Table TableName { set; get; }
        public User UserName { set; get; }

        public Product ProductName { set; get; }
        public int Quantity { set; get; }
        private Decimal Total { 
            get { return Total; }
            set { this.Total = ProductName.Price * this.Quantity; } 
        }
    }
}
