using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using xiketang.com.DAL;
using xiketang.com.Models;
using Timer = System.Windows.Forms.Timer;

namespace xiketang.com.MotionProject
{
    public enum RunStep
    {
        //等待运行
        RunReady,

        //前往取料口
        MoveToReclaimer,

        //取料口判断料是否存在
        ReclaimerWait,

        //取料口Z轴下降
        ReclaimerDown,

        //取料口抓取物体
        ReclaimerGrap,

        //取料口Z轴上升
        ReclaimerUp,

        //前往加工位
        MoveToProcess,

        //加工位检测
        ProcessCheck,

        //加工位Z轴下降1
        ProcessDown1,

        //加工位放下物体
        ProcessPutDown,

        //加工位Z轴上升1
        ProcessUp1,

        //加工位等待
        ProcessWait,

        //加工位Z轴下降2
        ProcessDown2,

        //加工位抓取物体
        ProcessGrab,

        //加工位Z轴上升2
        ProcessUp2,

        //前往出料口
        MoveToOutlet,

        //出料口等待
        OutletWait,

        //出料口Z轴下降
        OutletDown,

        //加工位放下物体
        OutletPutDown,

        //加工位Z轴上升
        OutletUp,

        //总步骤
        MaxStep,
    }

    public partial class FrmMonitor : DockContent
    {
        public FrmMonitor()
        {
            InitializeComponent();

            UpdateTimer.Interval = 200;

            UpdateTimer.Tick += UpdateTimer_Tick;

            this.Load += FrmMonitor_Load;
        }

        #region 字段或属性

        //表示板卡是否存在
        private bool IsCardExit = false;

        //表示系统模式，True表示自动模式，False表示手动模式
        private bool AutoMode = false;

        //实时更新的定时器
        private Timer UpdateTimer = new Timer();

        //创建三个轴号
        private ushort XAxis = 0;

        private ushort YAxis = 1;

        private ushort ZAxis = 2;


        /// <summary>
        /// 当前系统时间
        /// </summary>
        private string CurrentTime
        {
            get { return DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); }

        }

        //配置信息的对象
        private ConfigInfoExt objConfig = new ConfigInfoExt();

        //循环方式对象
        private AutoRunMode objRunMode = new AutoRunMode();

        //当前步骤
        private RunStep CurrentStep { get; set; } = RunStep.RunReady;

        //自动过程停止
        private bool IsAutoStop = false;

        //暂停信号
        private bool IsPause = false;

        //当前系统运行状态（0：就绪  1：运行   2：故障）
        private int SysStatus = 0;

        //允许更新轨迹曲线
        private bool AddCurveEnable = false;

        //创建消息过滤对象
        private MessageFilter messageFilter;

        #endregion

        #region 窗体初始化
        private void FrmMonitor_Load(object sender, EventArgs e)
        {
            int cardnum = Dmc2410.d2410_board_init();
            if (cardnum < 1 || cardnum > 8)
            {
                AddLog(1, "板卡未检测到，请检查！");
                IsCardExit = false;
                return;
            }
            else
            {
                AddLog(0, "检测到板卡，板卡数量为：" + cardnum.ToString());
                IsCardExit = true;

                //开启实时更新定时器
                this.UpdateTimer.Start();

                //读取配置文件
                objConfig = CommonMethods.LoadSettings();

                if (objConfig == null)
                {
                    AddLog(2, "配置文件信息不正确");
                    return;
                }

                if (objConfig.AutoLock)
                {
                    messageFilter = new MessageFilter();
                    Application.AddMessageFilter(messageFilter);
                }

                this.pointCurve1.ReclaimerXAxis = Convert.ToInt32(objConfig.ReclaimerXAxis.ToString());
                this.pointCurve1.ReclaimerYAxis = Convert.ToInt32(objConfig.ReclaimerYAxis.ToString());
                this.pointCurve1.ProcessXAxis = Convert.ToInt32(objConfig.ProcessXAxis.ToString());
                this.pointCurve1.ProcessYAxis = Convert.ToInt32(objConfig.ProcessYAxis.ToString());
                this.pointCurve1.OutletXAxis = Convert.ToInt32(objConfig.OutletXAxis.ToString());
                this.pointCurve1.OutletYAxis = Convert.ToInt32(objConfig.OutletYAxis.ToString());

                //设置控制卡轴的脉冲输出模式
                Dmc2410.d2410_set_pulse_outmode(0, 0);
                Dmc2410.d2410_set_pulse_outmode(1, 0);
                Dmc2410.d2410_set_pulse_outmode(2, 0);
                Dmc2410.d2410_set_pulse_outmode(3, 0);

                Task.Run(new Action(() =>
                {
                    CheckAutoStop();
                }));

            }
        }

