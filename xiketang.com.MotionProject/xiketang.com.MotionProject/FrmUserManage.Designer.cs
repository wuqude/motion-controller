namespace xiketang.com.MotionProject
{
    partial class FrmUserManage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserManage));
            this.dgv_User = new System.Windows.Forms.DataGridView();
            this.LoginName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_CurrentUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_User = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_HandCtrl = new System.Windows.Forms.CheckBox();
            this.chk_AutoCtrl = new System.Windows.Forms.CheckBox();
            this.chk_SysLog = new System.Windows.Forms.CheckBox();
            this.chk_Trend = new System.Windows.Forms.CheckBox();
            this.chk_Report = new System.Windows.Forms.CheckBox();
            this.chk_SysSet = new System.Windows.Forms.CheckBox();
            this.chk_UserManage = new System.Windows.Forms.CheckBox();
            this.btn_Add = new XKTControl.xktButton(this.components);
            this.btn_Delete = new XKTControl.xktButton(this.components);
            this.btn_Save = new XKTControl.xktButton(this.components);
            this.btn_Select = new XKTControl.xktButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_User
            // 
            this.dgv_User.AllowUserToAddRows = false;
            this.dgv_User.AllowUserToDeleteRows = false;
            this.dgv_User.AllowUserToResizeColumns = false;
            this.dgv_User.AllowUserToResizeRows = false;
            this.dgv_User.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_User.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_User.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_User.ColumnHeadersHeight = 35;
            this.dgv_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LoginName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_User.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_User.EnableHeadersVisualStyles = false;
            this.dgv_User.Location = new System.Drawing.Point(24, 27);
            this.dgv_User.Name = "dgv_User";
            this.dgv_User.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_User.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_User.RowHeadersWidth = 25;
            this.dgv_User.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_User.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_User.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_User.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_User.RowTemplate.Height = 30;
            this.dgv_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_User.Size = new System.Drawing.Size(232, 324);
            this.dgv_User.TabIndex = 33;
            this.dgv_User.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_User_CellClick);
            // 
            // LoginName
            // 
            this.LoginName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoginName.DataPropertyName = "LoginName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LoginName.DefaultCellStyle = dataGridViewCellStyle2;
            this.LoginName.FillWeight = 27.11618F;
            this.LoginName.HeaderText = "用户名";
            this.LoginName.Name = "LoginName";
            this.LoginName.ReadOnly = true;
            this.LoginName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_CurrentUser
            // 
            this.txt_CurrentUser.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_CurrentUser.Location = new System.Drawing.Point(109, 382);
            this.txt_CurrentUser.Name = "txt_CurrentUser";
            this.txt_CurrentUser.ReadOnly = true;
            this.txt_CurrentUser.Size = new System.Drawing.Size(134, 25);
            this.txt_CurrentUser.TabIndex = 36;
            this.txt_CurrentUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "当前用户：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Pwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_User);
            this.groupBox1.Font = new System.Drawing.Font("黑体", 11F);
            this.groupBox1.Location = new System.Drawing.Point(277, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 70);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 11F);
            this.label3.Location = new System.Drawing.Point(230, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "密码：";
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Font = new System.Drawing.Font("黑体", 11F);
            this.txt_Pwd.Location = new System.Drawing.Point(287, 26);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(102, 24);
            this.txt_Pwd.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 11F);
            this.label2.Location = new System.Drawing.Point(31, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "用户名：";
            // 
            // txt_User
            // 
            this.txt_User.Font = new System.Drawing.Font("黑体", 11F);
            this.txt_User.Location = new System.Drawing.Point(104, 25);
            this.txt_User.Name = "txt_User";
            this.txt_User.Size = new System.Drawing.Size(106, 24);
            this.txt_User.TabIndex = 34;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Select);
            this.groupBox2.Controls.Add(this.chk_HandCtrl);
            this.groupBox2.Controls.Add(this.chk_AutoCtrl);
            this.groupBox2.Controls.Add(this.chk_SysLog);
            this.groupBox2.Controls.Add(this.chk_Trend);
            this.groupBox2.Controls.Add(this.chk_Report);
            this.groupBox2.Controls.Add(this.chk_SysSet);
            this.groupBox2.Controls.Add(this.chk_UserManage);
            this.groupBox2.Font = new System.Drawing.Font("黑体", 11F);
            this.groupBox2.Location = new System.Drawing.Point(277, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 235);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户权限";
            // 
            // chk_HandCtrl
            // 
            this.chk_HandCtrl.AutoSize = true;
            this.chk_HandCtrl.Font = new System.Drawing.Font("黑体", 11F);
            this.chk_HandCtrl.Location = new System.Drawing.Point(78, 35);
            this.chk_HandCtrl.Name = "chk_HandCtrl";
            this.chk_HandCtrl.Size = new System.Drawing.Size(90, 19);
            this.chk_HandCtrl.TabIndex = 0;
            this.chk_HandCtrl.Text = "手动控制";
            this.chk_HandCtrl.UseVisualStyleBackColor = true;
            // 
            // chk_AutoCtrl
            // 
            this.chk_AutoCtrl.AutoSize = true;
            this.chk_AutoCtrl.Font = new System.Drawing.Font("黑体", 11F);
            this.chk_AutoCtrl.Location = new System.Drawing.Point(269, 35);
            this.chk_AutoCtrl.Name = "chk_AutoCtrl";
            this.chk_AutoCtrl.Size = new System.Drawing.Size(90, 19);
            this.chk_AutoCtrl.TabIndex = 0;
            this.chk_AutoCtrl.Text = "自动控制";
            this.chk_AutoCtrl.UseVisualStyleBackColor = true;
            // 
            // chk_SysLog
            // 
            this.chk_SysLog.AutoSize = true;
            this.chk_SysLog.Font = new System.Drawing.Font("黑体", 11F);
            this.chk_SysLog.Location = new System.Drawing.Point(269, 87);
            this.chk_SysLog.Name = "chk_SysLog";
            this.chk_SysLog.Size = new System.Drawing.Size(90, 19);
            this.chk_SysLog.TabIndex = 0;
            this.chk_SysLog.Text = "系统日志";
            this.chk_SysLog.UseVisualStyleBackColor = true;
            // 
            // chk_Trend
            // 
            this.chk_Trend.AutoSize = true;
            this.chk_Trend.Font = new System.Drawing.Font("黑体", 11F);
            this.chk_Trend.Location = new System.Drawing.Point(269, 139);
            this.chk_Trend.Name = "chk_Trend";
            this.chk_Trend.Size = new System.Drawing.Size(90, 19);
            this.chk_Trend.TabIndex = 0;
            this.chk_Trend.Text = "数据记录";
            this.chk_Trend.UseVisualStyleBackColor = true;
            // 
            // chk_Report
            // 
            this.chk_Report.AutoSize = true;
            this.chk_Report.Font = new System.Drawing.Font("黑体", 11F);
            this.chk_Report.Location = new System.Drawing.Point(78, 139);
            this.chk_Report.Name = "chk_Report";
            this.chk_Report.Size = new System.Drawing.Size(90, 19);
            this.chk_Report.TabIndex = 0;
            this.chk_Report.Text = "数据统计";
            this.chk_Report.UseVisualStyleBackColor = true;
            // 
            // chk_SysSet
            // 
            this.chk_SysSet.AutoSize = true;
            this.chk_SysSet.Font = new System.Drawing.Font("黑体", 11F);
            this.chk_SysSet.Location = new System.Drawing.Point(78, 87);
            this.chk_SysSet.Name = "chk_SysSet";
            this.chk_SysSet.Size = new System.Drawing.Size(90, 19);
            this.chk_SysSet.TabIndex = 0;
            this.chk_SysSet.Text = "系统设置";
            this.chk_SysSet.UseVisualStyleBackColor = true;
            // 
            // chk_UserManage
            // 
            this.chk_UserManage.AutoSize = true;
            this.chk_UserManage.Font = new System.Drawing.Font("黑体", 11F);
            this.chk_UserManage.Location = new System.Drawing.Point(78, 191);
            this.chk_UserManage.Name = "chk_UserManage";
            this.chk_UserManage.Size = new System.Drawing.Size(90, 19);
            this.chk_UserManage.TabIndex = 0;
            this.chk_UserManage.Text = "用户权限";
            this.chk_UserManage.UseVisualStyleBackColor = true;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Add.ButtonType = XKTControl.xktButton.ButtonPresetImage.Check;
            this.btn_Add.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.Image")));
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(301, 375);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(101, 39);
            this.btn_Add.TabIndex = 39;
            this.btn_Add.Text = "添加用户";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Delete.ButtonType = XKTControl.xktButton.ButtonPresetImage.Cancel;
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Location = new System.Drawing.Point(441, 374);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(101, 39);
            this.btn_Delete.TabIndex = 39;
            this.btn_Delete.Text = "删除用户";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Save.ButtonType = XKTControl.xktButton.ButtonPresetImage.Down;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(581, 374);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(101, 39);
            this.btn_Save.TabIndex = 39;
            this.btn_Save.Text = "保存修改";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Select.ButtonType = XKTControl.xktButton.ButtonPresetImage.None;
            this.btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Select.Location = new System.Drawing.Point(269, 177);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(79, 39);
            this.btn_Select.TabIndex = 40;
            this.btn_Select.Text = "全选";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // FrmUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 433);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_CurrentUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_User);
            this.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmUserManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户权限管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_User;
        private System.Windows.Forms.TextBox txt_CurrentUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_User;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_HandCtrl;
        private System.Windows.Forms.CheckBox chk_AutoCtrl;
        private System.Windows.Forms.CheckBox chk_SysLog;
        private System.Windows.Forms.CheckBox chk_Trend;
        private System.Windows.Forms.CheckBox chk_Report;
        private System.Windows.Forms.CheckBox chk_SysSet;
        private System.Windows.Forms.CheckBox chk_UserManage;
        private XKTControl.xktButton btn_Add;
        private XKTControl.xktButton btn_Delete;
        private XKTControl.xktButton btn_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoginName;
        private XKTControl.xktButton btn_Select;
    }
}