using MySql.Data.MySqlClient;
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
using xiketang.com.Models;

namespace xiketang.com.MotionProject
{
    public partial class FrmReport : DockContent
    {
        public FrmReport()
        {
            InitializeComponent();
            this.Load += FrmReport_Load;
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            InitialDGV();

            this.rdo_Year.Checked = true;

            for (int i = 2019; i < 2029; i++)
            {
                this.cmb_Year.Items.Add(i.ToString());
            }
            this.cmb_Year.Text = DateTime.Now.Year.ToString();

            for (int i = 1; i < 13; i++)
            {
                this.cmb_Month.Items.Add(i.ToString());
            }
            this.cmb_Month.Text = DateTime.Now.Month.ToString();

            this.rdo_Month_CheckedChanged(null, null);
        }

        /// <summary>
        /// 当前选择的年份
        /// </summary>
        private int CurrentYear
        {
            get { return Convert.ToInt32(this.cmb_Year.Text); }
        }

        //当前选择的月份
        private int CurrentMonth
        {
            get { return Convert.ToInt32(this.cmb_Month.Text); }
        }


        #region 初始化DGV样式
        private void InitialDGV()
        {

            this.dgv_Year.Rows.Add();
            this.dgv_Year.Rows[0].Cells[0].Value = "月产量";

            this.dgv_Year.Rows.Add();
            this.dgv_Year.Rows[1].Cells[0].Value = "合格数";


            this.dgv_Year.Rows.Add();
            this.dgv_Year.Rows[2].Cells[0].Value = "不合格数";


            this.dgv_Year.Rows.Add();
            this.dgv_Year.Rows[3].Cells[0].Value = "合格率";


            this.dgv_Month.Rows.Add();
            this.dgv_Month.Rows[0].Cells[0].Value = "日产量";

            this.dgv_Month.Rows.Add();
            this.dgv_Month.Rows[1].Cells[0].Value = "合格数";


            this.dgv_Month.Rows.Add();
            this.dgv_Month.Rows[2].Cells[0].Value = "不合格数";


            this.dgv_Month.Rows.Add();
            this.dgv_Month.Rows[3].Cells[0].Value = "合格率";


            this.dgv_Quarter.Rows.Add();
            this.dgv_Quarter.Rows[0].Cells[0].Value = "季度产量";

            this.dgv_Quarter.Rows.Add();
            this.dgv_Quarter.Rows[1].Cells[0].Value = "合格数";


            this.dgv_Quarter.Rows.Add();
            this.dgv_Quarter.Rows[2].Cells[0].Value = "不合格数";


            this.dgv_Quarter.Rows.Add();
            this.dgv_Quarter.Rows[3].Cells[0].Value = "合格率";
        }
        #endregion

        #region 相关事件

        private void FrmReport_Resize(object sender, EventArgs e)
        {
            this.MainPanel.Location = new Point((this.Width - this.MainPanel.Width) / 2, this.MainPanel.Location.Y);
        }

        private void rdo_Month_CheckedChanged(object sender, EventArgs e)
        {
            this.cmb_Month.Enabled = this.rdo_Month.Checked;
        }

        #endregion

        #region 报表查询

        private void btn_Query_Click(object sender, EventArgs e)
        {
            List<Result> result = new List<Result>();

            string sql = string.Empty;

            int YearAdd = CurrentYear - DateTime.Now.Year;

            int MonthAdd = CurrentMonth - DateTime.Now.Month;

            #region 年度报表查询
            if (rdo_Year.Checked)
            {
                for (int i = 1; i < 13; i++)
                {
                    sql = "Select OKNumber,NGNumber from Report where ReportDateTime between '{0}' and '{1}'";

                    string startformat = "yyyy/" + i.ToString("00") + "/01 00:00:00";

                    string endformat = string.Empty;

                    if (i == 12)
                    {
                        endformat = "yyyy/" + i.ToString("00") + "/31 23:59:59";
                    }
                    else
                    {
                        endformat = "yyyy/" + (i + 1).ToString("00") + "/01 00:00:00";
                    }

                    sql = string.Format(sql, DateTime.Now.AddYears(YearAdd).ToString(startformat), DateTime.Now.AddYears(YearAdd).ToString(endformat));

                    MySqlDataReader dr = MySQLHelper.GetReader(sql);

                    if (dr.HasRows)
                    {
                        int OKNumber = 0;

                        int NGNumber = 0;

                        while (dr.Read())
                        {
                            OKNumber += Convert.ToInt32(dr["OKNumber"]);

                            NGNumber += Convert.ToInt32(dr["NGNumber"]);
                        }

                        result.Add(new Result()
                        {
                            OKNumber = OKNumber,
                            NGNumber = OKNumber
                        });
                    }
                    else
                    {
                        result.Add(new Result()
                        {
                            OKNumber = 0,
                            NGNumber = 0
                        });
                    }

                }
                SetYearDGV(result);
            }

            #endregion

            #region 月度报表查询

            else if (rdo_Month.Checked)
            {
                int monthday = GetCurrentMonthDays();

                for (int i = 1; i <= monthday; i++)
                {
                    sql = "Select OKNumber,NGNumber from Report where ReportDateTime='{0}'";

                    string format = "yyyy/MM/" + i.ToString("00") + " 00:00:00";

                    sql = string.Format(sql, DateTime.Now.AddYears(YearAdd).AddMonths(MonthAdd).ToString(format));

                    MySqlDataReader dr = MySQLHelper.GetReader(sql);

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            result.Add(new Result()
                            {
                                OKNumber = Convert.ToInt32(dr["OKNumber"]),
                                NGNumber = Convert.ToInt32(dr["NGNumber"])
                            });
                        }
                    }
                    else
                    {
                        result.Add(new Result()
                        {
                            OKNumber = 0,
                            NGNumber = 0
                        });
                    }
                }

