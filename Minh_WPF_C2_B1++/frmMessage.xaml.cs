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
using System.Windows.Shapes;

namespace Minh_WPF_C2_B1
{
    /// <summary>
    /// Interaction logic for frmMessage.xaml
    /// </summary>
    public partial class frmMessage : Window
    {
        ucBills ucbill { get; set; }
        public ucEditUser ucedit { get; set; }
        public ucEditMovie uceditmovie { get; set; }
        public ucEditSchedule ucEditSche { get; set; }
        public ucEditShowtime ucEditshowtime { get; set; }
        object valuetemp;
        public int check = 0;

        public frmMessage(object Value, int op)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            valuetemp = Value;
            SelectedUserControl(op);
        }

        public void SelectedUserControl(int option)
        {
            stackpanel.Children.Clear();
            switch (option)
            {
                case 1:
                    ucbill = new ucBills(valuetemp);
                    stackpanel.Children.Add(ucbill);
                    break;
                case 2:
                    ucedit = new ucEditUser(valuetemp);
                    stackpanel.Children.Add(ucedit);
                    break;
                case 3:
                    uceditmovie = new ucEditMovie(valuetemp);
                    stackpanel.Children.Add(uceditmovie);
                    break;
                case 4:
                    ucEditSche = new ucEditSchedule(valuetemp);
                    stackpanel.Children.Add(ucEditSche);
                    break;
                case 5:
                    ucEditshowtime = new ucEditShowtime(valuetemp);
                    stackpanel.Children.Add(ucEditshowtime);
                    break;
            }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            check = 1;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            check = 2;
        }
    }
}
