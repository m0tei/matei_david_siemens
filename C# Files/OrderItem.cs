using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSiemens
{
    internal class OrderItem
    {
        private string product_name;
        private int quantity;
        private decimal unit_price;

        public OrderItem(string product_name, int quantity, decimal unit_price) { 
            this.product_name = product_name;
            this.quantity = quantity;
            this.unit_price = unit_price;
        }

        public decimal TotalPrice() {
            return quantity * unit_price; 
        }
        public string getProductName() { return this.product_name; }
        public int getQuantity() { return this.quantity;}
    }
}
