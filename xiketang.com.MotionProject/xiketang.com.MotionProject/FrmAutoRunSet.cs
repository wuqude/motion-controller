using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xiketang.com.Models;

namespace xiketang.com.MotionProject
{
    public partial class FrmAutoRunSet : Form
    {
        public FrmAutoRunSet()
        {
            InitializeComponent();
        }

        //循环方式对象
        public AutoRunMode objRunMode = new AutoRunMode();

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            if (this.rdo_OneAndHome.Checked)
            {
                objRunMode.CircleMode = CircleMode.OneAndHome;
                objRunMode.CircleTimes = 1;
            }
            else if (this.rdo_OneAndStop.Checked)
            {
                objRunMode.CircleMode = CircleMode.OneAndStop;
                objRunMode.CircleTimes = 1;
            }
            else
            {
                objRunMode.CircleMode = CircleMode.CustomTime;
                objRunMode.CircleTimes = Convert.ToInt32(this.num_CircleTimer.Value);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
