using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class Order
    {
        #region Fields
        public Customer Customer { get; set; }
        public TicketType Tickettype { get; set; }
        public CinemaType Cinematype { get; set; }
        public string ChairName { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string IdMovie { get; set; }
        public string NameMovie { get; set; }
        public double Total{ get; set; }
        public List<DetailOrder> lstDetailOrder { get; set; }
        #endregion

        public Order()
        {

        }

        public Order(Customer customer, TicketType tickettype, CinemaType cinematype, string chairname, double price, DateTime date, int id, string idmovie, string namemovie, double total)
        {
            this.Customer = customer;
            this.Tickettype = tickettype;
            this.Cinematype = cinematype;
            this.ChairName = chairname;
            this.Price = price;
            this.Date = date;
            this.Id = id;
            this.IdMovie = idmovie;
            this.NameMovie = namemovie;
            this.Total = total;
        }

        public Order(Customer customer, CinemaType cinematype, DateTime date, int id, double total, List<DetailOrder> lstdetailorder)
        {
            this.Customer = customer;
            this.Cinematype = cinematype;
            this.Date = date;
            this.Id = id;
            this.Total = total;
            this.lstDetailOrder = lstdetailorder;
        }
    }
}
