using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xiketang.com.DAL;

namespace xiketang.com.MotionProject
{
    static class Program
    {

        public static Mutex mutex;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 授权配置

            //判断是否有授权

            object reg = Regedit.GetData("xiketang", "xiketang");

            if (reg == null)
            {
                MessageBox.Show("本软件尚未授权，提供10分钟试用时间！", "授权提示");
                CommonMethods.IsLicence = false;
            }
            else
            {
                string Code = reg.ToString();

                if (!Register.Check(Code))
                {
                    MessageBox.Show("本软件尚未授权，提供10分钟试用时间！", "授权提示");
                    CommonMethods.IsLicence = false;
                }
                else
                {
                    CommonMethods.IsLicence = true;
                }
            }

            #endregion


            //判断应用程序是否运行
            mutex = new Mutex(true, "OnlyRun");

            if (!mutex.WaitOne(0, false))
            {
                MessageBox.Show("喜科堂运动控制系统已经运行！", "系统运行", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Application.Exit();
                return;
            }
            else
            {
                FrmLogin objFrm = new FrmLogin();
                objFrm.TopMost = true;
                if (objFrm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FrmMain());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