                SetMonthDGV(result);
            }

            #endregion

            #region 季度报表查询
            else
            {
                for (int i = 1; i < 5; i++)
                {
                    sql = "Select OKNumber,NGNumber from Report where ReportDateTime between '{0}' and '{1}'";

                    //1  4   7   10
                    string startFormat = "yyyy/" + ((i - 1) * 3 + 1).ToString("00") + "/01 00:00:00";

                    string endformat = string.Empty;
                    //4   7  10  12/31
                    if (i == 4)
                    {
                        endformat = "yyyy/12/31 23:59:59";
                    }
                    else
                    {
                        endformat = "yyyy/" + (3*i + 1).ToString("00") + "/01 00:00:00";
                    }

                    sql = string.Format(sql, DateTime.Now.AddYears(YearAdd).ToString(startFormat), DateTime.Now.AddYears(YearAdd).ToString(endformat));

                    MySqlDataReader dr = MySQLHelper.GetReader(sql);


                    if (dr.HasRows)
                    {
                        int OKNumber = 0;

                        int NGNumber = 0;

                        while (dr.Read())
                        {
                            OKNumber += Convert.ToInt32(dr["OKNumber"]);

                            NGNumber += Convert.ToInt32(dr["NGNumber"]);
                        }

                        result.Add(new Result()
                        {
                            OKNumber = OKNumber,
                            NGNumber = OKNumber
                        });
                    }
                    else
                    {
                        result.Add(new Result()
                        {
                            OKNumber = 0,
                            NGNumber = 0
                        });
                    }


                }

                SetQuarterDGV(result);
            }

