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
    /// Interaction logic for ucBills.xaml
    /// </summary>
    public partial class ucBills : UserControl
    {
        public ucBills(object lstOrder)
        {
            InitializeComponent();
            dtgBill.ItemsSource = lstOrder as List<Order>;
        }
    }
}
