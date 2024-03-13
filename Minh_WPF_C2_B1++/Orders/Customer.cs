using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class Customer
    {
        #region Properties
        public string Name { get; set; }
        public string Phone { get; set; }
        #endregion

        #region Contructor
        public Customer()
        {
            this.Name = "";
            this.Phone = "";
        }

        public Customer(string name, string phone)
        {
            this.Name = name;
            this.Phone = phone;
        }
        #endregion
    }
}
