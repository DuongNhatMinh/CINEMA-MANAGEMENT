using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Minh_WPF_C2_B1
{
    class ChairViewModel
    {
        #region Properties
        private static UnitOfWork unitofwork { get; set; }
        public RepositoryBase<Chair> chairRepo { get; set; }
        public List<Chair> lstChair { get; set; }
        #endregion

        #region Methods
        public void getList()
        {
            unitofwork = new UnitOfWork();
            chairRepo = unitofwork.GetRepositoryChair;
            lstChair = getList("//Chair");
        }

        public void getList(string IdMovie, int Day, int Hour, int Minute)
        {
            string pathData = string.Format("data/Movies/{0}/{1}/{2}-{3}.xml", IdMovie, Day, Hour, Minute);
            unitofwork = new UnitOfWork(pathData);
            chairRepo = unitofwork.GetRepositoryChair;
            lstChair = getList("//Chair", pathData);
        }

        public List<Chair> getList(string xPath)
        {
            lstChair = new List<Chair>();
            DataProvider.Instance.pathData = "data/Cinemas.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            Chair chair = null;
            string Id = string.Empty;
            string Name = string.Empty;
            char Type;
            int Status = 0;
            foreach (XmlNode node in lstNode)
            {
                Id = node.Attributes["Id"].Value;
                Name = node.Attributes["Name"].Value;
                Type = Char.Parse(node.Attributes["Type"].Value);
                Status = Int32.Parse(node.Attributes["Status"].Value);
                chair = new Chair(Id, Name, Type, Status);
                lstChair.Add(chair);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstChair;
        }

        public List<Chair> getList(string xPath, string pathData)
        {
            lstChair = new List<Chair>();
            DataProvider.Instance.pathData = pathData;
            DataProvider.Instance.Open(); // Mở tài liệu Xml           
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            Chair chair = null;
            string Id = string.Empty;
            string Name = string.Empty;
            char Type;
            int Status = 0;
            foreach (XmlNode node in lstNode)
            {
                Id = node.Attributes["Id"].Value;
                Name = node.Attributes["Name"].Value;
                Type = Char.Parse(node.Attributes["Type"].Value);
                Status = Int32.Parse(node.Attributes["Status"].Value);
                chair = new Chair(Id, Name, Type, Status);
                lstChair.Add(chair);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstChair;
        }

        public bool CreateChair(string Id, string Name, char type, int status)
        {
            Chair chair = null;
            try
            {
                if (!isExist(Id))
                {
                    chair = new Chair
                    {
                        ID = Id,
                        Name = Name,
                        Type = type,
                        Status = status
                    };
                    chairRepo.Add(chair);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public Chair SearchByName(string name)
        {
            foreach (var item in chairRepo.Gets())
                if (item.Name == name)
                    return item;
            return null;
        }

        public bool isExist(string name)
        {
            if (SearchByName(name) == null)
                return false;
            return true;
        }

        public void Update(string xPath, string pathData)
        {
            DataProvider.Instance.pathData = pathData;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            var node = DataProvider.Instance.getNode(xPath);
            node.Attributes["Status"].Value = 1.ToString();
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
        #endregion
    }
}
