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
    /// Interaction logic for ucMovie.xaml
    /// </summary>
    public partial class ucMovie : UserControl
    {
        private ObservableCollection<Movie> lstMovie { get; set; }
        private ObservableCollection<Movie> Movies { get; set; }
        private MovieViewModel movieVM { get; set; }
        public frmMessage frmmess { get; set; }

        public ucMovie()
        {
            InitializeComponent();
            movieVM = new MovieViewModel();
            movieVM.getList();
            lstMovie = new ObservableCollection<Movie>(movieVM.movieRepo.Items);
            Movies = new ObservableCollection<Movie>();
            for(int i = 0; i < lstMovie.Count; i++)
            {
                if(lstMovie[i].Status != 1)
                {
                    Movies.Add(lstMovie[i]);
                }
            }
            dtgMovie.ItemsSource = Movies;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Movie;
            frmmess = new frmMessage(item, 3);
            frmmess.ShowDialog();
            if (frmmess.check == 1)
            {
                string xpath = string.Format("Movie[@Id='{0}']", item.Id);
                Movie newmovie = new Movie(item.Id, frmmess.uceditmovie.txtName.Text, frmmess.uceditmovie.txtType.Text, frmmess.uceditmovie.txtContent.Text,
                    Int32.Parse(frmmess.uceditmovie.txtDuration.Text), frmmess.uceditmovie.txtUrl.Text, item.Status, item.lstSchedule);
                movieVM.Update(xpath, newmovie);
                Movies[dtgMovie.SelectedIndex].Name = frmmess.uceditmovie.txtName.Text;
                Movies[dtgMovie.SelectedIndex].Type = frmmess.uceditmovie.txtType.Text;
                Movies[dtgMovie.SelectedIndex].Content = frmmess.uceditmovie.txtContent.Text;
                Movies[dtgMovie.SelectedIndex].Duration = Int32.Parse(frmmess.uceditmovie.txtDuration.Text);
                Movies[dtgMovie.SelectedIndex].Url = frmmess.uceditmovie.txtUrl.Text;

                lstMovie[dtgMovie.SelectedIndex].Name = frmmess.uceditmovie.txtName.Text;
                lstMovie[dtgMovie.SelectedIndex].Type = frmmess.uceditmovie.txtType.Text;
                lstMovie[dtgMovie.SelectedIndex].Content = frmmess.uceditmovie.txtContent.Text;
                lstMovie[dtgMovie.SelectedIndex].Duration = Int32.Parse(frmmess.uceditmovie.txtDuration.Text);
                lstMovie[dtgMovie.SelectedIndex].Url = frmmess.uceditmovie.txtUrl.Text;
            }
            else
            {
                return;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int id = Movies.Count;
            id++;
            var item = (sender as Button).DataContext as Movie;
            frmmess = new frmMessage(0, 3);
            frmmess.ShowDialog();
            if (frmmess.check == 1)
            {
                Movie newmovie = new Movie("MOV0" + id, frmmess.uceditmovie.txtName.Text, frmmess.uceditmovie.txtType.Text, frmmess.uceditmovie.txtContent.Text,
                    Int32.Parse(frmmess.uceditmovie.txtDuration.Text), frmmess.uceditmovie.txtUrl.Text, 0);
                movieVM.Create(newmovie);
                Movies.Add(newmovie);
                lstMovie.Add(newmovie);
            }
            else
            {
                return;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Movie;
            string str = string.Format("You want Delete {0} ?", item.Name);
            MessageBoxResult result = MessageBox.Show(str, "Delete", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (item != null)
                    {
                        Movies.Remove(item);
                        lstMovie.Remove(item);
                        string xpath = string.Format("Movie[@Id='{0}']", item.Id);
                        movieVM.Update(xpath);
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
