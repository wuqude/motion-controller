using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xiketang.com.Models;
using xiketang.com.DAL;

namespace xiketang.com.MotionProject
{
    public static class CommonMethods
    {
        //用户登录对象
        public static SysAdmins objAdmin { get; set; } = new SysAdmins();

        //系统配置文件路径
        public static string SysSetPath = string.Empty;

        //软件授权状态（True表示已经授权，False表示尚未授权）
        public static bool IsLicence = false;

        //时间滴答次数
        public static int tickcount = 0;

        //读取系统配置文件
        public static ConfigInfoExt LoadSettings()
        {
            ConfigInfoExt objConfig = new ConfigInfoExt();

            try
            {
                //自动运动参数

                objConfig.VelMin= Convert.ToDouble(IniConfigHelper.ReadIniData("自动运动参数", "初始速度", "", CommonMethods.SysSetPath));

                objConfig.VelMax = Convert.ToDouble(IniConfigHelper.ReadIniData("自动运动参数", "运行速度", "", CommonMethods.SysSetPath));

                objConfig.Tac = Convert.ToDouble(IniConfigHelper.ReadIniData("自动运动参数", "加速时间", "", CommonMethods.SysSetPath));

                objConfig.STac = Convert.ToDouble(IniConfigHelper.ReadIniData("自动运动参数", "S段时间", "", CommonMethods.SysSetPath));

                objConfig.XAxisPosition = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运动参数", "X轴原限", "", CommonMethods.SysSetPath));

                objConfig.YAxisPosition = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运动参数", "Y轴原限", "", CommonMethods.SysSetPath));

                objConfig.ZAxisPosition = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运动参数", "Y轴原限", "", CommonMethods.SysSetPath));

                //系统锁屏设置

                objConfig.AutoLock = IniConfigHelper.ReadIniData("系统锁屏设置", "是否自动锁屏", "", SysSetPath) == "1";

                objConfig.LockPeriod = Convert.ToInt32(IniConfigHelper.ReadIniData("系统锁屏设置", "自动锁屏间隔", "", SysSetPath));

                //自动运行轨迹

                objConfig.ReclaimerXAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "取料口运动X轴", "", SysSetPath));

                objConfig.ReclaimerYAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "取料口运动Y轴", "", SysSetPath));

                objConfig.ProcessXAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "加工处运动X轴", "", SysSetPath));

                objConfig.ProcessYAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "加工处运动Y轴", "", SysSetPath));

                objConfig.OutletXAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "出料口运动X轴", "", SysSetPath));

                objConfig.OutletYAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "出料口运动Y轴", "", SysSetPath));

                objConfig.DownZAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "下降Z轴", "", SysSetPath));

                objConfig.LiftZAxis = Convert.ToInt32(IniConfigHelper.ReadIniData("自动运行轨迹", "上升Z轴", "", SysSetPath));

                return objConfig;

            }
            catch (Exception)
            {
                //写入
                return null;
            }
        }


    }
}
