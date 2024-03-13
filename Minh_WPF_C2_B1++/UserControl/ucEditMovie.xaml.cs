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
    /// Interaction logic for ucEditMovie.xaml
    /// </summary>
    public partial class ucEditMovie : UserControl
    {
        public ucEditMovie(object value)
        {
            Movie movie = value as Movie;
            InitializeComponent();
            this.txtName.Focus();
            if(movie != null)
            {
                txtName.Text = movie.Name;
                txtContent.Text = movie.Content;
                txtType.Text = movie.Type;
                txtDuration.Text = movie.Duration.ToString();
                txtUrl.Text = movie.Url;
            }
        }
    }
}
