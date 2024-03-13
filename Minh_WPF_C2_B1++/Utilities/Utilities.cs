using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minh_WPF_C2_B1
{
    class Utilities
    {
        frmMessage frmmess { get; set; }
        #region Methods
        public void Convert(int value, string name)
        {
            string str;
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            str = value.ToString("N0", culture);
            MessageBox.Show("Name Seat: " + name + "\n" + "Price: " + (str + "VND\n"));
        }

        public void Convert(double value, string name)
        {
            string str;
            var culture = new CultureInfo("en-US");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            str = value.ToString("N0", culture);
            MessageBox.Show("Name Seat: " + name + "\n" + "Price: " + (str + "VND\n"));
        }

        public int getIndex(List<Chair> lstChair, string name, string type)
        {
            if(type == CinemaType.Standard.ToString())
            {
                for (int i = 0; i < 25; i++)
                {
                    if (lstChair[i].Name == name)
                        return i;
                }
            }
            else
            {
                for (int i = 25; i < lstChair.Count; i++)
                {
                    if (lstChair[i].Name == name)
                        return i;
                }
            } 
            return -1;
        }

        public int check(ObservableCollection<Chair> lstChair, int index)
        {
            if (lstChair[index].Status == 1)
                return 1;
            return 0;
        }

        public int Output(List<Order> lstOrder)
        {
            frmmess = new frmMessage(lstOrder, 1);
            frmmess.ShowDialog();
            if (frmmess.check == 2)
                return 2;
            else if (frmmess.check == 1)
                return 1;
            return 0;
        }

        public void Notify()
        {
            MessageBox.Show("Login Fail");
            return;
        }

        public int checkType(List<Order> lstorder, int idx, CinemaType cinematype)
        {
            if (lstorder[idx].Cinematype == cinematype)
                return 1;
            return -1;
        }

        public int getIndex(List<Order> lstorder, CinemaType cinematype)
        {
            for (int i = 0; i < lstorder.Count; i++)
            {
                if (checkType(lstorder, i, cinematype) == 1)
                    return i;
            }
            return -1;
        }

        public int checkDate(List<Order> lstorder, int day, int month, int year)
        {
            for(int idx = 0; idx < lstorder.Count; idx++)
            {
                if (lstorder[idx].Date.Day == day && lstorder[idx].Date.Month == month && lstorder[idx].Date.Year == year)
                    return idx;
            }
            return -1;
        }

        public int checkItem(List<Order> lstorder)
        {
            if (lstorder.Count == 0)
                return 1;
            return 0;
        }

        public double getRevenue(List<DetailOrder> lstdetailorder, double revenue)
        {
            for(int i = 0; i < lstdetailorder.Count; i++)
            {
                revenue += lstdetailorder[i].Price;
            }
            return revenue;
        }

        public int check(ObservableCollection<Order> lstOrderdate, int id)
        {
            for (int j = 0; j < lstOrderdate.Count; j++)
            {
                if (id == lstOrderdate[j].Id)
                {
                    return 1;
                }
            }
            return 0;
        }
        #endregion
    }
}
