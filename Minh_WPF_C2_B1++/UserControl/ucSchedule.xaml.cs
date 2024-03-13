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
    /// Interaction logic for ucSchedule.xaml
    /// </summary>
    public partial class ucSchedule : UserControl
    {
        private ObservableCollection<Schedule> lstSchedule { get; set; }
        private ObservableCollection<Schedule> lstSchedule2 { get; set; }
        private ScheduleViewModel scheduleVM { get; set; }
        private ObservableCollection<Showtime> lstTime { get; set; }
        public frmMessage frmmess { get; set; }

        public ucSchedule()
        {
            InitializeComponent();
            scheduleVM = new ScheduleViewModel();
            scheduleVM.getList();
            lstSchedule = new ObservableCollection<Schedule>(scheduleVM.scheduleRepo.Items);
            lstSchedule2 = new ObservableCollection<Schedule>();

            for(int i = 0; i < lstSchedule.Count; i++)
            {
                if(lstSchedule[i].Status != 1)
                {
                    lstSchedule2.Add(lstSchedule[i]);
                }
            }
            dtgSchedule.ItemsSource = lstSchedule2;
            dtgShowtime.Visibility = Visibility.Hidden;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Schedule;
            frmmess = new frmMessage(item, 4);
            frmmess.ShowDialog();
            if (frmmess.check == 1)
            {
                string xpath = string.Format("Schedule[@Id='{0}']", item.Id);
                Schedule newSchedule = new Schedule(item.Id, DateTime.Parse(frmmess.ucEditSche.dtpdate.Text), item.Status, item.lstShowtime);
                scheduleVM.Update(xpath, newSchedule);
                lstSchedule2[dtgSchedule.SelectedIndex].Date = DateTime.Parse(frmmess.ucEditSche.dtpdate.Text);
                lstSchedule[dtgSchedule.SelectedIndex].Date = DateTime.Parse(frmmess.ucEditSche.dtpdate.Text);
            }
            else
            {
                return;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Schedule;
            string str = string.Format("You want Delete {0} ?", item.Date);
            MessageBoxResult result = MessageBox.Show(str, "Delete", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (item != null)
                    {
                        lstSchedule2.Remove(item);
                        lstSchedule.Remove(item);
                        string xpath = string.Format("Schedule[@Id='{0}']", item.Id);
                        scheduleVM.Update(xpath);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Schedule;
            int id = lstSchedule2.Count;
            id++;
            frmmess = new frmMessage(0, 4);
            frmmess.ShowDialog();
            if (frmmess.check == 1)
            {
                Schedule newSchedule = new Schedule("LT0" + id, DateTime.Parse(frmmess.ucEditSche.dtpdate.Text), 0, item.lstShowtime);
                scheduleVM.Create(newSchedule);
                lstSchedule2.Add(newSchedule);
                lstSchedule.Add(newSchedule);
            }
            else
            {
                return;
            }
        }

        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            dtgShowtime.Visibility = Visibility.Visible;
            lstTime = new ObservableCollection<Showtime>();
            Showtime time = null;
            var item = (sender as Button).DataContext as Schedule;
            if (item != null)
            {
                if(dtgSchedule.SelectedIndex == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        time = new Showtime(item.lstShowtime[i].Hour, item.lstShowtime[i].Minute);
                        lstTime.Add(time);
                    }
                    dtgShowtime.ItemsSource = lstTime; 
                }
                else
                {
                    for (int i = 5; i < 10; i++)
                    {
                        time = new Showtime(item.lstShowtime[i].Hour, item.lstShowtime[i].Minute);
                        lstTime.Add(time);
                    }
                    dtgShowtime.ItemsSource = lstTime;
                } 
            }   
        }

        private void btnEditTime_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Showtime;
            var item2 = dtgSchedule.SelectedItem as Schedule;
            frmmess = new frmMessage(item, 5);
            frmmess.ShowDialog();
            if (frmmess.check == 1)
            {
                List<Showtime> times = new List<Showtime>();
                string xpath = string.Format("Schedule[@Id='{0}']/Showtime[@Hour='0{1}']",item2.Id, item.Hour);
                Showtime time = new Showtime(Int32.Parse(frmmess.ucEditshowtime.txtHour.Text), Int32.Parse(frmmess.ucEditshowtime.txtMinute.Text));
                times.Add(time);
                Schedule newSchedule = new Schedule(item2.Id, item2.Date, item2.Status, times);
                scheduleVM.Update(xpath, time);
                lstSchedule2[dtgSchedule.SelectedIndex].lstShowtime[dtgShowtime.SelectedIndex].Hour = Int32.Parse(frmmess.ucEditshowtime.txtHour.Text);
                lstSchedule2[dtgSchedule.SelectedIndex].lstShowtime[dtgShowtime.SelectedIndex].Minute = Int32.Parse(frmmess.ucEditshowtime.txtMinute.Text);
            }
            else
            {
                return;
            }
        }
    }
}
