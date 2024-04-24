namespace xiketang.com.MotionProject
{
    partial class FrmNavi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNavi));
            this.btn_Monitor = new System.Windows.Forms.Button();
            this.btn_SysSet = new System.Windows.Forms.Button();
            this.btn_SysLog = new System.Windows.Forms.Button();
            this.btn_Report = new System.Windows.Forms.Button();
            this.btn_Trend = new System.Windows.Forms.Button();
            this.btn_UserManage = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Monitor
            // 
            this.btn_Monitor.FlatAppearance.BorderSize = 0;
            this.btn_Monitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Monitor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Monitor.Image = global::xiketang.com.MotionProject.Properties.Resources.monitor_24px_1088510_easyicon_net;
            this.btn_Monitor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Monitor.Location = new System.Drawing.Point(16, 28);
            this.btn_Monitor.Name = "btn_Monitor";
            this.btn_Monitor.Size = new System.Drawing.Size(74, 56);
            this.btn_Monitor.TabIndex = 0;
            this.btn_Monitor.Text = "集中监控";
            this.btn_Monitor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Monitor.UseVisualStyleBackColor = true;
            this.btn_Monitor.Click += new System.EventHandler(this.btn_Monitor_Click);
            // 
            // btn_SysSet
            // 
            this.btn_SysSet.FlatAppearance.BorderSize = 0;
            this.btn_SysSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SysSet.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SysSet.Image = global::xiketang.com.MotionProject.Properties.Resources.tool_24px_1088507_easyicon_net;
            this.btn_SysSet.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SysSet.Location = new System.Drawing.Point(16, 118);
            this.btn_SysSet.Name = "btn_SysSet";
            this.btn_SysSet.Size = new System.Drawing.Size(74, 56);
            this.btn_SysSet.TabIndex = 0;
            this.btn_SysSet.Text = "系统设置";
            this.btn_SysSet.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SysSet.UseVisualStyleBackColor = true;
            this.btn_SysSet.Click += new System.EventHandler(this.btn_SysSet_Click);
            // 
            // btn_SysLog
            // 
            this.btn_SysLog.FlatAppearance.BorderSize = 0;
            this.btn_SysLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SysLog.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SysLog.Image = global::xiketang.com.MotionProject.Properties.Resources.alert_24px_555455_easyicon_net;
            this.btn_SysLog.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_SysLog.Location = new System.Drawing.Point(16, 208);
            this.btn_SysLog.Name = "btn_SysLog";
            this.btn_SysLog.Size = new System.Drawing.Size(74, 56);
            this.btn_SysLog.TabIndex = 0;
            this.btn_SysLog.Text = "系统日志";
            this.btn_SysLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_SysLog.UseVisualStyleBackColor = true;
            this.btn_SysLog.Click += new System.EventHandler(this.btn_SysLog_Click);
            // 
            // btn_Report
            // 
            this.btn_Report.FlatAppearance.BorderSize = 0;
            this.btn_Report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Report.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Report.Image = global::xiketang.com.MotionProject.Properties.Resources.note_24px_555457_easyicon_net;
            this.btn_Report.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Report.Location = new System.Drawing.Point(16, 298);
            this.btn_Report.Name = "btn_Report";
            this.btn_Report.Size = new System.Drawing.Size(74, 56);
            this.btn_Report.TabIndex = 0;
            this.btn_Report.Text = "数据统计";
            this.btn_Report.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Report.UseVisualStyleBackColor = true;
            this.btn_Report.Click += new System.EventHandler(this.btn_Report_Click);
            // 
            // btn_Trend
            // 
            this.btn_Trend.FlatAppearance.BorderSize = 0;
            this.btn_Trend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Trend.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Trend.Image = global::xiketang.com.MotionProject.Properties.Resources.stats_24px_1088513_easyicon_net;
            this.btn_Trend.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Trend.Location = new System.Drawing.Point(16, 388);
            this.btn_Trend.Name = "btn_Trend";
            this.btn_Trend.Size = new System.Drawing.Size(74, 56);
            this.btn_Trend.TabIndex = 0;
            this.btn_Trend.Text = "数据记录";
            this.btn_Trend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Trend.UseVisualStyleBackColor = true;
            this.btn_Trend.Click += new System.EventHandler(this.btn_Trend_Click);
            // 
            // btn_UserManage
            // 
            this.btn_UserManage.FlatAppearance.BorderSize = 0;
            this.btn_UserManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UserManage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_UserManage.Image = global::xiketang.com.MotionProject.Properties.Resources.user_24px_1088466_easyicon_net;
            this.btn_UserManage.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_UserManage.Location = new System.Drawing.Point(16, 478);
            this.btn_UserManage.Name = "btn_UserManage";
            this.btn_UserManage.Size = new System.Drawing.Size(74, 56);
            this.btn_UserManage.TabIndex = 0;
            this.btn_UserManage.Text = "用户管理";
            this.btn_UserManage.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_UserManage.UseVisualStyleBackColor = true;
            this.btn_UserManage.Click += new System.EventHandler(this.btn_UserManage_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.FlatAppearance.BorderSize = 0;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.Image = global::xiketang.com.MotionProject.Properties.Resources._24px_1088449_easyicon_net;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Exit.Location = new System.Drawing.Point(16, 568);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 56);
            this.btn_Exit.TabIndex = 0;
            this.btn_Exit.Text = "注销系统";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // FrmNavi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 650);
            this.CloseButtonVisible = false;
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_UserManage);
            this.Controls.Add(this.btn_Trend);
            this.Controls.Add(this.btn_Report);
            this.Controls.Add(this.btn_SysLog);
            this.Controls.Add(this.btn_SysSet);
            this.Controls.Add(this.btn_Monitor);
            this.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmNavi";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "系统导航";
            this.Load += new System.EventHandler(this.FrmNavi_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Monitor;
        private System.Windows.Forms.Button btn_SysSet;
        private System.Windows.Forms.Button btn_SysLog;
        private System.Windows.Forms.Button btn_Report;
        private System.Windows.Forms.Button btn_Trend;
        private System.Windows.Forms.Button btn_UserManage;
        private System.Windows.Forms.Button btn_Exit;
    }
}