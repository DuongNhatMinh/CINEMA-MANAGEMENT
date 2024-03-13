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
    /// Interaction logic for frmUser.xaml
    /// </summary>
    public partial class frmUser : Window
    {
        private ucDisplayMovie ucmovie { get; set; }
        private frmLogin frmlogin { get; set; }

        public frmUser()
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
                    ucmovie = new ucDisplayMovie(option);
                    stackPanel.Children.Add(ucmovie);
                    break;
                case 2:
                    ucmovie = new ucDisplayMovie(option);
                    stackPanel.Children.Add(ucmovie);
                    break;
                case 3:
                    this.Visibility = Visibility.Hidden;
                    frmlogin = new frmLogin();
                    frmlogin.Show();
                    break;
            }
        }

        private void menuXem_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(2);
        }

        private void menuThoat_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(3);
        }

        private void menuDat_Click(object sender, RoutedEventArgs e)
        {
            SelectedUserControl(1);
        }
    }
}
