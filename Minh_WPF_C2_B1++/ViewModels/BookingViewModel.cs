using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minh_WPF_C2_B1
{
    class BookingViewModel
    {
        #region Properties
        public ChairViewModel ChairVM = new ChairViewModel();
        public OrderViewModel OrderVM = new OrderViewModel();
        public Utilities ult = new Utilities();
        #endregion

        #region Methods
        public void Order(List<Order> lstorder, Order order)
        {
            if(ult.Output(lstorder) == 1)
            {
                for (int i = 0; i < lstorder.Count; i++)
                {
                    string pathData = string.Format("data/Movies/{0}/{1}/{2}-{3}.xml", lstorder[i].IdMovie, lstorder[i].Date.Day, lstorder[i].Date.Hour, lstorder[i].Date.Minute);
                    string xpath = string.Format("Cinema[@Type='{0}']//Chair[@Name='{1}']", lstorder[i].Cinematype, lstorder[i].ChairName);
                    ChairVM.Update(xpath, pathData);
                }

                OrderVM.Create(order);
                OrderVM.Create2(lstorder);
            }
            else
            {
                return;
            }
            
        }
        #endregion
    }
}
