using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_WPF_C2_B1
{
    class MovieViewModel
    {
        #region Properties
        private static UnitOfWork unitofwork
        {
            get; set;
        }
        public RepositoryBase<Movie> movieRepo { get; set; }
        public List<Movie> lstMovie = new List<Movie>();
        public List<Schedule> lstSchedule = new List<Schedule>();
        public List<Showtime> lstShowtime = new List<Showtime>();
        #endregion

        #region Methods
        public void getList()
        {
            unitofwork = new UnitOfWork();
            movieRepo = unitofwork.GetRepositoryMovie;
            lstMovie = getList("/Movie");
        }

        public List<Movie> getList(string xPath)
        {
            DataProvider.Instance.pathData = "data/Movies/Movies.xml";
            //lstMovie = new List<Movie>();
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            Movie movie = null;
            Schedule schedule = null;
            Showtime showtime = null;
            string Id = string.Empty;
            string Id2 = string.Empty;
            string Name = string.Empty;
            string type = string.Empty;
            string Content = string.Empty;
            int Duration = 0;
            string url = string.Empty;
            int status = 0;
            DateTime date = DateTime.Now;
            int hour = 0, minute;
            foreach (XmlNode node in lstNode)
            {
                Id = node.Attributes["Id"].Value;
                Name = node.Attributes["Name"].Value;
                type = node.Attributes["Type"].Value;
                Content = node.Attributes["Content"].Value;
                Duration = Int32.Parse(node.Attributes["Duration"].Value);
                url = node.Attributes["Url"].Value;
                status = Int32.Parse(node.Attributes["Status"].Value);
                DataProvider.Instance.pathData = "data/Movies/Schedule.xml";
                //lstMovie = new List<Movie>();
                DataProvider.Instance.Open();
                XmlNodeList ListNode2 = DataProvider.Instance.getDsNode("Schedule");
                foreach(XmlNode node2 in ListNode2)
                {
                    int status2 = 0;
                    Id2 = node2.Attributes["Id"].Value;
                    date = DateTime.Parse(node2.Attributes["Date"].Value);
                    status2 = Int32.Parse(node.Attributes["Status"].Value);
                    lstShowtime = new List<Showtime>();
                    XmlNodeList ListNode3 = DataProvider.Instance.getDsNode("//Showtime");
                    foreach (XmlNode item in ListNode3)
                    {
                        hour = Int32.Parse(item.Attributes["Hour"].Value);
                        minute = Int32.Parse(item.Attributes["Minute"].Value);
                        showtime = new Showtime(hour, minute);
                        lstShowtime.Add(showtime);
                    }
                    schedule = new Schedule(Id2, date, status2, lstShowtime);
                    lstSchedule.Add(schedule);
                }
                movie = new Movie(Id, Name, type, Content, Duration, url, status, lstSchedule);
                lstMovie.Add(movie);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstMovie;
        }

        public void Update(string xPath)
        {
            DataProvider.Instance.pathData = "data/Movies/Movies.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Status"].Value = 1.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Update(string xPath, Movie movie)
        {
            DataProvider.Instance.pathData = "data/Movies/Movies.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Name"].Value = movie.Name.ToString();
            node.Attributes["Type"].Value = movie.Type.ToString();
            node.Attributes["Content"].Value = movie.Content.ToString();
            node.Attributes["Duration"].Value = movie.Duration.ToString();
            node.Attributes["Url"].Value = movie.Url.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Create(Movie movie)
        {
            DataProvider.Instance.pathData = "data/Movies/Movies.xml";
            var newNode = DataProvider.Instance.createNode("Movie");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = movie.Id.ToString();
            var attr2 = DataProvider.Instance.createAttr("Name");
            attr2.Value = movie.Name;
            var attr3 = DataProvider.Instance.createAttr("Type");
            attr3.Value = movie.Type;
            var attr4 = DataProvider.Instance.createAttr("Content");
            attr4.Value = movie.Content.ToString();
            var attr5 = DataProvider.Instance.createAttr("Duration");
            attr5.Value = movie.Duration.ToString();
            var attr6 = DataProvider.Instance.createAttr("Url");
            attr6.Value = movie.Url.ToString();
            var attr7 = DataProvider.Instance.createAttr("Status");
            attr7.Value = movie.Status.ToString();
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.Attributes.Append(attr3);
            newNode.Attributes.Append(attr4);
            newNode.Attributes.Append(attr5);
            newNode.Attributes.Append(attr6);
            newNode.Attributes.Append(attr7);
            newNode.InnerText = string.Empty;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
        #endregion
    }
}
