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
    /// Interaction logic for ucDatVe.xaml
    /// </summary>
    public partial class ucXemGia : UserControl
    {
        const int margin = 5;
        const int padding = 5;
        const int s = 50;
        const int value = 5;
        public int nRow;
        public int nColumn;
        private CinemaStandardViewModel cinemastandardVM = new CinemaStandardViewModel();
        private CinemaVipViewModel cinemavipVM = new CinemaVipViewModel();
        private ChairViewModel chairVM = new ChairViewModel();
        private ObservableCollection<Chair> lstchair { get; set; }
        private Utilities ult = new Utilities();
        private UnitOfWork unit = new UnitOfWork();

        public ucXemGia()
        {
            InitializeComponent();
            chairVM.getList();
            lstchair = new ObservableCollection<Chair>(chairVM.chairRepo.Items);
            cbCinema.Items.Add(CinemaType.Standard.ToString());
            cbCinema.Items.Add(CinemaType.Vip.ToString());
            cbCinema.DropDownClosed += CbCinema_DropDownClosed;
        }

        private void CbCinema_DropDownClosed(object sender, EventArgs e)
        {
            lstb.Items.Clear();
            if (cbCinema.Text == CinemaType.Standard.ToString())
            {
                CinemaStandard CinemaStandard = new CinemaStandard();
                CinemaStandard = cinemastandardVM.getItem(0);
                init(0);
            }
            else if (cbCinema.Text == CinemaType.Vip.ToString())
            {
                CinemaVIP Cinemavip = new CinemaVIP();
                Cinemavip = cinemavipVM.getItem(1);
                init(25);
            }
        }

        private void init(int idx)
        {
            int count = idx;
            nRow = value;
            nColumn = value;
            StackPanel stackpanel = new StackPanel();
            Button[][] btn = new Button[nRow][];
            for (int i = 0; i < nRow; i++)
            {
                stackpanel = new StackPanel();
                stackpanel.Children.Capacity = nColumn;
                btn[i] = new Button[nColumn];
                for (int j = 0; j < nColumn; j++)
                {
                    btn[i][j] = new Button();
                    btn[i][j].Margin = new Thickness(margin);
                    btn[i][j].Padding = new Thickness(padding);
                    btn[i][j].Height = s;
                    btn[i][j].Width = s;
                    btn[i][j].Content = lstchair[count].Name;
                    stackpanel.Orientation = Orientation.Horizontal;
                    stackpanel.Children.Add(btn[i][j]);
                    btn[i][j].Background = Brushes.Cyan ;
                    btn[i][j].Click += UcBanVe_Click;
                    if (lstchair[count++].Status == 1)
                    {
                        btn[i][j].Background = Brushes.OrangeRed;
                    }

                }
                lstb.Items.Add(stackpanel);
            }
        }

        private void UcBanVe_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as Button;
            Chair chair = new Chair();
            chair = chairVM.SearchByName(item.Content.ToString());
            if (cbCinema.Text == CinemaType.Standard.ToString())
                ult.Convert(cinemastandardVM.DoDiscount(chair.Type), chair.Name);
            else
                ult.Convert(cinemavipVM.DoDiscount(chair.Type), chair.Name);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbCinema.SelectedIndex = -1;
        }
    }
}
