using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_WPF_C2_B1
{
    class OrderViewModel
    {
        public Order order = new Order();
        private List<Order> lstOrder = new List<Order>();
        private static UnitOfWork unitofwork
        {
            get; set;
        }
        public RepositoryBase<Order> orderRepo { get; set; }

        public void getList()
        {
            unitofwork = new UnitOfWork();
            orderRepo = unitofwork.GetRepositoryOrder;
            lstOrder = getList("/Orders/Order");
        }

        public List<Order> getList(string xPath)
        {
            lstOrder = new List<Order>();
            DataProvider.Instance.pathData = "data/Orders.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            order = null;
            Customer customer = null;
            int Id = 0, id2;
            string IdMovie = string.Empty;
            string NameMovie = string.Empty;
            string CustomerName = string.Empty;
            string cinemaType = string.Empty;
            string Phone = string.Empty;
            DateTime Date = DateTime.Now;
            string tickettype = string.Empty;
            string chairname = string.Empty;
            double Total = 0;
            double price = 0;
            foreach (XmlNode node in lstNode)
            {
                Id = Int32.Parse(node.Attributes["Id"].Value);
                IdMovie = node.Attributes["IdMovie"].Value;
                NameMovie = node.Attributes["NameMovie"].Value;
                CustomerName = node.Attributes["CustomerName"].Value;
                cinemaType = node.Attributes["CinemaType"].Value;
                Phone = node.Attributes["Phone"].Value;
                Date = DateTime.Parse(node.Attributes["Date"].Value);
                Total = double.Parse(node.Attributes["Total"].Value);
                XmlNodeList lstNode2 = DataProvider.Instance.getDsNode("//DetailOrder");
                foreach (XmlNode node2 in lstNode2)
                {
                    id2 = Int32.Parse(node2.Attributes["IdOrder"].Value);
                    tickettype = node2.Attributes["TicketType"].Value;
                    chairname = node2.Attributes["SeatNo"].Value;
                    price = double.Parse(node2.Attributes["Price"].Value);
                    customer = new Customer(CustomerName, Phone);
                    if(Id == id2)
                    {
                        if (cinemaType == CinemaType.Standard.ToString())
                        {
                            if (tickettype == TicketType.Adult.ToString())
                                order = new Order(customer, TicketType.Adult, CinemaType.Standard, chairname, price, Date, Id, IdMovie, NameMovie, Total);
                            else
                                order = new Order(customer, TicketType.Children, CinemaType.Standard, chairname, price, Date, Id, IdMovie, NameMovie, Total);
                        }
                        else
                            order = new Order(customer, TicketType.Adult, CinemaType.Vip, chairname, price, Date, Id, IdMovie, NameMovie, Total);
                        lstOrder.Add(order);
                    }
                }  
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstOrder;
        }

        public List<Order> getListByID(string xPath)
        {
            lstOrder = new List<Order>();
            DataProvider.Instance.pathData = "data/Orders.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            order = null;
            Customer customer = null;
            int Id = 0, idorder = 0;
            string CustomerName = string.Empty;
            string cinemaType = string.Empty;
            string Phone = string.Empty;
            DateTime Date = DateTime.Now;
            string tickettype = string.Empty;
            string chairname = string.Empty;
            double Total = 0;
            double price = 0;
            DetailOrder detailorder = null;
            foreach (XmlNode node in lstNode)
            {
                Id = Int32.Parse(node.Attributes["Id"].Value);
                CustomerName = node.Attributes["CustomerName"].Value;
                cinemaType = node.Attributes["CinemaType"].Value;
                Phone = node.Attributes["Phone"].Value;
                Date = DateTime.Parse(node.Attributes["Date"].Value);
                Total = double.Parse(node.Attributes["Total"].Value);
                customer = new Customer(CustomerName, Phone);
                XmlNodeList lstNode2 = DataProvider.Instance.getDsNode("//DetailOrder");
                List<DetailOrder> lstDetailOrder = new List<DetailOrder>();
                foreach (XmlNode node2 in lstNode2)
                {
                    idorder = Int32.Parse(node2.Attributes["IdOrder"].Value);
                    tickettype = node2.Attributes["TicketType"].Value;
                    chairname = node2.Attributes["SeatNo"].Value;
                    price = double.Parse(node2.Attributes["Price"].Value);
                    if (cinemaType == CinemaType.Standard.ToString())
                    {
                        if (tickettype == TicketType.Adult.ToString())
                        {
                            detailorder = new DetailOrder(TicketType.Adult, chairname, price, idorder);
                            if (detailorder.Id == Id)
                            {
                                lstDetailOrder.Add(detailorder);
                                order = new Order(customer, CinemaType.Standard, Date, Id, Total, lstDetailOrder);
                            }
                        }
                        else
                        {
                            detailorder = new DetailOrder(TicketType.Children, chairname, price, idorder);
                            if (detailorder.Id == Id)
                            {
                                lstDetailOrder.Add(detailorder);
                                order = new Order(customer, CinemaType.Standard, Date, Id, Total, lstDetailOrder);
                            }
                        }
                    }
                    else
                    {
                        detailorder = new DetailOrder(TicketType.Adult, chairname, price, idorder);
                        if (detailorder.Id == Id)
                        {
                            lstDetailOrder.Add(detailorder);
                            order = new Order(customer, CinemaType.Vip, Date, Id, Total, lstDetailOrder);
                        }
                    }
                }
                lstOrder.Add(order);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstOrder;
        }

        public List<DetailOrder> getListTheoCinemaType(string xPath)
        {
            List<DetailOrder> lstDetailOrder = new List<DetailOrder>();
            DataProvider.Instance.pathData = "data/Orders.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            DetailOrder detailorder = null;
            int Id = 0;
            string tickettype = string.Empty;
            string chairname = string.Empty;
            double price = 0;
            foreach (XmlNode node in lstNode)
            {
                Id = Int32.Parse(node.Attributes["IdOrder"].Value);
                tickettype = node.Attributes["TicketType"].Value;
                chairname = node.Attributes["SeatNo"].Value;
                price = double.Parse(node.Attributes["Price"].Value);
                if (tickettype == TicketType.Adult.ToString())
                    detailorder = new DetailOrder(TicketType.Adult, chairname, price, Id);
                else
                    detailorder = new DetailOrder(TicketType.Children, chairname, price, Id);
                lstDetailOrder.Add(detailorder);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstDetailOrder;
        }

        public void Create(Order order)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            string[] date = order.Date.GetDateTimeFormats(culture);
            DataProvider.Instance.pathData = "data/Orders.xml";
            var newNode = DataProvider.Instance.createNode("Order");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = order.Id.ToString();
            var attr2 = DataProvider.Instance.createAttr("IdMovie");
            attr2.Value = order.IdMovie.ToString();
            var attr3 = DataProvider.Instance.createAttr("NameMovie");
            attr3.Value = order.NameMovie.ToString();
            var attr4 = DataProvider.Instance.createAttr("CinemaType");
            attr4.Value = order.Cinematype.ToString();
            var attr5 = DataProvider.Instance.createAttr("CustomerName");
            attr5.Value = order.Customer.Name;
            var attr6 = DataProvider.Instance.createAttr("Phone");
            attr6.Value = order.Customer.Phone;
            var attr7 = DataProvider.Instance.createAttr("Date");
            attr7.Value = date[29];
            var attr8 = DataProvider.Instance.createAttr("Total");
            attr8.Value = order.Total.ToString();
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.Attributes.Append(attr3);
            newNode.Attributes.Append(attr4);
            newNode.Attributes.Append(attr5);
            newNode.Attributes.Append(attr6);
            newNode.Attributes.Append(attr7);
            newNode.Attributes.Append(attr8);
            newNode.InnerText = string.Empty;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Create2(List<Order> lstorder)
        {
            DataProvider.Instance.pathData = "data/Orders.xml";
            for(int i = 0; i < lstorder.Count; i++)
            {
                var newNode = DataProvider.Instance.createNode("DetailOrder");
                var attr1 = DataProvider.Instance.createAttr("IdOrder");
                attr1.Value = lstorder[i].Id.ToString();
                var attr2 = DataProvider.Instance.createAttr("TicketType");
                attr2.Value = lstorder[i].Tickettype.ToString();
                var attr3 = DataProvider.Instance.createAttr("SeatNo");
                attr3.Value = lstorder[i].ChairName.ToString();
                var attr4 = DataProvider.Instance.createAttr("Price");
                attr4.Value = lstorder[i].Price.ToString();
                newNode.Attributes.Append(attr1);
                newNode.Attributes.Append(attr2);
                newNode.Attributes.Append(attr3);
                newNode.Attributes.Append(attr4);
                DataProvider.Instance.Open(); // Mở tài liệu Xml
                string xpath = string.Format("Order[@CustomerName='{0}']", lstorder[i].Customer.Name);
                var node = DataProvider.Instance.getNode(xpath);
                DataProvider.Instance.AppendNode(node, newNode);
                DataProvider.Instance.Close(); // Đóng tài liệu Xml
            }
        }
    }
}
