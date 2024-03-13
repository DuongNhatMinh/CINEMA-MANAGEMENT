using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_WPF_C2_B1
{
    class CinemaStandardViewModel : IDiscount, IChildrenDiscount
    {
        public CinemaStandard cinemastandard = new CinemaStandard();
        private List<Chair> lstChair = new List<Chair>();
        private ChairViewModel ChairVM = new ChairViewModel();

        public CinemaStandard getItem(int index)
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
            cinemastandard = new CinemaStandard(Id, Name, Type, Price, lstChair);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return cinemastandard;
        }

        public double DoDiscount(char type)
        {
            if (type == 'A')
                return cinemastandard.getPriceCenter() - 2 * cinemastandard.getDiscountPrice();
            else if (type == 'B')
                return cinemastandard.getPriceCenter() - cinemastandard.getDiscountPrice();
            else if (type == 'C')
                return cinemastandard.getPriceCenter();
            else if (type == 'D')
                return cinemastandard.getPriceCenter() - cinemastandard.getDiscountPrice();
            else if (type == 'E')
                return cinemastandard.getPriceCenter() - 2 * cinemastandard.getDiscountPrice();
            return 0;
        }

        public double DiscountChild(char type)
        {
            return DoDiscount(type) * 0.5;
        }
    }
}
