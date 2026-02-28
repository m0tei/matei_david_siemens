using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSiemens
{
    internal class Customer
    {
        private int id;
        private string name;

        private Customer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int getId() { return this.id; }
        public string getName() { return this.name;}
    }
}
