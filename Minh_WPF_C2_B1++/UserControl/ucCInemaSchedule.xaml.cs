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
    /// Interaction logic for ucCInemaSchedule.xaml
    /// </summary>
    public partial class ucCInemaSchedule : UserControl
    {
        private ucSchedule ucschedule { get; set; }
        public ucCInemaSchedule()
        {
            InitializeComponent();
            cbCinema.Items.Add(CinemaType.Standard.ToString());
            cbCinema.Items.Add(CinemaType.Vip.ToString());
            cbCinema.SelectionChanged += CbCinema_SelectionChanged; ;
        }

        private void CbCinema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            stack.Children.Remove(ucschedule);
            ucschedule = new ucSchedule();
            stack.Children.Add(ucschedule);
        }
    }
}
