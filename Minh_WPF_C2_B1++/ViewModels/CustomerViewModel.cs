using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class CustomerViewModel
    {
        #region Properties
        public Customer customer = new Customer();
        #endregion

        #region Methods
        public void Create(string name, string phone)
        {
            customer = new Customer(name, phone);
        }
        #endregion
    }
}
