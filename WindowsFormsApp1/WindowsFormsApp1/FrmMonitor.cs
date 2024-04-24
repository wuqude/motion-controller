using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region 字段或属性
        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); }

        }
        #region 更新日志通用方法

        private void AddLog(int index, string log)
        {
            if (this.lstInfo.InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    ListViewItem lst = new ListViewItem("   " + CurrentTime, index);
                    lst.SubItems.Add(log);
                    lstInfo.Items.Insert(index, lst);
                }));
            }
            else
            {
                ListViewItem lst = new ListViewItem("   " + CurrentTime, index);
                lst.SubItems.Add(log);
                lstInfo.Items.Insert(index, lst);
            }

        }
        #endregion

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
