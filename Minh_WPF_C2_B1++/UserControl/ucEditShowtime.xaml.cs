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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minh_WPF_C2_B1
{
    /// <summary>
    /// Interaction logic for ucEditShowtime.xaml
    /// </summary>
    public partial class ucEditShowtime : UserControl
    {
        public ucEditShowtime(object value)
        {
            InitializeComponent();
            Showtime time = value as Showtime;
            txtHour.Text = time.Hour.ToString();
            txtMinute.Text = time.Minute.ToString();
        }
    }
}