        #endregion

        #region 检测停止按钮
        private void CheckAutoStop()
        {
            while (true)
            {
                if (Dmc2410.d2410_read_inbit(0, 1) == 0)
                {
                    IsAutoStop = true;
                }
            }
        }
        #endregion

        #region 实时更新

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (IsCardExit)
            {
                //更新实时速度
                this.lbl_XAxisSpeed.Text = Dmc2410.d2410_read_current_speed(XAxis).ToString("f2");
                this.lbl_YAxisSpeed.Text = Dmc2410.d2410_read_current_speed(YAxis).ToString("f2");
                this.lbl_ZAxisSpeed.Text = Dmc2410.d2410_read_current_speed(ZAxis).ToString("f2");

                //更新实时位置
                this.lbl_XAxisPosition.Text = Dmc2410.d2410_get_position(XAxis).ToString("f2");
                this.lbl_YAxisPosition.Text = Dmc2410.d2410_get_position(YAxis).ToString("f2");
                this.lbl_ZAxisPosition.Text = Dmc2410.d2410_get_position(ZAxis).ToString("f2");

                //更新各个轴的状态
                ushort xStatus = Dmc2410.d2410_axis_io_status(XAxis);

                this.btn_Left.BackColor = GetbitValueWord(xStatus, 13) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;
                this.btn_Right.BackColor = GetbitValueWord(xStatus, 12) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;
                this.btn_XZero.BackColor = GetbitValueWord(xStatus, 14) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;


                ushort yStatus = Dmc2410.d2410_axis_io_status(YAxis);

                this.btn_Back.BackColor = GetbitValueWord(yStatus, 13) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;
                this.btn_Forward.BackColor = GetbitValueWord(yStatus, 12) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;
                this.btn_YZero.BackColor = GetbitValueWord(yStatus, 14) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;


                ushort zStatus = Dmc2410.d2410_axis_io_status(ZAxis);

                this.btn_Up.BackColor = GetbitValueWord(zStatus, 13) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;
                this.btn_Down.BackColor = GetbitValueWord(zStatus, 12) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;
                this.btn_ZZero.BackColor = GetbitValueWord(zStatus, 14) ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;

                #region 更新系统状态
                switch (SysStatus)
                {
                    case 0:
                        //更新UI
                        this.ld_state.ColorList = new Color[] { Color.FromArgb(255, 128, 0) };
                        this.lbl_state.Text = "系统就绪";

                        //更新指示灯
                        Dmc2410.d2410_write_outbit(0, 2, 0);
                        Dmc2410.d2410_write_outbit(0, 1, 1);
                        Dmc2410.d2410_write_outbit(0, 3, 1);

                        break;

                    case 1:
                        //更新UI
                        this.ld_state.ColorList = new Color[] { Color.Green };
                        this.lbl_state.Text = "系统运行";

                        //更新指示灯
                        Dmc2410.d2410_write_outbit(0, 3, 0);
                        Dmc2410.d2410_write_outbit(0, 1, 1);
                        Dmc2410.d2410_write_outbit(0, 2, 1);

                        break;
                    case 2:
                        //更新UI
                        this.ld_state.ColorList = new Color[] { Color.Red };
                        this.lbl_state.Text = "系统故障";

                        //更新指示灯
                        Dmc2410.d2410_write_outbit(0, 1, 0);
                        Dmc2410.d2410_write_outbit(0, 2, 1);
                        Dmc2410.d2410_write_outbit(0, 3, 1);

                        break;
                    default:
                        break;
                }
                #endregion

                #region 更新轨迹

                if (AddCurveEnable)
                {
                    this.pointCurve1.AddSinglePoint(new PointF(Convert.ToSingle(this.lbl_XAxisPosition.Text), Convert.ToSingle(this.lbl_YAxisPosition.Text)));
                }

                #endregion

            }

            CommonMethods.tickcount++;

