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
    /// Interaction logic for ucMovieSchedule.xaml
    /// </summary>
    public partial class ucMovieSchedule : UserControl
    {
        private ObservableCollection<Movie> lstMovie { get; set; }
        private ObservableCollection<Movie> Movies { get; set; }
        private MovieViewModel movieVM { get; set; }
        private ucSchedule ucschedule { get; set; }
        private ucCInemaSchedule uccinemaschedule { get; set; }

        public ucMovieSchedule()
        {
            InitializeComponent();
            movieVM = new MovieViewModel();
            movieVM.getList();
            lstMovie = new ObservableCollection<Movie>(movieVM.movieRepo.Items);
            Movies = new ObservableCollection<Movie>();
            for (int i = 0; i < lstMovie.Count; i++)
            {
                if (lstMovie[i].Status != 1)
                {
                    Movies.Add(lstMovie[i]);
                }
            }
            dtgMovie.ItemsSource = Movies;
        }

        private void dtgMovie_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            stack.Children.Remove(this.dtgMovie);
            uccinemaschedule = new ucCInemaSchedule();
            stack.Children.Add(uccinemaschedule);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Movie;
            MessageBoxResult result = MessageBox.Show("You want delete this ?", "Delete", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (item != null)
                    {
                        lstMovie.Remove(item);
                        Movies.Remove(item);
                        string xpath = string.Format("Movie[@Id='{0}']", item.Id);
                        movieVM.Update(xpath);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            stack.Children.Remove(this.dtgMovie);
            uccinemaschedule = new ucCInemaSchedule();
            stack.Children.Add(uccinemaschedule);
        }
    }
}
