using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    public class Account : INotifyPropertyChanged
    {
        private string _Username;
        private string _Password;
        private int _Status;
        public string UserName {
            get { return _Username; }
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get { return _Password; }
            set
            {
                _Password = value;
                OnPropertyChanged();
            }
        }
        public string Role { get; set; }
        public int Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Account()
        {
            this.UserName = string.Empty;
            this.Password = string.Empty;
        }

        public Account(string username, string password, string role, int status)
        {
            this.UserName = username;
            this.Password = password;
            this.Role = role;
            this.Status = status;
        }
    }
}
