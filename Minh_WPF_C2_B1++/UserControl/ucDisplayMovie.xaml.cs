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
    /// Interaction logic for ucDisplayMovie.xaml
    /// </summary>
    public partial class ucDisplayMovie : UserControl
    {
        private int op { get; set; }
        private ucXemGia ucXemgia { get; set; }
        private ucDatVe ucdat { get; set; }
        private ObservableCollection<Movie> lstMovie { get; set; }
        private MovieViewModel movieVM { get; set; }
        private List<string> id = new List<string>();

        public ucDisplayMovie(int option)
        {
            InitializeComponent();
            op = option;
            movieVM = new MovieViewModel();
            movieVM.getList();
            lstMovie = new ObservableCollection<Movie>(movieVM.movieRepo.Items); 
        }

        public void SelectedUserControl(int option, string id, string name)
        {
            stackpanel.Children.Clear();
            switch (option)
            {
                case 1:
                    ucdat = new ucDatVe(id, name);
                    stackpanel.Children.Add(ucdat);
                    break;
                case 2:
                    ucXemgia = new ucXemGia();
                    stackpanel.Children.Add(ucXemgia);
                    break;
            }
        }

        private void Selec(int index)
        {
            if (lstMovie[index].Status != 1)
            {
                SelectedUserControl(this.op, lstMovie[index].Id, lstMovie[index].Name);
            }
            else
                MessageBox.Show("This Film is Lock");
        }

        private void btnMOV04_Click(object sender, RoutedEventArgs e)
        {
            Selec(3);
        }

        private void btnMOV05_Click(object sender, RoutedEventArgs e)
        {
            Selec(4);
        }

        private void btnMOV02_Click(object sender, RoutedEventArgs e)
        {
            Selec(1);
        }

        private void btnMOV01_Click(object sender, RoutedEventArgs e)
        {
            Selec(0);
        }

        private void btnMOV03_Click(object sender, RoutedEventArgs e)
        {
            Selec(2);
        }
    }
}
