using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class CinemaVIP : Cinema
    {
        #region Fields
        private double Fee = 40000;
        private double DiscountPrice = 5000;
        #endregion

        #region Contructor
        public CinemaVIP()
        {
        }

        public CinemaVIP(string id, string name, string cinematype, double pricecenter, List<Chair> lstchair) : base(id, name, cinematype, pricecenter, lstchair)
        {
            this.IDCinema = id;
            this.Name = name;
            this.Type = cinematype;
            this.PriceCenter = pricecenter;
            this.lstChair = lstchair;
        }
        #endregion

        #region Methods
        public double getDiscountPrice()
        {
            return DiscountPrice;
        }

        public double getFee()
        {
            return Fee;
        }

        public double getPriceCenter()
        {
            return PriceCenter;
        }

        public List<Chair> getListChair()
        {
            return lstChair;
        }
        #endregion
    }
}
