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
using ZedGraph;

namespace xiketang.com.MotionProject
{
    public partial class FrmTrend : DockContent
    {
        public FrmTrend()
        {
            InitializeComponent();

            this.Load += FrmTrend_Load;

        }

        /// <summary>
        /// 当前选择的年份
        /// </summary>
        private int CurrentYear
        {
            get { return Convert.ToInt32(this.cmb_Year.Text); }
        }

        //当前选择的季度
        private int CurrentQuarter
        {
            get { return Convert.ToInt32(this.cmb_Quarter.Text); }
        }

        //当前选择的月份
        private int CurrentMonth
        {
            get { return Convert.ToInt32(this.cmb_Month.Text); }
        }

        //ZedGraph数据源

        private PointPairList list1 = new PointPairList();

        private PointPairList list2 = new PointPairList();

        #region 窗体加载事件
        private void FrmTrend_Load(object sender, EventArgs e)
        {
            for (int i = 2019; i < 2029; i++)
            {
                this.cmb_Year.Items.Add(i.ToString());
            }
            this.cmb_Year.Text = DateTime.Now.Year.ToString();


            for (int i = 1; i < 5; i++)
            {
                this.cmb_Quarter.Items.Add(i.ToString());
            }

            //123  457  789  10 11 12

            switch (DateTime.Now.Month)
            {
                case 1:
                case 2:
                case 3:
                    this.cmb_Quarter.Text = "1";
                    break;
                case 4:
                case 5:
                case 6:
                    this.cmb_Quarter.Text = "2";
                    break;
                case 7:
                case 8:
                case 9:
                    this.cmb_Quarter.Text = "3";
                    break;
                case 10:
                case 11:
                case 12:
                    this.cmb_Quarter.Text = "4";
                    break;
                default:
                    break;
            }
            for (int i = 1; i < 13; i++)
            {
                this.cmb_Month.Items.Add(i.ToString());
            }
            this.cmb_Month.Text = DateTime.Now.Month.ToString();


            this.rdo_year.Checked = true;

            ZedGraphSet();
        }

        #endregion

        #region ZedGraph控件设置

        private void ZedGraphSet()
        {
            this.zedGraphControl1.GraphPane.IsFontsScaled = false;
            this.zedGraphControl1.GraphPane.Fill = new Fill(Color.FromArgb(240, 240, 240));

            // 设置标题及X轴Y轴名称即字体
            this.zedGraphControl1.GraphPane.Title.Text = "产量统计图";
            this.zedGraphControl1.GraphPane.Title.FontSpec.Size = 14;
            this.zedGraphControl1.GraphPane.Title.FontSpec.Family = "微软雅黑";
            this.zedGraphControl1.GraphPane.YAxis.Title.Text = "产量（件）";
            this.zedGraphControl1.GraphPane.YAxis.Title.FontSpec.Size = 14;
            this.zedGraphControl1.GraphPane.YAxis.Title.FontSpec.Family = "微软雅黑";

            this.zedGraphControl1.GraphPane.YAxis.Scale.MaxAuto = true;
            this.zedGraphControl1.GraphPane.XAxis.Title.Text = "时间日期";
            this.zedGraphControl1.GraphPane.XAxis.Title.FontSpec.Size = 14;
            this.zedGraphControl1.GraphPane.XAxis.Title.FontSpec.Family = "微软雅黑";

            //填充渐变色
            this.zedGraphControl1.GraphPane.Chart.Fill = new Fill(Color.FromArgb(240, 240, 240), Color.FromArgb(255, 255, 166), 45.0F);

            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();

            // Y轴范围自动变换
            this.zedGraphControl1.GraphPane.YAxis.Scale.Max += this.zedGraphControl1.GraphPane.YAxis.Scale.MajorStep;

            // 每个Bar图形创建标签
            BarItem.CreateBarLabels(this.zedGraphControl1.GraphPane, false, "f0");
        }

        #endregion

        #region 相关事件

        private void FrmReport_Resize(object sender, EventArgs e)
        {
            this.MainPanel.Location = new Point((this.Width - this.MainPanel.Width) / 2, this.MainPanel.Location.Y);
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            this.cmb_Quarter.Enabled = this.rdo_Quarter.Checked;

            this.cmb_Month.Enabled = this.rdo_Month.Checked;
        }

        #endregion

