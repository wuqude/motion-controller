using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using xiketang.com.DAL;
using xiketang.com.Models;

namespace xiketang.com.MotionProject
{
    public partial class FrmSysSet : DockContent
    {
        public FrmSysSet()
        {
            InitializeComponent();

            this.Load += FrmSysSet_Load;
        }

        private void FrmSysSet_Load(object sender, EventArgs e)
        {
            this.btn_Licence.Visible = CommonMethods.objAdmin.LoginName == "超级管理员";

            ConfigInfo objConfig = CommonMethods.LoadSettings();

            if (objConfig != null)
            {
                this.num_MinVel.Value = Convert.ToDecimal(objConfig.VelMin);
                this.num_MaxVel.Value = Convert.ToDecimal(objConfig.VelMax);
                this.num_Tac.Value = Convert.ToDecimal(objConfig.Tac);
                this.num_STac.Value = Convert.ToDecimal(objConfig.STac);
                this.num_XAxis.Value = decimal.Parse(objConfig.XAxisPosition.ToString());
                this.num_YAxis.Value = decimal.Parse(objConfig.YAxisPosition.ToString());
                this.num_ZAxis.Value = decimal.Parse(objConfig.ZAxisPosition.ToString());

                this.btn_AutoLock.Checked = objConfig.AutoLock;
                this.num_LockPeriod.Value = decimal.Parse(objConfig.LockPeriod.ToString());


                this.num_reclaimerX.Value = decimal.Parse(objConfig.ReclaimerXAxis.ToString());
                this.num_reclaimerY.Value = decimal.Parse(objConfig.ReclaimerYAxis.ToString());
                this.num_processX.Value = decimal.Parse(objConfig.ProcessXAxis.ToString());
                this.num_processY.Value = decimal.Parse(objConfig.ProcessYAxis.ToString());
                this.num_outletX.Value = decimal.Parse(objConfig.OutletXAxis.ToString());
                this.num_outletY.Value = decimal.Parse(objConfig.OutletYAxis.ToString());
                this.num_DownZ.Value = decimal.Parse(objConfig.DownZAxis.ToString());
                this.num_LiftZ.Value = decimal.Parse(objConfig.LiftZAxis.ToString());

                this.pointCurve1.ReclaimerXAxis = Convert.ToInt32(objConfig.ReclaimerXAxis.ToString());
                this.pointCurve1.ReclaimerYAxis = Convert.ToInt32(objConfig.ReclaimerYAxis.ToString());
                this.pointCurve1.ProcessXAxis = Convert.ToInt32(objConfig.ProcessXAxis.ToString());
                this.pointCurve1.ProcessYAxis = Convert.ToInt32(objConfig.ProcessYAxis.ToString());
                this.pointCurve1.OutletXAxis = Convert.ToInt32(objConfig.OutletXAxis.ToString());
                this.pointCurve1.OutletYAxis = Convert.ToInt32(objConfig.OutletYAxis.ToString());
            }
            else
            {
                MessageBox.Show("配置文件格式解析不正确", "加载配置");
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (SaveIniConfig())
            {
                MessageBox.Show("保存配置成功！", "保持配置");
            }
            else
            {
                MessageBox.Show("保存配置失败！", "保持配置");
            }
        }

        #region 保存配置信息
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <returns>是否成功</returns>
        private bool SaveIniConfig()
        {
            //判断文件是否存在
            if (!File.Exists(CommonMethods.SysSetPath))
            {
                FileStream fs = new FileStream(CommonMethods.SysSetPath, FileMode.Create);
                fs.Close();
            }

            bool result = true;

            //自动运动参数

            result &= IniConfigHelper.WriteIniData("自动运动参数", "初始速度", this.num_MinVel.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运动参数", "运行速度", this.num_MaxVel.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运动参数", "加速时间", this.num_Tac.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运动参数", "S段时间", this.num_STac.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运动参数", "X轴原限", this.num_XAxis.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运动参数", "Y轴原限", this.num_YAxis.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运动参数", "Z轴原限", this.num_ZAxis.Value.ToString(), CommonMethods.SysSetPath);

            //系统锁屏设置

            result &= IniConfigHelper.WriteIniData("系统锁屏设置", "是否自动锁屏", this.btn_AutoLock.Checked ? "1" : "0", CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("系统锁屏设置", "自动锁屏间隔", this.num_LockPeriod.Value.ToString(), CommonMethods.SysSetPath);

            //自动运行轨迹

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "取料口运动X轴", this.num_reclaimerX.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "取料口运动Y轴", this.num_reclaimerY.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "加工处运动X轴", this.num_processX.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "加工处运动Y轴", this.num_processY.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "出料口运动X轴", this.num_outletX.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "出料口运动Y轴", this.num_outletY.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "下降Z轴", this.num_DownZ.Value.ToString(), CommonMethods.SysSetPath);

            result &= IniConfigHelper.WriteIniData("自动运行轨迹", "上升Z轴", this.num_LiftZ.Value.ToString(), CommonMethods.SysSetPath);

            return result;

        }
        #endregion

        #region 设定值发生改变事件
        private void FrmSysSet_Resize(object sender, EventArgs e)
        {
            this.MainPanel.Location = new Point((this.Width - this.MainPanel.Width) / 2, this.MainPanel.Location.Y);
        }

        private void num_reclaimerX_ValueChanged(object sender, EventArgs e)
        {
            this.pointCurve1.ReclaimerXAxis = Convert.ToInt32(this.num_reclaimerX.Value);
        }

        private void num_reclaimerY_ValueChanged(object sender, EventArgs e)
        {
            this.pointCurve1.ReclaimerYAxis = Convert.ToInt32(this.num_reclaimerY.Value);
        }

        private void num_processX_ValueChanged(object sender, EventArgs e)
        {
            this.pointCurve1.ProcessXAxis = Convert.ToInt32(this.num_processX.Value);
        }

        private void num_processY_ValueChanged(object sender, EventArgs e)
        {
            this.pointCurve1.ProcessYAxis = Convert.ToInt32(this.num_processY.Value);
        }

        private void num_outletX_ValueChanged(object sender, EventArgs e)
        {
            this.pointCurve1.OutletXAxis = Convert.ToInt32(this.num_outletX.Value);
        }

        private void num_outletY_ValueChanged(object sender, EventArgs e)
        {
            this.pointCurve1.OutletYAxis = Convert.ToInt32(this.num_outletY.Value);
        }
        #endregion

        #region 授权管理

        private void btn_Licence_Click(object sender, EventArgs e)
        {
            try
            {
                Regedit.AddItem("xiketang", "xiketang", Register.Encrypt());
            }
            catch (Exception)
            {

                MessageBox.Show("授权失败！", "软件授权");
                return;
            }
            MessageBox.Show("授权成功，重启生效！", "软件授权");
        }

        #endregion
    }
}
