using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_WPF_C2_B1
{
    class ScheduleViewModel
    {
        #region Properties
        private static UnitOfWork unitofwork { get; set; }
        public RepositoryBase<Schedule> scheduleRepo { get; set; }
        public List<Schedule> lstSchedule = new List<Schedule>();
        public List<Showtime> lstShowtime = new List<Showtime>();
        #endregion

        public void getList()
        {
            unitofwork = new UnitOfWork();
            scheduleRepo = unitofwork.GetRepositorySchedule;
            lstSchedule = getList("Schedule");
        }

        public List<Schedule> getList(string xPath)
        {
            DataProvider.Instance.pathData = "data/Movies/Schedule2.xml";
            //lstMovie = new List<Movie>();
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            Schedule schedule = null;
            Showtime showtime = null;
            DateTime date = DateTime.Now;
            string Id = string.Empty;
            int hour = 0, minute;
            DataProvider.Instance.Open();
            foreach (XmlNode node2 in lstNode)
            {
                int status = 0;
                Id = node2.Attributes["Id"].Value;
                date = DateTime.Parse(node2.Attributes["Date"].Value);
                status = Int32.Parse(node2.Attributes["Status"].Value);
                lstShowtime = new List<Showtime>();
                XmlNodeList ListNode3 = DataProvider.Instance.getDsNode("//Showtime");
                foreach (XmlNode item in ListNode3)
                {
                    hour = Int32.Parse(item.Attributes["Hour"].Value);
                    minute = Int32.Parse(item.Attributes["Minute"].Value);
                    showtime = new Showtime(hour, minute);
                    lstShowtime.Add(showtime);
                }
                schedule = new Schedule(Id, date, status, lstShowtime);
                lstSchedule.Add(schedule);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstSchedule;
        }

        public void Update(string xPath)
        {
            DataProvider.Instance.pathData = "data/Movies/Schedule2.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Status"].Value = 1.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Update(string xPath, Schedule schedule)
        {
            DataProvider.Instance.pathData = "data/Movies/Schedule2.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Date"].Value = schedule.Date.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Update(string xPath2, Showtime schedule)
        {
            DataProvider.Instance.pathData = "data/Movies/Schedule2.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node2 = DataProvider.Instance.getNode(xPath2);

            node2.Attributes["Hour"].Value = schedule.Hour.ToString();
            node2.Attributes["Minute"].Value = schedule.Minute.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }

        public void Create(Schedule schedule)
        {
            string[] date;
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            date = schedule.Date.GetDateTimeFormats('d', culture);
            DataProvider.Instance.pathData = "data/Movies/schedule2.xml";
            var newNode = DataProvider.Instance.createNode("Schedule");
            var attr1 = DataProvider.Instance.createAttr("Id");
            attr1.Value = schedule.Id.ToString();
            var attr2 = DataProvider.Instance.createAttr("Date");
            attr2.Value = date[0];
            var attr3 = DataProvider.Instance.createAttr("Status");
            attr3.Value = schedule.Status.ToString();
            newNode.Attributes.Append(attr1);
            newNode.Attributes.Append(attr2);
            newNode.Attributes.Append(attr3);
            newNode.InnerText = string.Empty;   
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            for (int i = 0; i < schedule.lstShowtime.Count; i++)
            {
                var newNode2 = DataProvider.Instance.createNode("Showtime");
                var attr4 = DataProvider.Instance.createAttr("Hour");
                attr4.Value = schedule.lstShowtime[i].Hour.ToString();
                var attr5 = DataProvider.Instance.createAttr("Minute");
                attr5.Value = schedule.lstShowtime[i].Minute.ToString();
                newNode2.Attributes.Append(attr4);
                newNode2.Attributes.Append(attr5);
                newNode2.InnerText = string.Empty;
                DataProvider.Instance.Open(); // Mở tài liệu Xml
                string xpath = string.Format("Schedule[@Id='{0}']", schedule.Id);
                var node = DataProvider.Instance.getNode(xpath);
                DataProvider.Instance.AppendNode(node, newNode2);
                DataProvider.Instance.Close(); // Đóng tài liệu Xml
            }
        }
    }
}
