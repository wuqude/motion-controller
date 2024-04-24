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

    //第一步：声明委托

    public delegate void OpenFormDelegate(string frmName);


    public partial class FormNav : DockContent
    {
        public FormNav()
        {
            InitializeComponent();
        }

        //第二步：创建委托对象

        public OpenFormDelegate OpenForm;

        private void btn_SysSet_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void FormNav_Load(object sender, EventArgs e)
        {

        }

        private void button_Monitor_Click(object sender, EventArgs e)
        {
            //第五步：调用委托对象
            OpenForm(((Button)sender).Text);
        }

        private void button_SysSet_Click(object sender, EventArgs e)
        {
            OpenForm(((Button)sender).Text);

        }
    }
}
