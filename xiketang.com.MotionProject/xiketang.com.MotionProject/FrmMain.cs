using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            myTimer.Interval = 500;
            myTimer.Tick += MyTimer_Tick;
            myTimer.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            this.tsl_CurrentTime.Text = CurrentTime;

            //授权检测
            if (CommonMethods.IsLicence == false)
            {
                if (DateTime.Now.Subtract(Convert.ToDateTime(SysStartTime)).TotalSeconds > 600)
                {
                    myTimer.Enabled = false;

                    MessageBox.Show("软件授权到期，即将关闭系统！", "授权提示");

                    IsExit = false;

                    this.Close();
                }                    
            }

            if (DateTime.Now.ToString("HH:mm:ss") == "23:59:55")
            {
                UpdateReport();
            }
        }

        private string SysStartTime = string.Empty;

        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); }
        }

      private   Timer myTimer = new Timer();

        private bool IsExit = true;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //初始化相关信息
            InitialParam();

            FrmNavi frmNavi = new FrmNavi();

            //第四步：绑定委托
            frmNavi.OpenForm = this.OpenFormMethod;

            frmNavi.Show(DockMain);

            //设置居左显示的宽度像素
            frmNavi.DockPanel.DockLeftPortion = 110;

            //设置自动隐藏时的比例  0.086=110/1280
            frmNavi.AutoHidePortion = 0.086;

            OpenFormMethod("集中监控");

        }


        #region 初始化参数
        private void InitialParam()
        {
            CommonMethods.SysSetPath = Application.StartupPath + "\\Settings\\SysSet.ini";

            //写入日志
            MySQLHelper.Log("登录系统", 0, CommonMethods.objAdmin.LoginName);

            //系统开始时间
            SysStartTime = CurrentTime;

            //授权显示
            this.tsl_LicenceState.Text = CommonMethods.IsLicence ? "【已授权】" : "【未授权】";

        }

        #endregion

        #region 创建委托实现的方法

        //第三步：创建委托实现的方法

        private void OpenFormMethod(string formName)
        {
            //避免重复打开

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
                    new FrmMonitor().Show(DockMain);
                    break;
                case "系统设置":
                    tsm_SysSet_Click(null, null);
                    break;
                case "系统日志":
                    tsm_SysLog_Click(null, null);
                    break;
                case "数据统计":
                    tsm_Record_Click(null, null);
                    break;
                case "数据记录":
                    tsm_Trend_Click(null, null);
                    break;
                case "用户管理":
                    tsm_UserManage_Click(null, null);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region 判断当前窗体名称是否已经打开

        private DockContent FindDockContent(string frmName)
        {
            foreach (DockContent item in DockMain.Documents)
            {
                if (item.Text == frmName)
                {
                    return item;
                }
            }
            return null;
        }



        #endregion

        #region 窗体关闭前提示

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsExit)
            {
                DialogResult dr = MessageBox.Show("是否确定要退出系统？", "退出询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dr == DialogResult.OK)
                {
                    //关闭之前处理

                    UpdateReport();

                    MySQLHelper.Log("退出系统", 0, CommonMethods.objAdmin.LoginName);

                    for (ushort i = 1; i <= 4; i++)
                    {
                        Dmc2410.d2410_write_outbit(0, i, 1);
                    }
                    Dmc2410.d2410_board_close();

                    System.Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region 系统菜单栏操作

        private void tsm_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsm_SysSet_Click(object sender, EventArgs e)
        {
            if (CommonMethods.objAdmin.SysSet)
            {
                new FrmSysSet().Show(DockMain);
            }
            else
            {
                MessageBox.Show("当前用户操作权限不足，请切换用户！", "参数设置");
            }
        }

        private void tsm_Trend_Click(object sender, EventArgs e)
        {
            if (CommonMethods.objAdmin.Trend)
            {
                new FrmTrend().Show(DockMain);
            }
            else
            {
                MessageBox.Show("当前用户操作权限不足，请切换用户！", "数据记录");
            }
        }

        private void tsm_Record_Click(object sender, EventArgs e)
        {
            if (CommonMethods.objAdmin.Report)
            {
                new FrmReport().Show(DockMain);
            }
            else
            {
                MessageBox.Show("当前用户操作权限不足，请切换用户！", "数据统计");
            }
        }

        private void tsm_SysLog_Click(object sender, EventArgs e)
        {
            if (CommonMethods.objAdmin.SysLog)
            {
                new FrmSysLog().Show(DockMain);
            }
            else
            {
                MessageBox.Show("当前用户操作权限不足，请切换用户！", "系统日志");
            }
        }

        private void tsm_UserManage_Click(object sender, EventArgs e)
        {
            if (CommonMethods.objAdmin.UserManage)
            {
                new FrmUserManage().ShowDialog();
            }
            else
            {
                MessageBox.Show("当前用户操作权限不足，请切换用户！", "用户管理");
            }
        }

        #endregion

        #region 统计产量

        //【1】每天晚上0点之前（23:59:50），把当天的产量统计存入数据库
        //【2】软件每次关闭之前，统计产量存入数据库


        //判断系统开启时间与关闭时间是否为同一天
        
        //如果是同一天，查询开始时间即为软件开启时间，
        
        //如果不是同一天，查询开始时间为当天的0点


         //每次更新产量，都要判断Report表里是否有当天的数据，如果有，做追加（Update），如果没有，创建（Insert）

        private void UpdateReport()
        {
            string sql = string.Empty;

            //说明开启时间与关闭时间是同一天
            if (Convert.ToDateTime(CurrentTime).ToString("yyyy/MM/dd") == Convert.ToDateTime(SysStartTime).ToString("yyyy/MM/dd"))
            {
                sql = "Select Count(*) from Report where ReportDateTime='{0}'";
                sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"));
                int Count = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));
                // 判断Report表里是否有当天的数据,Insert
                if (Count == 0)
                {
                    //查询合格
                    sql = "Select Count(*) from Product where ProductDateTime between '{0}' and '{1}' and Result=1";

                    sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"), CurrentTime);

                    int OKNum = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));


                    // 查询不合格
                    sql = "Select Count(*) from Product where ProductDateTime between '{0}' and '{1}' and Result=0";

                    sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"), CurrentTime);

                    int NGNum = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));

                    //插入数据
                    sql = "Insert into Report(ReportDateTime,OKNumber,NGNumber,TotalNumber) values('{0}',{1},{2},{3})";

                    sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"), OKNum, NGNum, OKNum + NGNum);

                    MySQLHelper.Update(sql);

                }
                // 判断Report表里是否有当天的数据,Update
                else
                {
                    //查询当天已经有多少
                    sql = "Select OKNumber,NGNumber from Report where ReportDateTime='{0}'";

                    sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"));

                    MySqlDataReader dr = MySQLHelper.GetReader(sql);

                    List<Result> res = new List<Result>();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            res.Add(new Result()
                            {
                                OKNumber=Convert.ToInt32( dr["OKNumber"]),
                                NGNumber = Convert.ToInt32(dr["NGNumber"])
                            });
                        }
                    }
                    if (res.Count >= 1)
                    {
                        int OKOrgin = res[0].OKNumber;
                        int NGOrgin = res[0].NGNumber;

                        //查询合格
                        sql = "Select Count(*) from Product where ProductDateTime between '{0}' and '{1}' and Result=1";

                        sql = string.Format(sql, SysStartTime, CurrentTime);

                        int OKNum = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));


                        // 查询不合格
                        sql = "Select Count(*) from Product where ProductDateTime between '{0}' and '{1}' and Result=0";

                        sql = string.Format(sql, SysStartTime, CurrentTime);

                        int NGNum = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));

                        //更新
                        sql = "Update Report set OKNumber={0},NGNumber={1},TotalNumber={2} where ReportDateTime='{3}'";

                        sql = string.Format(sql, OKNum + OKOrgin, NGNum + NGOrgin, OKNum + OKOrgin+NGNum + NGOrgin, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"));

                        MySQLHelper.Update(sql);

                    }
                }
            }
            //说明开启时间与关闭时间不是同一天
            else
            {
                //查询合格
                sql = "Select Count(*) from Product where ProductDateTime between '{0}' and '{1}' and Result=1";

                sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"), CurrentTime);

                int OKNum = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));


                // 查询不合格
                sql = "Select Count(*) from Product where ProductDateTime between '{0}' and '{1}' and Result=0";

                sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"), CurrentTime);

                int NGNum = Convert.ToInt32(MySQLHelper.GetSingleResult(sql));

                //插入数据
                sql = "Insert into Report(ReportDateTime,OKNumber,NGNumber,TotalNumber) values('{0}',{1},{2},{3})";

                sql = string.Format(sql, DateTime.Now.ToString("yyyy/MM/dd 00:00:00"), OKNum, NGNum, OKNum + NGNum);

                MySQLHelper.Update(sql);
            }
        
        }


        #endregion

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {

        }

        private void DockMain_ActiveContentChanged(object sender, EventArgs e)
        {

        }
    }
}
