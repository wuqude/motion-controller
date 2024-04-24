using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace xiketang.com.MotionProject
{

    //第一步：声明委托

    public delegate void OpenFormDelegate(string frmName);


    public partial class FrmNavi : DockContent
    {
        public FrmNavi()
        {
            InitializeComponent();
        }

        //第二步：创建委托对象

        public OpenFormDelegate OpenForm;

        private void btn_Monitor_Click(object sender, EventArgs e)
        {
            //第五步：调用委托对象
            OpenForm(((Button)sender).Text);
        }

        private void btn_SysSet_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_UserManage_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_Trend_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void btn_SysLog_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);
        }

        private void FrmNavi_Load(object sender, EventArgs e)
        {
            FrmNavi frmNavi= new FrmNavi();  
        }
    }
}