            if (CommonMethods.tickcount == 1000 / UpdateTimer.Interval * objConfig.LockPeriod)
            {
                LockWorkStation();
            }
        }

        #endregion

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

        #region 定长运动控制

        private void btn_Right_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                CommonMotion(XAxis, 1);
            }
        }

        private void btn_Left_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                CommonMotion(XAxis, -1);
            }
        }

        private void btn_Forward_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                CommonMotion(YAxis, 1);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                CommonMotion(YAxis, -1);
            }
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                CommonMotion(ZAxis, -1);
            }
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                CommonMotion(ZAxis, 1);
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                Dmc2410.d2410_decel_stop(XAxis, Convert.ToDouble(num_Tac.Value));
                Dmc2410.d2410_decel_stop(YAxis, Convert.ToDouble(num_Tac.Value));
                Dmc2410.d2410_decel_stop(ZAxis, Convert.ToDouble(num_Tac.Value));
            }
        }

        private void btn_XAxisClear_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                Dmc2410.d2410_set_position(XAxis, 0);
            }
        }

        private void btn_YAxisClear_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                Dmc2410.d2410_set_position(YAxis, 0);
            }
        }

        private void btn_ZAxisClear_Click(object sender, EventArgs e)
        {
            if (JOGMotionCheck())
            {
                Dmc2410.d2410_set_position(ZAxis, 0);
            }
        }

        private void btn_XZero_Click(object sender, EventArgs e)
        {
            Dmc2410.d2410_set_HOME_pin_logic(XAxis, 0, 1); //设置 0 号轴原点信号低电平有效，使能滤波功能

            Dmc2410.d2410_config_home_mode(XAxis, 0, 0); //设置 0 号轴模式为遇原点后停止，EZ 信号出现次数为

            Dmc2410.d2410_home_move(XAxis, 2, 0);  //设置 0 号轴为负方向回原点，速度方式为低速回原点 

            while (Dmc2410.d2410_check_done(XAxis) == 0) //等待回原点动作完成
            {
                Thread.Sleep(10);
            }
            Dmc2410.d2410_set_position(XAxis, 0);
        }

        private void btn_YZero_Click(object sender, EventArgs e)
        {
            Dmc2410.d2410_set_HOME_pin_logic(YAxis, 0, 1); //设置 0 号轴原点信号低电平有效，使能滤波功能

            Dmc2410.d2410_config_home_mode(YAxis, 0, 0); //设置 0 号轴模式为遇原点后停止，EZ 信号出现次数为

            Dmc2410.d2410_home_move(YAxis, 2, 0);  //设置 0 号轴为负方向回原点，速度方式为低速回原点 

            while (Dmc2410.d2410_check_done(YAxis) == 0) //等待回原点动作完成
            {
                Thread.Sleep(10);
            }
            Dmc2410.d2410_set_position(YAxis, 0);
        }

        private void btn_ZZero_Click(object sender, EventArgs e)
        {
            Dmc2410.d2410_set_HOME_pin_logic(ZAxis, 0, 1); //设置 0 号轴原点信号低电平有效，使能滤波功能

            Dmc2410.d2410_config_home_mode(ZAxis, 0, 0); //设置 0 号轴模式为遇原点后停止，EZ 信号出现次数为

            Dmc2410.d2410_home_move(ZAxis, 2, 0);  //设置 0 号轴为负方向回原点，速度方式为低速回原点 

            while (Dmc2410.d2410_check_done(ZAxis) == 0) //等待回原点动作完成
            {
                Thread.Sleep(10);
            }
            Dmc2410.d2410_set_position(ZAxis, 0);
        }


        #endregion

        #region 定长运动前检测

        private bool JOGMotionCheck()
        {
            if (!IsCardExit)
            {
                AddLog(1, "板卡不存在，无法进行定长运动");
                return false;
            }

            if (AutoMode)
            {
                AddLog(1, "自动模式下，无法进行定长运动");
                return false;
            }
            return true;
        }

        #endregion

        #region 系统控制前检测

        private bool SystemMotionCheck()
        {
            if (!IsCardExit)
            {
                AddLog(1, "板卡不存在，无法进行定长运动");
                return false;
            }

            if (!AutoMode)
            {
                AddLog(1, "手动模式下，无法进行系统运动");
                return false;
            }
            return true;
        }

        #endregion

        #region 通用定长运动

        private void CommonMotion(ushort axis, int direction)
        {
            //获取设置的参数值
            double MinVel = Convert.ToDouble(num_MinVel.Value);

            double MaxVel = Convert.ToDouble(num_MaxVel.Value);

            double Tac = Convert.ToDouble(num_Tac.Value);

            double STac = Convert.ToDouble(num_STac.Value);

            short Distance = Convert.ToInt16(num_Dist.Value);

            Dmc2410.d2410_set_st_profile(axis, MinVel, MaxVel, Tac, Tac, STac, STac);

            Dmc2410.d2410_s_pmove(axis, Distance * direction, 0);
        }


        #endregion

        #region 窗体自动缩放及窗体关闭前事件

        private void FrmMonitor_Resize(object sender, EventArgs e)
        {
            this.MainPanel.Location = new Point((this.Width - this.MainPanel.Width) / 2, this.MainPanel.Location.Y);
        }

        private void FrmMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region 手自动切换按钮事件
        private void btn_Auto_Click(object sender, EventArgs e)
        {
            AutoMode = !AutoMode;

            this.btn_Auto.BackColor = AutoMode ? Color.FromArgb(0, 192, 0) : SystemColors.ControlLight;
            this.btn_Auto.ForeColor = AutoMode ? Color.White : SystemColors.ControlText;
            this.btn_Auto.Text = AutoMode ? "自动模式" : "手动模式";
        }

        #endregion

        #region 系统归零按钮事件
        private void btn_Home_Click(object sender, EventArgs e)
        {
            //判断
            if (SystemMotionCheck())
            {
                AddLog(0, "系统开始回零");

                this.btn_Home.Enabled = false;

                Task.Run(new Action(() =>
                {
                    if (HomeProcess())
                    {
                        AddLog(0, "系统回零完成");
                    }
                    else
                    {
                        AddLog(2, "系统回零失败");
                    }
                }));

                this.btn_Home.Enabled = true;
            }
        }
        #endregion

        #region 自动运行按钮事件
        private void btn_AutoRun_Click(object sender, EventArgs e)
        {
            //清除内容

            this.lbl_CurrentProduct.Text = "0";

            this.lbl_CurrentStep.Text = "0：系统待机状态";

            if (SystemMotionCheck())
            {
                //打开运动配置窗体

                FrmAutoRunSet objFrm = new FrmAutoRunSet();

                if (objFrm.ShowDialog() == DialogResult.OK)
                {
                    this.objRunMode = objFrm.objRunMode;

                    this.lbl_TotalProduct.Text = this.objRunMode.CircleTimes.ToString();

                    this.btn_AutoRun.Enabled = false;
                    this.btn_Home.Enabled = false;

                    Task.Run(new Action(() =>
                    {
                        if (HomeProcess())
                        {
                            AddCurveEnable = true;
                            AutoRunProcess();
                        }
                    }));

                    this.btn_AutoRun.Enabled = true;
                    this.btn_Home.Enabled = true;
                }
            }
        }
        #endregion

        #region 自动运行流程
        private void AutoRunProcess()
        {
            AddLog(0, "系统归零完成，等待触发");

            //初始化当前步骤
            CurrentStep = RunStep.RunReady;

            bool fRun = false;

            bool fOver = false;

            int Error = 0;

            int CycleTimes = 0;

            while (true)
            {
                //检测是否按下启动信号
                int start = Dmc2410.d2410_read_inbit(0, 2);

                if (start == 0)
                {
                    fRun = true;
                    CurrentStep = RunStep.MoveToReclaimer;
                }

                if (fRun)
                {
                    AddLog(0, "系统开始生产...");

                    MySQLHelper.Log("系统开始生产...", 0, CommonMethods.objAdmin.LoginName);

                    fRun = false;

                    SysStatus = 1;

                    while (true)
                    {
                        switch (CurrentStep)
                        {
                            case RunStep.MoveToReclaimer:

                                UpdateStep("1：前往取料口");

                                if (CycleTimes == 0)
                                {
                                    Dmc2410.d2410_set_position(XAxis, 0);
                                    Dmc2410.d2410_set_position(YAxis, 0);
                                    //设置直线插补的参数
                                    Dmc2410.d2410_set_vector_profile(objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac);

                                    Dmc2410.d2410_t_line2(XAxis, objConfig.OrginX, YAxis, objConfig.OrginY, 0);

                                }
                                else
                                {
                                    //设置直线插补的参数
                                    Dmc2410.d2410_set_vector_profile(objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac);

                                    Dmc2410.d2410_t_line2(XAxis, objConfig.OutletX, YAxis, objConfig.OutletY, 0);
                                }

                                while (Dmc2410.d2410_check_done(XAxis) == 0 || Dmc2410.d2410_check_done(YAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                if (CycleTimes > 0)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        this.pointCurve1.ClearAllPoints();
                                    }));
                                
                                }

                                break;
                            case RunStep.ReclaimerWait:

                                //实际项目在这里需要检测是否有料

                                UpdateStep("2：检测是否有料");

                                Thread.Sleep(2000);

                                break;
                            case RunStep.ReclaimerDown:

                                UpdateStep("3：取料口下降");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.DownZAxis, 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }
                                break;
                            case RunStep.ReclaimerGrap:

                                UpdateStep("4：取料口抓取");

                                //抓取物体
                                Dmc2410.d2410_write_outbit(0, 4, 0);

                                Thread.Sleep(500);

                                break;
                            case RunStep.ReclaimerUp:

                                UpdateStep("5：取料口上升");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.LiftZAxis * (-1), 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.MoveToProcess:

                                UpdateStep("6：前往加工位");

                                //设置直线插补的参数
                                Dmc2410.d2410_set_vector_profile(objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac);

                                Dmc2410.d2410_t_line2(XAxis, objConfig.ReclaimerX, YAxis, objConfig.ReclaimerY, 0);

                                while (Dmc2410.d2410_check_done(XAxis) == 0 || Dmc2410.d2410_check_done(YAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.ProcessCheck:

                                UpdateStep("7：检测是否有料");

                                //实际项目在这里需要检测是否有料

                                Thread.Sleep(2000);

                                break;
                            case RunStep.ProcessDown1:

                                UpdateStep("8：加工位下降I");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.LiftZAxis, 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.ProcessPutDown:

                                UpdateStep("9：加工位放下");

                                //放下物体
                                Dmc2410.d2410_write_outbit(0, 4, 1);

                                Thread.Sleep(500);

                                break;
                            case RunStep.ProcessUp1:

                                UpdateStep("10：加工位上升I");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.LiftZAxis * (-1), 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.ProcessWait:

                                UpdateStep("11：检测是否回来");

                                //实际项目在这里需要检测是否有料

                                Thread.Sleep(2000);

                                break;
                            case RunStep.ProcessDown2:

                                UpdateStep("12：加工位下降II");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.LiftZAxis, 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.ProcessGrab:
                                UpdateStep("13：加工位抓取");

                                //放下物体
                                Dmc2410.d2410_write_outbit(0, 4, 0);

                                Thread.Sleep(500);

                                break;
                            case RunStep.ProcessUp2:

                                UpdateStep("14：加工位上升II");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.LiftZAxis * (-1), 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.MoveToOutlet:

                                UpdateStep("15：前往出料口");

                                //设置直线插补的参数
                                Dmc2410.d2410_set_vector_profile(objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac);

                                Dmc2410.d2410_t_line2(XAxis, objConfig.ProcessX, YAxis, objConfig.ProcessY, 0);

                                while (Dmc2410.d2410_check_done(XAxis) == 0 || Dmc2410.d2410_check_done(YAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.OutletWait:

                                UpdateStep("16：出料口检测");

                                //实际项目在这里需要检测是否有料

                                Thread.Sleep(2000);


                                break;
                            case RunStep.OutletDown:

                                UpdateStep("17：出料口下降");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.LiftZAxis, 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }

                                break;
                            case RunStep.OutletPutDown:

                                UpdateStep("18：出料口放下");

                                //放下物体
                                Dmc2410.d2410_write_outbit(0, 4, 1);

                                Thread.Sleep(500);

                                break;
                            case RunStep.OutletUp:

                                UpdateStep("19：加工位上升");

                                Dmc2410.d2410_set_position(ZAxis, 0);

                                Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

                                Dmc2410.d2410_s_pmove(ZAxis, objConfig.LiftZAxis * (-1), 0);

                                while (Dmc2410.d2410_check_done(ZAxis) == 0)
                                {
                                    if (IsAutoStop)
                                    {
                                        fOver = true;
                                        break;
                                    }
                                    Thread.Sleep(10);
                                }
                                break;
                            case RunStep.RunReady:
                                break;
                            case RunStep.MaxStep:
                                break;
                            default:
                                break;
                        }

                        #region 检测是否有暂停信号
                        //检测是否有暂停信号

                        if (IsPause)
                        {
                            AddLog(0, "系统开始暂停");

                            MySQLHelper.Log("系统开始暂停", 0, CommonMethods.objAdmin.LoginName);

                            while (IsPause)
                            {
                                if (IsAutoStop)
                                {
                                    fOver = true;
                                    break;
                                }
                                Thread.Sleep(10);
                            }
                        }
                        #endregion

                        #region 检测是否有错误信号
                        //检测是否有错误信号
                        switch (Error)
                        {
                            //根据错误严重程序
                            case 1:
                                SysStatus = 2;
                                break;
                            case 2:
                                SysStatus = 2;
                                break;
                            default:
                                break;
                        }
                        #endregion

                        //当前步骤加1
                        CurrentStep++;

                        #region 检测是否为最后一步
                        //检测是否为最后一步
                        if (CurrentStep == RunStep.MaxStep)
                        {
                            CycleTimes++;

                            //更新当前产量
                            Invoke(new Action(() =>
                            {
                                this.lbl_CurrentProduct.Text = CycleTimes.ToString();
                            }));

                            //插入数据库（暂时传递一个随机结果到数据，后面可以改成视觉检测）
                            MySQLHelper.AddProduct(txt_LotNum.Text.Trim(), new Random().Next(0,1), CommonMethods.objAdmin.LoginName);

                            switch (this.objRunMode.CircleMode)
                            {
                                case CircleMode.OneAndHome:
                                    fOver = true;
                                    break;
                                case CircleMode.OneAndStop:
                                    fOver = true;
                                    break;
                                case CircleMode.CustomTime:
                                    //完成产量，正常结束
                                    if (CycleTimes == this.objRunMode.CircleTimes)
                                    {
                                        fOver = true;
                                    }
                                    else
                                    {
                                        CurrentStep = RunStep.MoveToReclaimer;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        #endregion

                        //检测fOver是否为true
                        if (fOver)
                        {
                            break;
                        }
                    }
                }

                if (fOver)
                {
                    if (IsAutoStop)
                    {
                        AddLog(1, "自动运行异常停止");

                        MySQLHelper.Log("自动运行异常停止", 1, CommonMethods.objAdmin.LoginName);

                        Dmc2410.d2410_decel_stop(XAxis, 0.1);
                        Dmc2410.d2410_decel_stop(YAxis, 0.1);
                        Dmc2410.d2410_decel_stop(ZAxis, 0.1);

                        SysStatus = 2;

                        IsAutoStop = false;
                    }
                    else
                    {
                        AddLog(0, "自动运行正常，生产完成");

                        MySQLHelper.Log("自动运行正常，生产完成", 0, CommonMethods.objAdmin.LoginName);

                        SysStatus = 0;                  
                    }

                   //将电磁阀关闭
                    Dmc2410.d2410_write_outbit(0, 4, 1);


                    //清除曲线
                    AddCurveEnable = false;

                    Invoke(new Action(() =>
                    {
                        this.pointCurve1.ClearAllPoints();
                        this.pointCurve1.Refresh();
                    }));

                    //根据模式判断是否归零
                    if (objRunMode.CircleMode != CircleMode.OneAndStop)
                    {
                        HomeProcess();
                    }
                    break;
                }
            }


        }
        #endregion

        #region 回零过程
        /// <summary>
        /// 回零过程
        /// </summary>
        private bool HomeProcess()
        {
            #region 复位Z轴

            //第一步：运动轴朝负方向运动，使用速度控制或定长运动（要使用较长的位移距离，保证能到达负限位）

            //Z轴脉冲清零

            Dmc2410.d2410_set_position(ZAxis, 0);

            Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

            Dmc2410.d2410_s_vmove(ZAxis, 0);

            while (Dmc2410.d2410_check_done(ZAxis) == 0)
            {
                long position = Dmc2410.d2410_get_position(ZAxis);

                if (position < -1 * this.pointCurve1.MaxZAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(ZAxis, 0.1);

                    AddLog(2, "Z轴异常，请检查！");

                    return false;

                }
            }

            //第二步：再朝正方向运动一定距离，保证刚好通过原点感应器

            Dmc2410.d2410_set_position(ZAxis, 0);

            Dmc2410.d2410_set_st_profile(ZAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

            Dmc2410.d2410_s_pmove(ZAxis, objConfig.ZAxisPosition, 0);

            while (Dmc2410.d2410_check_done(ZAxis) == 0)
            {
                long position = Dmc2410.d2410_get_position(ZAxis);

                if (position > this.pointCurve1.MaxZAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(ZAxis, 0.1);

                    AddLog(2, "Z轴异常，请检查！");

                    return false;
                }
            }

            //第三步：再朝负方向低速找原点

            Dmc2410.d2410_set_HOME_pin_logic(ZAxis, 0, 1);

            Dmc2410.d2410_config_home_mode(ZAxis, 0, 0);

            Dmc2410.d2410_home_move(ZAxis, 2, 0);

            while (Dmc2410.d2410_check_done(ZAxis) == 0)
            {
                long position = Dmc2410.d2410_get_position(ZAxis);

                if (position < -1 * this.pointCurve1.MaxZAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(ZAxis, 0.1);

                    AddLog(2, "Z轴异常，请检查！");

                    return false;

                }
            }

            Dmc2410.d2410_set_position(ZAxis, 0);

            #endregion

            #region 复位XY轴

            //第一步：运动轴朝负方向运动，使用速度控制或定长运动（要使用较长的位移距离，保证能到达负限位）

            Dmc2410.d2410_set_position(XAxis, 0);
            Dmc2410.d2410_set_position(YAxis, 0);

            Dmc2410.d2410_set_st_profile(XAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);
            Dmc2410.d2410_set_st_profile(YAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);

            Dmc2410.d2410_s_vmove(XAxis, 0);
            Dmc2410.d2410_s_vmove(YAxis, 0);


            while (Dmc2410.d2410_check_done(XAxis) == 0 || Dmc2410.d2410_check_done(YAxis) == 0)
            {

                long positionX = Dmc2410.d2410_get_position(XAxis);

                long positionY = Dmc2410.d2410_get_position(YAxis);

                if (positionX < -1 * this.pointCurve1.MaxXAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(XAxis, 0.1);

                    AddLog(2, "X轴异常，请检查！");

                    return false;
                }

                if (positionY < -1 * this.pointCurve1.MaxYAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(YAxis, 0.1);

                    AddLog(2, "Y轴异常，请检查！");

                    return false;
                }

            }

            //第二步：再朝正方向运动一定距离，保证刚好通过原点感应器

            Dmc2410.d2410_set_position(XAxis, 0);
            Dmc2410.d2410_set_position(YAxis, 0);

            Dmc2410.d2410_set_st_profile(XAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);
            Dmc2410.d2410_set_st_profile(YAxis, objConfig.VelMin, objConfig.VelMax, objConfig.Tac, objConfig.Tac, objConfig.STac, objConfig.STac);


            Dmc2410.d2410_s_pmove(XAxis, objConfig.XAxisPosition, 0);
            Dmc2410.d2410_s_pmove(YAxis, objConfig.YAxisPosition, 0);

            while (Dmc2410.d2410_check_done(XAxis) == 0 || Dmc2410.d2410_check_done(YAxis) == 0)
            {
                long positionX = Dmc2410.d2410_get_position(XAxis);
                long positionY = Dmc2410.d2410_get_position(XAxis);

                if (positionX > this.pointCurve1.MaxXAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(XAxis, 0.1);

                    AddLog(2, "X轴异常，请检查！");

                    return false;
                }

                if (positionY > this.pointCurve1.MaxYAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(YAxis, 0.1);

                    AddLog(2, "Y轴异常，请检查！");

                    return false;
                }
            }

            //第三步：再朝负方向低速找原点

            Dmc2410.d2410_set_HOME_pin_logic(XAxis, 0, 1);
            Dmc2410.d2410_set_HOME_pin_logic(YAxis, 0, 1);

            Dmc2410.d2410_config_home_mode(XAxis, 0, 0);
            Dmc2410.d2410_config_home_mode(YAxis, 0, 0);

            Dmc2410.d2410_home_move(XAxis, 2, 0);
            Dmc2410.d2410_home_move(YAxis, 2, 0);

            while (Dmc2410.d2410_check_done(XAxis) == 0 || Dmc2410.d2410_check_done(YAxis) == 0)
            {

                long positionX = Dmc2410.d2410_get_position(XAxis);

                long positionY = Dmc2410.d2410_get_position(YAxis);

                if (positionX < -1 * this.pointCurve1.MaxXAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(XAxis, 0.1);

                    AddLog(2, "X轴异常，请检查！");

                    return false;
                }

                if (positionY < -1 * this.pointCurve1.MaxYAxis)
                {
                    //当位置超限时，停止轴运动
                    Dmc2410.d2410_decel_stop(YAxis, 0.1);

                    AddLog(2, "Y轴异常，请检查！");

                    return false;
                }
            }

            Dmc2410.d2410_set_position(XAxis, 0);

            Dmc2410.d2410_set_position(YAxis, 0);

            #endregion

            #region 返回值

            return true;

            #endregion
        }

        #endregion

        #region 通过16位无符号整数获取某个位

        private bool GetbitValueWord(ushort val, int index)
        {
            byte[] input = BitConverter.GetBytes(val);
            if (input.Length == 2 && index >= 0 && index < 16)
            {
                byte low = input[0];
                byte high = input[1];
                switch (index)
                {
                    case 0: return ((byte)((low >> 0) & 0x1)).ToString() == "1";
                    case 1: return ((byte)((low >> 1) & 0x1)).ToString() == "1";
                    case 2: return ((byte)((low >> 2) & 0x1)).ToString() == "1";
                    case 3: return ((byte)((low >> 3) & 0x1)).ToString() == "1";
                    case 4: return ((byte)((low >> 4) & 0x1)).ToString() == "1";
                    case 5: return ((byte)((low >> 5) & 0x1)).ToString() == "1";
                    case 6: return ((byte)((low >> 6) & 0x1)).ToString() == "1";
                    case 7: return ((byte)((low >> 7) & 0x1)).ToString() == "1";
                    case 8: return ((byte)((high >> 0) & 0x1)).ToString() == "1";
                    case 9: return ((byte)((high >> 1) & 0x1)).ToString() == "1";
                    case 10: return ((byte)((high >> 2) & 0x1)).ToString() == "1";
                    case 11: return ((byte)((high >> 3) & 0x1)).ToString() == "1";
                    case 12: return ((byte)((high >> 4) & 0x1)).ToString() == "1";
                    case 13: return ((byte)((high >> 5) & 0x1)).ToString() == "1";
                    case 14: return ((byte)((high >> 6) & 0x1)).ToString() == "1";
                    case 15: return ((byte)((high >> 7) & 0x1)).ToString() == "1";
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }



        #endregion

        #region 更新运动步骤

        private void UpdateStep(string info)
        {
            Invoke(new Action(() =>
            {
                this.lbl_CurrentStep.Text = info;
            }));
        }

        #endregion

        #region 系统控制按钮事件
        private void btn_EmeStop_Click(object sender, EventArgs e)
        {
            Dmc2410.d2410_emg_stop();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            Dmc2410.d2410_reset_clear_flag(0);
            Dmc2410.d2410_board_rest();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            IsPause = !IsPause;
            this.btn_Pause.Text=IsPause?"恢复暂停":"暂停运行";
            this.btn_Pause.BackColor = IsPause ? Color.Red : SystemColors.ControlLight;
            this.btn_Pause.ForeColor = IsPause ? Color.White : SystemColors.ControlText;
        }
        #endregion

        #region 扫码控制
        private void btn_CodeCtrl_Click(object sender, EventArgs e)
        {
            if (this.btn_CodeCtrl.Text == "手动输入")
            {
                this.txt_LotNum.ReadOnly = false;
                this.btn_CodeCtrl.Text = "确定输入";
            }
            else
            {
                this.txt_LotNum.ReadOnly = true;
                this.btn_CodeCtrl.Text = "手动输入";
            }
        }
        #endregion

        #region 系统锁屏

        [DllImport("user32")]
        public static extern bool LockWorkStation();

        #endregion
    }

    #region 消息筛选器
    internal class MessageFilter : IMessageFilter
    {
        public bool PreFilterMessage(ref Message m)
        {
            //如果检测到有鼠标或则键盘的消息，则使计数为0.....
            if (m.Msg == 0x0200 || m.Msg == 0x0201 || m.Msg == 0x0204 || m.Msg == 0x0207)
            {
                CommonMethods.tickcount = 0;
            }
            return false;
        }
    }
    #endregion

}
