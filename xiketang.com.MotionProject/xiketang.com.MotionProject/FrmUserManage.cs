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
using xiketang.com.DAL;
using xiketang.com.Models;

namespace xiketang.com.MotionProject
{
    public partial class FrmUserManage : Form
    {
        public FrmUserManage()
        {
            InitializeComponent();
            this.Load += FrmUserManage_Load;
            this.dgv_User.AutoGenerateColumns = false;
        }

        private void FrmUserManage_Load(object sender, EventArgs e)
        {
            BindAdminList();
            this.txt_CurrentUser.Text = CommonMethods.objAdmin.LoginName;

            if (AdminList.Count > 0)
            {
                SysAdmins objAdmin = AdminList[0];

                this.txt_User.Text = objAdmin.LoginName;
                this.txt_Pwd.Text = objAdmin.LoginPwd;
                this.chk_HandCtrl.Checked = objAdmin.HandCtrl;
                this.chk_AutoCtrl.Checked = objAdmin.AutoCtrl;
                this.chk_SysSet.Checked = objAdmin.SysSet;
                this.chk_SysLog.Checked = objAdmin.SysLog;
                this.chk_Report.Checked = objAdmin.Report;
                this.chk_Trend.Checked = objAdmin.Trend;
                this.chk_UserManage.Checked = objAdmin.UserManage;
            }
        }

        List<SysAdmins> AdminList = new List<SysAdmins>();


        #region 绑定用户集合
        private void BindAdminList()
        {
            AdminList = GetAdminList();
            this.dgv_User.DataSource = null;
            this.dgv_User.DataSource = AdminList;
        }

        /// <summary>
        /// 获取所有的用户列表
        /// </summary>
        /// <returns></returns>
        private List<SysAdmins> GetAdminList()
        {
            string sql = "Select * from SysAdmins";

            MySqlDataReader dr = MySQLHelper.GetReader(sql);

            List<SysAdmins> AdminList = new List<SysAdmins>();

            while (dr.Read())
            {
                AdminList.Add(new SysAdmins()
                {
                    LoginName = dr["LoginName"].ToString(),
                    LoginPwd = Register.Decrypt(dr["LoginPwd"].ToString()),
                    HandCtrl = dr["HandCtrl"].ToString() == "1",
                    AutoCtrl = dr["AutoCtrl"].ToString() == "1",
                    SysSet = dr["SysSet"].ToString() == "1",
                    SysLog = dr["SysLog"].ToString() == "1",
                    Report = dr["Report"].ToString() == "1",
                    Trend = dr["Trend"].ToString() == "1",
                    UserManage = dr["UserManage"].ToString() == "1",
                });
            }
            return AdminList;
        }
        #endregion