            #endregion
        }

        #endregion

        #region 获取月份的天数
        /// <summary>
        /// 获取月份的天数
        /// </summary>
        /// <returns></returns>
        private int GetCurrentMonthDays()
        {
            List<int> dayList = new List<int>();

            if (CurrentYear % 4 == 0)
            {
                dayList = new List<int>() { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            }
            else
            {
                dayList = new List<int>() { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            }

            return dayList[CurrentMonth - 1];
        }
        #endregion

        #region 报表设置

        private void SetYearDGV(List<Result> lstValue)
        {
            if (lstValue.Count == 12)
            {
                int yearOKNumber = 0;
                int yearNGNumber = 0;

                for (int i = 0; i < 12; i++)
                {
                    int total = lstValue[i].OKNumber + lstValue[i].NGNumber;

                    this.dgv_Year.Rows[0].Cells[i + 1].Value = total;
                    this.dgv_Year.Rows[1].Cells[i + 1].Value = lstValue[i].OKNumber;
                    this.dgv_Year.Rows[2].Cells[i + 1].Value = lstValue[i].NGNumber;

                    if (total > 0)
                    {
                        this.dgv_Year.Rows[3].Cells[i + 1].Value = (lstValue[i].OKNumber * 100.0f / total).ToString("f2") + "%";
                    }
                    else
                    {
                        this.dgv_Year.Rows[3].Cells[i + 1].Value = "0.0%";
                    }
                    yearOKNumber += lstValue[i].OKNumber;
                    yearNGNumber += lstValue[i].NGNumber;
                }
                //计算全年产量
                this.dgv_Year.Rows[0].Cells[13].Value = yearOKNumber + yearNGNumber;
                this.dgv_Year.Rows[1].Cells[13].Value = yearOKNumber;
                this.dgv_Year.Rows[2].Cells[13].Value = yearNGNumber;

                if (yearOKNumber + yearNGNumber > 0)
                {
                    this.dgv_Year.Rows[3].Cells[13].Value = (yearOKNumber * 100.0f / (yearOKNumber + yearNGNumber)).ToString("f2") + "%";
                }
                else
                {
                    this.dgv_Year.Rows[3].Cells[13].Value = "0.0%";
                }
            }
            else
            {
                MessageBox.Show("查询数据数量不满足，请检查！", "报表查询");
            }
        }

        private void SetMonthDGV(List<Result> lstValue)
        {
            if (lstValue.Count == GetCurrentMonthDays())
            {
                int monthOKNumber = 0;
                int monthNGNumber = 0;

                for (int i = 0; i < GetCurrentMonthDays(); i++)
                {
                    int total = lstValue[i].OKNumber + lstValue[i].NGNumber;

                    this.dgv_Month.Rows[0].Cells[i + 1].Value = total;
                    this.dgv_Month.Rows[1].Cells[i + 1].Value = lstValue[i].OKNumber;
                    this.dgv_Month.Rows[2].Cells[i + 1].Value = lstValue[i].NGNumber;

                    if (total > 0)
                    {
                        this.dgv_Month.Rows[3].Cells[i + 1].Value = (lstValue[i].OKNumber * 100.0f / total).ToString("f2") + "%";
                    }
                    else
                    {
                        this.dgv_Month.Rows[3].Cells[i + 1].Value = "0.0%";
                    }
                    monthOKNumber += lstValue[i].OKNumber;
                    monthNGNumber += lstValue[i].NGNumber;
                }
                //计算全月产量
                this.dgv_Month.Rows[0].Cells[32].Value = monthOKNumber + monthNGNumber;
                this.dgv_Month.Rows[1].Cells[32].Value = monthOKNumber;
                this.dgv_Month.Rows[2].Cells[32].Value = monthNGNumber;

                if (monthOKNumber + monthNGNumber > 0)
                {
                    this.dgv_Month.Rows[3].Cells[32].Value = (monthOKNumber * 100.0f / (monthOKNumber + monthNGNumber)).ToString("f2") + "%";
                }
                else
                {
                    this.dgv_Month.Rows[3].Cells[32].Value = "0.0%";
                }
            }
            else
            {
                MessageBox.Show("查询数据数量不满足，请检查！", "报表查询");
            }
        }

        private void SetQuarterDGV(List<Result> lstValue)
        {
            if (lstValue.Count == 4)
            {
                int quarterOKNumber = 0;
                int quarterNGNumber = 0;

                for (int i = 0; i < 4; i++)
                {
                    int total = lstValue[i].OKNumber + lstValue[i].NGNumber;

                    this.dgv_Quarter.Rows[0].Cells[i + 1].Value = total;
                    this.dgv_Quarter.Rows[1].Cells[i + 1].Value = lstValue[i].OKNumber;
                    this.dgv_Quarter.Rows[2].Cells[i + 1].Value = lstValue[i].NGNumber;

                    if (total > 0)
                    {
                        this.dgv_Quarter.Rows[3].Cells[i + 1].Value = (lstValue[i].OKNumber * 100.0f / total).ToString("f2") + "%";
                    }
                    else
                    {
                        this.dgv_Quarter.Rows[3].Cells[i + 1].Value = "0.0%";
                    }
                    quarterOKNumber += lstValue[i].OKNumber;
                    quarterNGNumber += lstValue[i].NGNumber;
                }
                //计算全年产量
                this.dgv_Quarter.Rows[0].Cells[5].Value = quarterOKNumber + quarterNGNumber;
                this.dgv_Quarter.Rows[1].Cells[5].Value = quarterOKNumber;
                this.dgv_Quarter.Rows[2].Cells[5].Value = quarterNGNumber;

                if (quarterOKNumber + quarterNGNumber > 0)
                {
                    this.dgv_Quarter.Rows[3].Cells[5].Value = (quarterOKNumber * 100.0f / (quarterOKNumber + quarterNGNumber)).ToString("f2") + "%";
                }
                else
                {
                    this.dgv_Quarter.Rows[3].Cells[5].Value = "0.0%";
                }
            }
            else
            {
                MessageBox.Show("查询数据数量不满足，请检查！", "报表查询");
            }
        }

        #endregion

        #region 报表导出

        private void btn_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "XLS文件(*.xls)|*.xls|所有文件|*.*";

            sfd.FileName = "报表导出";

            sfd.DefaultExt = "xls";

            sfd.AddExtension = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (rdo_Year.Checked)
                {
                    if (NiceExcelSaveAndRead.SaveToExcelNew(sfd.FileName, this.dgv_Year))
                    {
                        MessageBox.Show("年度报表导出成功！", "报表导出");

                    }
                    else
                    {
                        MessageBox.Show("年度报表导出失败！", "报表导出");
                    }
                }
                else if (this.rdo_Month.Checked)
                {
                    if (NiceExcelSaveAndRead.SaveToExcelNew(sfd.FileName, this.dgv_Month))
                    {
                        MessageBox.Show("月度报表导出成功！", "报表导出");

                    }
                    else
                    {
                        MessageBox.Show("月度报表导出失败！", "报表导出");
                    }
                }
                else
                {
                    if (NiceExcelSaveAndRead.SaveToExcelNew(sfd.FileName, this.dgv_Month))
                    {
                        MessageBox.Show("季度报表导出成功！", "报表导出");

                    }
                    else
                    {
                        MessageBox.Show("季度报表导出失败！", "报表导出");
                    }
                }
            }
        }

        #endregion
    }
}
