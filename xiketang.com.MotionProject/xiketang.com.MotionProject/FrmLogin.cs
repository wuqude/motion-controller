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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            this.Load += FrmLogin_Load;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InitialUserList();
        }

        #region 初始化用户列表

        private void InitialUserList()
        {
            string sql = "Select * from SysAdmins";

            MySqlDataReader dr = MySQLHelper.GetReader(sql);

            List<string> UserList = new List<string>();

            while (dr.Read())
            {
                UserList.Add(dr["LoginName"].ToString());
            }

            if (UserList.Count > 0)
            {
                this.cmb_User.DataSource = UserList;
                this.cmb_User.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("用户列表为空！", "系统登录");
            }

        }

        #endregion

        #region 系统登录按钮

        private void btn_Login_Click(object sender, EventArgs e)
        {
            //数据验证

            if (this.cmb_User.Text.Length == 0)
            {
                MessageBox.Show("请选择用户名！", "登录提示");
                this.cmb_User.Focus();
                return;
            }

            if (this.txt_LoginPwd.Text.Length == 0)
            {
                MessageBox.Show("请填写登录密码！", "登录提示");
                this.txt_LoginPwd.Focus();
                return;
            }

            //封装对象
            SysAdmins objAdmin = new SysAdmins()
            {
                LoginName = this.cmb_User.Text.Trim(),
                //给密码做加密
                LoginPwd = Register.Encrypt(this.txt_LoginPwd.Text.Trim())
            };

            //登录验证
            objAdmin = AdminCheck(objAdmin);

            if (objAdmin != null)
            {
                //设置DialResult
                this.DialogResult = DialogResult.OK;

                //保存用户信息
                CommonMethods.objAdmin = objAdmin;
            }
            else
            {
                MessageBox.Show("用户名或密码错误！", "登录提示");
            }
        }

        #endregion

        #region 退出系统按钮
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 登录查询的方法
        /// <summary>
        /// 登录查询的方法
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        private SysAdmins AdminCheck(SysAdmins objAdmin)
        {
            string sql = "Select * from SysAdmins where LoginName='{0}' and LoginPwd='{1}'";

            sql = string.Format(sql, objAdmin.LoginName, objAdmin.LoginPwd);

            DataSet ds = MySQLHelper.GetDataSet(sql);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                objAdmin.HandCtrl = dt.Rows[0]["HandCtrl"].ToString() == "1";
                objAdmin.AutoCtrl = dt.Rows[0]["AutoCtrl"].ToString() == "1";
                objAdmin.SysSet = dt.Rows[0]["SysSet"].ToString() == "1";
                objAdmin.SysLog = dt.Rows[0]["SysLog"].ToString() == "1";
                objAdmin.Report = dt.Rows[0]["Report"].ToString() == "1";
                objAdmin.Trend = dt.Rows[0]["Trend"].ToString() == "1";
                objAdmin.UserManage = dt.Rows[0]["UserManage"].ToString() == "1";

                return objAdmin;
            }
            else
            {
                return null;
            }    
        }
        #endregion

        #region 快捷登录
        private void txt_LoginPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_Login_Click(null, null);
            }
        }

        private void cmb_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_Login_Click(null, null);
            }
        }
        #endregion

        private void FrmLogin_Load_1(object sender, EventArgs e)
        {

        }

        #region 登录查询的方法
        /// <summary>
        /// 登录查询的方法
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        private SysAdmins AdminCheck(SysAdmins objAdmin)
        {
            string sql = "Select * from SysAdmins where LoginName='{0}' and LoginPwd='{1}'";

            sql = string.Format(sql, objAdmin.LoginName, objAdmin.LoginPwd);

            DataSet ds = MySQLHelper.GetDataSet(sql);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                objAdmin.HandCtrl = dt.Rows[0]["HandCtrl"].ToString() == "1";
                objAdmin.AutoCtrl = dt.Rows[0]["AutoCtrl"].ToString() == "1";
                objAdmin.SysSet = dt.Rows[0]["SysSet"].ToString() == "1";
                objAdmin.SysLog = dt.Rows[0]["SysLog"].ToString() == "1";
                objAdmin.Report = dt.Rows[0]["Report"].ToString() == "1";
                objAdmin.Trend = dt.Rows[0]["Trend"].ToString() == "1";
                objAdmin.UserManage = dt.Rows[0]["UserManage"].ToString() == "1";

                return objAdmin;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}
