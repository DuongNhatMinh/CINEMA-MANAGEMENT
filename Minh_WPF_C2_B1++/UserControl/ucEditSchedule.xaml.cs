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
    /// Interaction logic for ucEditSchedule.xaml
    /// </summary>
    public partial class ucEditSchedule : UserControl
    {
        public ucEditSchedule(object value)
        {
            InitializeComponent();
            Schedule schedule = value as Schedule;
            dtpdate.Text = schedule.Date.ToString();
        }
    }
}
