using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class Chair
    {
        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public char Type { get; set; }
        public int Status { get; set; }
        #endregion

        #region Contructor
        public Chair()
        {
            ID = "Underfined";
            Name = "Underfined";
            Type = '?';
            Status = 0;
        }

        public Chair(string id, string name, char type, int status)
        {
            this.ID = id;
            this.Name = name;
            this.Type = type;
            this.Status = status;
        }
        #endregion
    }
}