        #region 点击DGV
        private void dgv_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgv_User.SelectedRows.Count > 0)
            {
                int index = e == null ? 0 : e.RowIndex;

                if (index >= 0)
                {
                    SysAdmins objAdmin = AdminList[index];

                    this.txt_User.Text = objAdmin.LoginName;
                    this.txt_Pwd.Text = objAdmin.LoginPwd;
                    this.chk_HandCtrl.Checked = objAdmin.HandCtrl;
                    this.chk_AutoCtrl.Checked = objAdmin.AutoCtrl;
                    this.chk_SysSet.Checked = objAdmin.SysSet;
                    this.chk_SysLog.Checked = objAdmin.SysLog;
                    this.chk_Report.Checked = objAdmin.Report;
                    this.chk_Trend.Checked = objAdmin.Trend;
                    this.chk_UserManage.Checked = objAdmin.UserManage;
                }
            }
        }
        #endregion

        #region 添加用户
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!CheckLoginNameExit(this.txt_User.Text.Trim()))
            {
                //封装用户对象
                SysAdmins objAdmin = new SysAdmins()
                {
                    LoginName = this.txt_User.Text.Trim(),
                    LoginPwd = Register.Encrypt(this.txt_Pwd.Text.Trim()),
                    HandCtrl = this.chk_HandCtrl.Checked,
                    AutoCtrl = this.chk_AutoCtrl.Checked,
                    SysSet = this.chk_SysSet.Checked,
                    SysLog = this.chk_SysLog.Checked,
                    Report = this.chk_Report.Checked,
                    Trend = this.chk_Trend.Checked,
                    UserManage = this.chk_UserManage.Checked
                };
                if (AddUser(objAdmin))
                {
                    MessageBox.Show("添加用户成功！", "添加用户");
                }
                else
                {
                    MessageBox.Show("添加用户失败！", "添加用户");
                    return;
                }
                BindAdminList();
            }
            else
            {
                MessageBox.Show("当前用户名已经存在，请修改后添加", "添加用户");            
            }
        }

        #endregion

        #region 检测用户名是否存在，存在为True，不存在未False
        private bool CheckLoginNameExit(string LoginName)
        {
            foreach (var item in AdminList)
            {
                if (item.LoginName == LoginName)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 根据用户对象添加用户

        private bool AddUser(SysAdmins objAdmin)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Insert into SysAdmins(LoginName,LoginPwd,HandCtrl,AutoCtrl,SysSet,SysLog,Report,Trend,UserManage)");

            sb.Append(" values('{0}','{1}',{2},{3},{4},{5},{6},{7},{8})");

            string sql = string.Format(sb.ToString(), objAdmin.LoginName, objAdmin.LoginPwd, objAdmin.HandCtrl?1:0, objAdmin.AutoCtrl ? 1 : 0, 
                
                objAdmin.SysSet ? 1 : 0, objAdmin.SysLog ? 1 : 0, objAdmin.Report ? 1 : 0, objAdmin.Trend ? 1 : 0, objAdmin.UserManage ? 1 : 0);

            return MySQLHelper.Update(sql) == 1;

        }
        #endregion


        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.txt_User.Text == "管理员")
            {
                MessageBox.Show("管理员用户无法删除", "删除用户");
                return;
            }

            SysAdmins objAdmin = new SysAdmins()
            {
                LoginName = this.txt_User.Text.Trim()
            };
            if (DeleteUser(objAdmin))
            {
                MessageBox.Show("用户删除成功！", "删除用户");
            }
            else
            {
                MessageBox.Show("用户删除失败！", "删除用户");
                return;
            }
            BindAdminList();
        }


        #region 根据用户对象进行删除

        private bool DeleteUser(SysAdmins objAdmin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Delete from SysAdmins");
            sb.Append(" where LoginName='{0}'");

            string sql = string.Format(sb.ToString(), objAdmin.LoginName);

            return MySQLHelper.Update(sql) == 1;
        
        }

        #endregion


        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (this.txt_User.Text == "管理员" && this.txt_CurrentUser.Text != "管理员")
            {
                MessageBox.Show("管理员信息修改权限不足", "保存修改");
                return;
            }

            if (CheckLoginNameExit(this.txt_User.Text))
            {
                //封装用户对象
                SysAdmins objAdmin = new SysAdmins()
                {
                    LoginName = this.txt_User.Text.Trim(),
                    LoginPwd = Register.Encrypt(this.txt_Pwd.Text.Trim()),
                    HandCtrl = this.chk_HandCtrl.Checked,
                    AutoCtrl = this.chk_AutoCtrl.Checked,
                    SysSet = this.chk_SysSet.Checked,
                    SysLog = this.chk_SysLog.Checked,
                    Report = this.chk_Report.Checked,
                    Trend = this.chk_Trend.Checked,
                    UserManage = this.chk_UserManage.Checked
                };
                if (UpdateUser(objAdmin))
                {
                    MessageBox.Show("用户信息修改成功", "保存修改");
                }
                else
                {
                    MessageBox.Show("用户信息修改失败", "保存修改");
                    return;
                }

                BindAdminList();
            }
            else
            {
                MessageBox.Show("当前修改的用户名不存在，请添加后修改", "保存修改");
            }

        }

        private bool UpdateUser(SysAdmins objAdmin)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Update SysAdmins set LoginPwd='{0}',HandCtrl={1},AutoCtrl={2},");

            sb.Append("SysSet={3},SysLog={4},Report={5},Trend={6},UserManage={7}");

            sb.Append(" where LoginName='{8}'");

            string sql = string.Format(sb.ToString(), objAdmin.LoginPwd, objAdmin.HandCtrl ? 1 : 0,

                objAdmin.AutoCtrl ? 1 : 0, objAdmin.SysSet ? 1 : 0, objAdmin.SysLog ? 1 : 0, objAdmin.Report ? 1 : 0,

                 objAdmin.Trend ? 1 : 0, objAdmin.UserManage ? 1 : 0, objAdmin.LoginName);

            return MySQLHelper.Update(sql) == 1;
        
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            if (this.btn_Select.Text == "全选")
            {
                foreach (var item in groupBox2.Controls)
                {
                    if (item is CheckBox chk)
                    {
                        chk.Checked = true;
                    }
                }
                this.btn_Select.Text = "全不选";
            }
            else
            {
                foreach (var item in groupBox2.Controls)
                {
                    if (item is CheckBox chk)
                    {
                        chk.Checked = false;
                    }
                }
                this.btn_Select.Text = "全选";
            }
        }
    }
}
