using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Minh_WPF_C2_B1
{
    /// <summary>
    /// Interaction logic for frmAdmin.xaml
    /// </summary>
    public partial class frmAdmin : Window
    {
        private frmLogin frmlogin { get; set; }
        private ucUser ucuser { get; set; }
        private ucMovie ucmovie { get; set; }
        private ucMovieSchedule ucschedule { get; set; }
        private ucStatistical ucThongKe { get; set; }

        public frmAdmin()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public void SelectedUserControl(int option)
        {
            stackPanel.Children.Clear();
            switch (option)
            {
                case 1:
                    ucuser = new ucUser();
                    stackPanel.Children.Add(ucuser);
                    break;
                case 2:
                    ucmovie = new ucMovie();
                    stackPanel.Children.Add(ucmovie);
                    break;
                case 3:
                    ucschedule = new ucMovieSchedule();
                    stackPanel.Children.Add(ucschedule);
                    break;
                case 4:
                    ucThongKe = new ucStatistical();
                    stackPanel.Children.Add(ucThongKe);
                    break;
                case 5:
                    this.Visibility = Visibility.Hidden;
                    frmlogin = new frmLogin();
                    frmlogin.Show();
                    break;
            }
        }

        private void menuThoat_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(5);
        }

        private void menuMovie_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(2);
        }

        private void menuUser_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(1);
        }

        private void menuAirtime_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(3);
        }

        private void menuThongKe_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(4);
        }
    }
}
