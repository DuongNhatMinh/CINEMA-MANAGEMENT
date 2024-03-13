using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class CinemaStandard : Cinema
    {
        private double DiscountPrice = 10000;

        public CinemaStandard()
        {
        }

        public CinemaStandard(string id, string name, string cinematype, double pricecenter, List<Chair> lstchair) : base(id, name, cinematype, pricecenter, lstchair)
        {
            this.IDCinema = id;
            this.Name = name;
            this.Type = cinematype;
            this.PriceCenter = pricecenter;
            this.lstChair = lstchair;
        }

        public double getDiscountPrice()
        {
            return DiscountPrice;
        }

        public double getPriceCenter()
        {
            return PriceCenter;
        }

        public List<Chair> getListChair()
        {
            return lstChair;
        }
    }
}
