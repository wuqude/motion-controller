using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xiketang.com.model;

namespace WindowsFormsApp1
{
    public class CommonMethods
    {
        //用户登录对象
        public static SysAdmins objAdmin { get; set; } = new SysAdmins();

        //系统配置文件路径
        public static string SysSetPath = string.Empty;

        //软件授权状态（True表示已经授权，False表示尚未授权）
        public static bool IsLicence = false;

        //时间滴答次数
        public static int tickcount = 0;
    }
}
