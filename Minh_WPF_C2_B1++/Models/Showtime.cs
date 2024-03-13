using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class Showtime : INotifyPropertyChanged
    {
        private int _hour;
        private int _minute;
        #region Properties
        public int Hour
        {
            get { return _hour; }
            set
            {
                _hour = value;
                OnPropertyChanged();
            }
        }
        public int Minute
        {
            get { return _minute; }
            set
            {
                _minute = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Contructor
        public Showtime(int hour, int minute)
        {
            this.Hour = hour;
            this.Minute = minute;
        }

        public Showtime()
        {
            this.Hour = 0;
            this.Minute = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
