using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
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
            Application.Run(new Frmlogin());

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
                Frmlogin objFrm = new Frmlogin();
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