        private void btn_Query_Click(object sender, EventArgs e)
        {
            List<Result> result = new List<Result>();

            string sql = string.Empty;

            int YearAdd = CurrentYear - DateTime.Now.Year;

            int MonthAdd = CurrentMonth - DateTime.Now.Month;

            #region 年度报表查询

            if (rdo_year.Checked)
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
                int monthStart = (CurrentQuarter - 1) * 3 + 1;

                int monthEnd = (CurrentQuarter - 1) * 3 + 4;

                for (int i = monthStart; i < monthEnd; i++)
                {
                    sql = "Select OKNumber,NGNumber from Report where ReportDateTime between '{0}' and '{1}'";

             
                    string startFormat = "yyyy/" + i.ToString("00") + "/01 00:00:00";

                    string endformat = string.Empty;

                    if (i == 13)
                    {
                        endformat = "yyyy/12/31 23:59:59";
                    }
                    else
                    {
                        endformat = "yyyy/" + ( i + 1).ToString("00") + "/01 00:00:00";
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


        #region 曲线设置

        private void SetYearDGV(List<Result> lstValue)
        {
            if (lstValue.Count == 12)
            {
                //清空ZedGraph

                this.zedGraphControl1.GraphPane.CurveList.Clear();
                this.zedGraphControl1.GraphPane.GraphObjList.Clear();

                //设置标题
                this.zedGraphControl1.GraphPane.Title.Text = CurrentYear + "年度产量统计图";

                list1 = new PointPairList();
                list2 = new PointPairList();

                List<string> XAxisNameList = new List<string>();


                for (int i = 0; i < 12; i++)
                {
                    double xAxis = i;
                    double y1Axis = lstValue[i].OKNumber;
                    double y2Axis = lstValue[i].NGNumber;
                    list1.Add(xAxis, y1Axis);
                    list2.Add(xAxis, y2Axis);

                    XAxisNameList.Add((i + 1).ToString() + "月份");
                }

                //显示曲线

                //设置示例的字体
                this.zedGraphControl1.GraphPane.Legend.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.Legend.FontSpec.Size = 10;

               this.zedGraphControl1.GraphPane.AddBar("合格", list1, Color.Blue);
                this.zedGraphControl1.GraphPane.AddBar("不合格", list2, Color.Red);


                //设置X轴显示名称
                this.zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = XAxisNameList.ToArray();
                this.zedGraphControl1.GraphPane.XAxis.Type = AxisType.Text;

                this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Size = 10;
                this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Size = 10;

                this.zedGraphControl1.GraphPane.YAxis.Scale.MaxAuto = true;

                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();
            }
            else
            {
                MessageBox.Show("查询数据数量不满足，请检查！", "曲线查询");
            }
        }

        private void SetMonthDGV(List<Result> lstValue)
        {
            int dayCount = GetCurrentMonthDays();

            if (lstValue.Count == dayCount)
            {
                //清空ZedGraph

                this.zedGraphControl1.GraphPane.CurveList.Clear();
                this.zedGraphControl1.GraphPane.GraphObjList.Clear();

                //设置标题
                this.zedGraphControl1.GraphPane.Title.Text = CurrentYear + "年第" + CurrentMonth.ToString() + "月度产量统计图";

                list1 = new PointPairList();
                list2 = new PointPairList();

                List<string> XAxisNameList = new List<string>();

                for (int i = 0; i < dayCount; i++)
                {
                    double xAxis = i;
                    double y1Axis = lstValue[i].OKNumber;
                    double y2Axis = lstValue[i].NGNumber;
                    list1.Add(xAxis, y1Axis);
                    list2.Add(xAxis, y2Axis);

                    XAxisNameList.Add((i+1)+ "日");
                }

                //显示曲线

                //设置示例的字体
                this.zedGraphControl1.GraphPane.Legend.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.Legend.FontSpec.Size = 10;

                this.zedGraphControl1.GraphPane.AddBar("合格", list1, Color.Blue);
                this.zedGraphControl1.GraphPane.AddBar("不合格", list2, Color.Red);


                //设置X轴显示名称
                this.zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = XAxisNameList.ToArray();
                this.zedGraphControl1.GraphPane.XAxis.Type = AxisType.Text;

                this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Size = 10;
                this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Size = 10;

                this.zedGraphControl1.GraphPane.YAxis.Scale.MaxAuto = true;

                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();
            }
            else
            {
                MessageBox.Show("查询数据数量不满足，请检查！", "曲线查询");
            }
        }

        private void SetQuarterDGV(List<Result> lstValue)
        {
            if (lstValue.Count == 3)
            {
                //清空ZedGraph

                this.zedGraphControl1.GraphPane.CurveList.Clear();
                this.zedGraphControl1.GraphPane.GraphObjList.Clear();

                //设置标题
                this.zedGraphControl1.GraphPane.Title.Text = CurrentYear + "年第"+CurrentQuarter.ToString()+"季度产量统计图";

                list1 = new PointPairList();
                list2 = new PointPairList();

                List<string> XAxisNameList = new List<string>();

                for (int i = 0; i < 3; i++)
                {
                    double xAxis = i;
                    double y1Axis = lstValue[i].OKNumber;
                    double y2Axis = lstValue[i].NGNumber;
                    list1.Add(xAxis, y1Axis);
                    list2.Add(xAxis, y2Axis);

                    XAxisNameList.Add(((CurrentQuarter-1)*3+1+i)+ "月份");
                }

                //显示曲线

                //设置示例的字体
                this.zedGraphControl1.GraphPane.Legend.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.Legend.FontSpec.Size = 10;

                 this.zedGraphControl1.GraphPane.AddBar("合格", list1, Color.Blue);
                 this.zedGraphControl1.GraphPane.AddBar("不合格", list2, Color.Red);


                //设置X轴显示名称
                this.zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = XAxisNameList.ToArray();
                this.zedGraphControl1.GraphPane.XAxis.Type = AxisType.Text;

                this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.XAxis.Scale.FontSpec.Size = 10;
                this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Family = "微软雅黑";
                this.zedGraphControl1.GraphPane.YAxis.Scale.FontSpec.Size = 10;

                this.zedGraphControl1.GraphPane.YAxis.Scale.MaxAuto = true;

                this.zedGraphControl1.AxisChange();
                this.zedGraphControl1.Refresh();
            }
            else
            {
                MessageBox.Show("查询数据数量不满足，请检查！", "曲线查询");
            }
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

        private void btn_Export_Click(object sender, EventArgs e)
        {
            this.zedGraphControl1.SaveAsBitmap();
        }
    }
}
