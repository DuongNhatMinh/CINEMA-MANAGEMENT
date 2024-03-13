using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class Movie : INotifyPropertyChanged
    {
        #region Filed
        private string _id;
        private string _name;
        private string _type;
        private string _content;
        private string _url;
        private int _duration;
        private int _status;
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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }
            public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }
            public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }
            public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
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
        public List<Schedule> lstSchedule;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Contructor
        public Movie(string id, string name, string type, string content, int duration, string url, int status, List<Schedule> lstschedule)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Content = content;
            this.Duration = duration;
            this.Url = url;
            this.Status = status;
            this.lstSchedule = lstschedule;
        }

        public Movie(string id, string name, string type, string content, int duration, string url, int status)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Content = content;
            this.Duration = duration;
            this.Url = url;
            this.Status = status;
        }

        public Movie() { }
        #endregion
    }
}
