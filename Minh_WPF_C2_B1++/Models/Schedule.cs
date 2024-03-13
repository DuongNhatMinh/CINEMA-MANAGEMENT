using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class Schedule : INotifyPropertyChanged
    {
        #region Filed
        private string _id;
        private DateTime _date;
        private int _status;
        private List<Showtime> _lstshowtime;
        #endregion

        #region Properties
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }
        public List<Showtime> lstShowtime
        {
            get { return _lstshowtime; }
            set
            {
                _lstshowtime = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Contructor
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Schedule(string id, DateTime date, int status, List<Showtime> lstshowtime)
        {
            this.Id = id;
            this.Date = date;
            this.Status = status;
            this.lstShowtime = lstshowtime; 
        }

        public Schedule()
        {
            this.Id = string.Empty;
            this.Date = DateTime.Today;
            this.lstShowtime = null;
            this.Status = 0;
        }
        #endregion
    }
}
