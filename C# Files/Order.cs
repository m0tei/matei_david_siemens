using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSiemens
{
    internal class Order
    {
        private int id;
        private Customer Customer;
        private List<OrderItem> Items;
        private bool discounted;

        public Order(int id, Customer customer) { 
            this.id = id;
            this.Customer = customer;
            this.discounted = false;

            Items = new List<OrderItem>();
        }

        public decimal CulculateTotal()
        {
            // we use this function to calculate the subtotal of the order without the discount
            decimal price = 0;
            foreach (OrderItem item in Items)
            {
                price += item.TotalPrice();
            }
            return price;
        }

        public decimal CalculateFinalPrice()
        {
            // this is the final price with the discount applied
            decimal price = this.CulculateTotal();
            if (price > 500)
            {
                price = price - price * 0.9m;
                this.discounted = true;
            }
            return price;
        }

        public Customer getCustomer() { return this.Customer; }
        public bool getDiscounted() {

            if (!discounted)
            {
                this.CalculateFinalPrice(); //we make sure that the discounted flag is set if discounted is false
            }
            return discounted; 
        }
        public List<OrderItem> getItems()
        {
            return Items;
        }
    }
}