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
using xiketang.com.DAL;

namespace xiketang.com.MotionProject
{
    public partial class FrmSysLog : DockContent
    {
        public FrmSysLog()
        {
            InitializeComponent();
            this.Load += FrmSysLog_Load;

        }

        private void FrmSysLog_Load(object sender, EventArgs e)
        {
            this.cmb_AlarmType.DataSource = new string[] { "日志信息", "报警信息", "全部信息" };
            this.cmb_AlarmType.SelectedIndex = 2;

            this.dgv_Log.AutoGenerateColumns = false;
        }

        private void FrmReport_Resize(object sender, EventArgs e)
        {
            this.MainPanel.Location = new Point((this.Width - this.MainPanel.Width) / 2, this.MainPanel.Location.Y);
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            QueryProcess(this.dtp_Date.Text + " " + this.dtp_Start.Text, this.dtp_Date.Text + " " + this.dtp_End.Text, this.cmb_AlarmType.SelectedIndex);
        }
        /// <summary>
        /// 信息查询
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="type"></param>
        private void QueryProcess(string start, string end, int type)
        {
            //对开始时间和结束时间做判断

            DateTime t_start = Convert.ToDateTime(start);

            DateTime t_end = Convert.ToDateTime(end);

            if (t_start >= t_end)
            {
                MessageBox.Show("开始时间必须小于结束时间", "查询提示");
                return;
            }

            //SQL语句拼接

            StringBuilder sb = new StringBuilder();

            sb.Append("select * from SysLog where LogTime between '{0}' and '{1}'");

            string sql = string.Format(sb.ToString(), start, end);

            if (type <= 1)
            {

                sql += " and LogType=" + type;
            }

            DataSet ds = MySQLHelper.GetDataSet(sql);

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        row["LogType"] = row["LogType"].ToString() == "1" ? "报警信息" : "日志信息";
                    }

                    this.dgv_Log.DataSource = null;                
                    this.dgv_Log.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("未查询到数据，请检查！", "查询提示");
                }
            }
            else
            {
                MessageBox.Show("查询有误，请检查！", "查询提示");
            }
        }

        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Log_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DgvRowPostPaint(this.dgv_Log, e);
        }

        private void DgvRowPostPaint(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                //添加行号 
                SolidBrush v_SolidBrush = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
                int v_LineNo = 0;
                v_LineNo = e.RowIndex + 1;
                string v_Line = v_LineNo.ToString();
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                e.Graphics.DrawString(v_Line, e.InheritedRowStyle.Font, v_SolidBrush, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加行号时发生错误，错误信息：" + ex.Message, "操作失败");
            }
        }

        /// <summary>
        /// 打印功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Print_Click(object sender, EventArgs e)
        {
            PrintDGV.Print_DataGridView(this.dgv_Log);
        }

        /// <summary>
        /// 导出功能
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter="XLS文件(*.xls)|*.xls|所有文件|*.*";

            sfd.FileName = "日志导出";

            sfd.DefaultExt = "xls";

            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (NiceExcelSaveAndRead.SaveToExcelNew(sfd.FileName, this.dgv_Log))
                {
                    MessageBox.Show("报表导出成功！", "报表导出");

                }
                else
                {
                    MessageBox.Show("报表导出失败！", "报表导出");
                }
            }

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
