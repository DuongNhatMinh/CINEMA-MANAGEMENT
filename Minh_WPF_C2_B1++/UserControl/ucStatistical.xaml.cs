using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minh_WPF_C2_B1
{
    /// <summary>
    /// Interaction logic for ucStatistical.xaml
    /// </summary>
    public partial class ucStatistical : UserControl
    {
        private OrderViewModel orderVM = new OrderViewModel();
        private ObservableCollection<Order> lstOrderTemp { get; set; }
        private ObservableCollection<Order> lstOrder { get; set; }
        private ObservableCollection<Order> lstOrderdate { get; set; }
        private ObservableCollection<Order> lstOrderdetail { get; set; }
        private Utilities ult = new Utilities();
        private UnitOfWork unit = new UnitOfWork();
        public ucStatistical()
        {
            InitializeComponent();
            orderVM.getList();
            lstOrderTemp = new ObservableCollection<Order>(orderVM.orderRepo.Items);
            lstOrder = new ObservableCollection<Order>();
            lstOrderdate = new ObservableCollection<Order>();
            lstOrderdetail = new ObservableCollection<Order>();
            cbCinema.Items.Add(CinemaType.Standard.ToString());
            cbCinema.Items.Add(CinemaType.Vip.ToString());
            cbCinema.SelectionChanged += CbCinema_SelectionChanged;
        }

        private void CbCinema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgOrders.ItemsSource = null;
            dgOrderDetails.ItemsSource = null;
            date.SelectedDate = null;
            lstOrder = new ObservableCollection<Order>();
            if (cbCinema.SelectedIndex == 0)
            {
                for(int i = 0; i < lstOrderTemp.Count; i++)
                {
                    if(lstOrderTemp[i].Cinematype == CinemaType.Standard)
                    {
                        lstOrder.Add(lstOrderTemp[i]);
                    }
                }
                cbCinema.Text = "Standard";
            }
            else if (cbCinema.SelectedIndex == 1)
            {
                for (int i = 0; i < lstOrderTemp.Count; i++)
                {
                    if (lstOrderTemp[i].Cinematype == CinemaType.Vip)
                    {
                        lstOrder.Add(lstOrderTemp[i]);
                    }
                }
                cbCinema.Text = "Vip";
            }
        }

        private void date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dgOrders.ItemsSource = null;
            dgOrderDetails.ItemsSource = null;
            int flag = 0;
            for(int i = 0; i < lstOrder.Count; i++)
            {
                if (date.SelectedDate == null)
                    return;
                DateTime dateValue = Convert.ToDateTime(date.SelectedDate);
                if (lstOrder[i].Date.Day == dateValue.Day)
                {
                    if (lstOrder[i].Cinematype.ToString() == cbCinema.Text)
                    {
                        lstOrderdetail.Add(lstOrder[i]);
                        if (flag == 0)
                        {
                            lstOrderdate.Add(lstOrder[i]);
                            dgOrders.ItemsSource = lstOrderdate;
                            flag = 1;
                        }

                        if (ult.check(lstOrderdate, lstOrder[i].Id) == 0)
                        {
                            lstOrderdate.Add(lstOrder[i]);
                            dgOrders.ItemsSource = lstOrderdate;
                        }
                    }
                }
            }
            //lstOrder = new ObservableCollection<Order>();
            //lstOrderdate = new ObservableCollection<Order>();
        }

        private void dgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order order = dgOrders.SelectedItem as Order;
            ObservableCollection<Order> Orderdetails = new ObservableCollection<Order>();
            if (order == null)
                return;
            for(int i = 0; i < lstOrderdetail.Count; i++)
            {
                if (order.Id == lstOrderdetail[i].Id)
                {
                    Orderdetails.Add(lstOrderdetail[i]);
                }
            }
            dgOrderDetails.ItemsSource = Orderdetails;
            //lstOrderdetail = new ObservableCollection<Order>();
        }
    }
}
