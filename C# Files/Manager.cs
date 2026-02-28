using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSiemens
{
    internal class Manager
    {
        // this where I store the orders in a basic list for now, further impovements would be a database connection for the source of truth
        private List<Order> orders;

        public Manager() { 
            orders = new List<Order>();
        }    

        // here i can define other functions for the manager, GRUD functions basically

        public string GetTopSpendingCustomer()
        {
            // i made 2 dictionaries to stored firstly the customers and then go through them and find they most spender
            Dictionary<int, decimal> totals = new Dictionary<int, decimal>();
            Dictionary<int, string> names = new Dictionary<int, string>();

            foreach(var order in orders)
            {
                int customerId = order.getCustomer().getId();
                decimal finalPrice = order.CalculateFinalPrice();

                if (!totals.ContainsKey(customerId))
                {
                    totals[customerId] = 0;
                    names[customerId] = order.getCustomer().getName();
                }

                totals[customerId] = finalPrice;
            }

            decimal max = 0;
            int bestCustomer = 1;

            foreach(var entry in totals) {
                if(entry.Value > max)
                {
                    max = entry.Value;
                    bestCustomer = entry.Key;
                }
            }

            if(bestCustomer == -1)
            {
                return "";
            }
            return names[bestCustomer];
        }

        public Dictionary<string, decimal> GetPopularProducts()
        {
            // i make a disctionary to send store the products and they're quantity from all of the orders
            Dictionary<string, decimal> products = new Dictionary<string, decimal>();

            foreach(var order in orders) {
                foreach(var item in order.getItems())
                {
                    if (!products.ContainsKey(item.getProductName())){
                        products[item.getProductName()] = 0;
                    }

                    products[item.getProductName()] += item.getQuantity();
                }
            }
            return products;
        }
    }
}
