using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.model
{
    public class SysAdmins
    {
        public string LoginName { get; set; }

        public string LoginPwd { get; set; }

        public bool HandCtrl { get; set; }

        public bool AutoCtrl { get; set; }

        public bool SysSet { get; set; }

        public bool SysLog { get; set; }

        public bool Report { get; set; }

        public bool Trend { get; set; }

        public bool UserManage { get; set; }

    }
}
