using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minh_WPF_C2_B1
{
    class AccountInfor
    {
        public string UserName;

        public AccountInfor()
        {
            this.UserName = string.Empty;
        }

        public AccountInfor(string username)
        {
            this.UserName = username;
        }
    }
}
