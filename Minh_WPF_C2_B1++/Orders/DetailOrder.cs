using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class DetailOrder
    {
        #region Fields
        public TicketType Tickettype { get; set; }
        public string ChairName { get; set; }
        public double Price { get; set; }
        public int Id { get; set; }
        #endregion

        public DetailOrder()
        {

        }

        public DetailOrder(TicketType tickettype, string chairname, double price, int id)
        {
            this.Tickettype = tickettype;
            this.ChairName = chairname;
            this.Price = price;
            this.Id = id;
        }
    }
}
