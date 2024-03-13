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
using System.Windows.Shapes;

namespace Minh_WPF_C2_B1
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        private Account acc { get; set; }
        private AccountViewModel accVM { get; set; }
        private Utilities ult { get; set; }
        private frmUser frmNVBV { get; set; }
        private frmAdmin frmadmin { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            acc = new Account();
            accVM = new AccountViewModel();
            ult = new Utilities();
            accVM.getList();
            this.txtUsername.Focus();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public void Login()
        {
            string check;
            check = accVM.Compare(txtUsername.Text, pwbPassword.Password);
            if (check == string.Empty)
                ult.Notify();
            switch (check)
            {
                case "QL":
                    frmadmin = new frmAdmin();
                    frmadmin.Show();
                    //this.Visibility = Visibility.Hidden;
                    this.Close();
                    break;
                case "BV":
                    frmNVBV = new frmUser();
                    frmNVBV.Show();
                    //this.Visibility = Visibility.Hidden;
                    this.Close();
                    break;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login();
            txtUsername.Text = acc.UserName;
            pwbPassword.Password = acc.Password;
            this.txtUsername.Focus();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login();
                txtUsername.Text = acc.UserName;
                pwbPassword.Password = acc.Password;
                this.txtUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
