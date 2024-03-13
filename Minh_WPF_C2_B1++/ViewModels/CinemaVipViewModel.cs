using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_WPF_C2_B1
{
    class CinemaVipViewModel : IDiscount, IDisCountThursday
    {
        public CinemaVIP cinemavip = new CinemaVIP();
        private List<Chair> lstChair = new List<Chair>();
        private ChairViewModel ChairVM = new ChairViewModel();

        public CinemaVIP getItem(int index)
        {
            string Id = string.Empty;
            string Name = string.Empty;
            string Type = string.Empty;
            double Price = 0;
            DataProvider.Instance.pathData = "data/Cinemas.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            string xPath = string.Format("/CinemaStore/Cinema");
            XmlNode node = DataProvider.Instance.getNode(xPath, index);
            Id = node.Attributes["IdCinema"].Value;
            Name = node.Attributes["Name"].Value;
            Type = node.Attributes["Type"].Value;
            Price = Double.Parse(node.Attributes["PriceCenter"].Value);
            lstChair = ChairVM.getList("/CinemaStore/Cinema//Chair");
            cinemavip = new CinemaVIP(Id, Name, Type, Price, lstChair);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return cinemavip;
        }

        public double DoDiscount(char type)
        {
            if (type == 'A')
                return cinemavip.getPriceCenter() - 2 * cinemavip.getDiscountPrice() + cinemavip.getFee();
            else if (type == 'B')
                return cinemavip.getPriceCenter() - cinemavip.getDiscountPrice() + cinemavip.getFee();
            else if (type == 'C')
                return cinemavip.getPriceCenter() + cinemavip.getFee();
            else if (type == 'D')
                return cinemavip.getPriceCenter() - cinemavip.getDiscountPrice() + cinemavip.getFee();
            else if (type == 'E')
                return cinemavip.getPriceCenter() - 2 * cinemavip.getDiscountPrice() + cinemavip.getFee();
            return 0;
        }

        public double DiscountThursday(char type)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                return DoDiscount(type) * 0.9;
            }
            else
                return DoDiscount(type);
        }
    }
}
