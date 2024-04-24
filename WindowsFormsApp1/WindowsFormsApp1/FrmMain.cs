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

namespace WindowsFormsApp1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            this.Load += FrmMain_Load;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FormNav frmNavi = new FormNav();
            frmNavi.Show(DockerMain);

            //第四步：绑定委托
            frmNavi.OpenForm = this.OpenFormMethod;

            frmNavi.Show(DockerMain);

            //设置居左显示的宽度像素
            frmNavi.DockPanel.DockLeftPortion = 110;

            //设置自动隐藏时的比例  0.086=110/1280
            frmNavi.AutoHidePortion = 0.086;

            OpenFormMethod("集中监控");


        }

        private void OpenFormMethod(string formName)
        {

            DockContent frm = FindDockContent(formName);

            if (frm != null)
            {
                frm.BringToFront();
                frm.Activate();
                return;
            }

            switch (formName)
            {
                case "集中监控":
                    new FrmMonitor().Show(DockerMain);
                    break;
                case "系统设置":
                    new FrmMonitor().Show(DockerMain);
                    break;
            }

        }


        #region 判断当前窗体名称是否已经打开

        private DockContent FindDockContent(string frmName)
        {
            foreach (DockContent item in DockerMain.Documents)
            {
                if (item.Text == frmName)
                {
                    return item;
                }
            }
            return null;
        }
        #endregion



        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DockerMain_ActiveContentChanged(object sender, EventArgs e)
        {

        }
    }
}


