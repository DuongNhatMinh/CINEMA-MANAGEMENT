using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1

{
    class Cinema
    {
        #region Properties
        protected string IDCinema;
        protected string Name;
        public string Type;
        protected double PriceCenter;
        protected List<Chair> lstChair;
        #endregion

        #region Contructor
        public Cinema(string id, string name, string cinematype, double pricecenter, List<Chair> lstchair)
        {
            this.IDCinema = id;
            this.Name = name;
            this.Type = cinematype;
            this.PriceCenter = pricecenter;
            this.lstChair = lstchair;
        }

        public Cinema() { }
        #endregion
    }
}
