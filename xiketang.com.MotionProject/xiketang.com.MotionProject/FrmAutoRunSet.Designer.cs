namespace xiketang.com.MotionProject
{
    partial class FrmAutoRunSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoRunSet));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.num_CircleTimer = new System.Windows.Forms.NumericUpDown();
            this.rdo_OneAndStop = new System.Windows.Forms.RadioButton();
            this.rdo_OneAndHome = new System.Windows.Forms.RadioButton();
            this.rdo_Custom = new System.Windows.Forms.RadioButton();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_CircleTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.num_CircleTimer);
            this.groupBox1.Controls.Add(this.rdo_OneAndStop);
            this.groupBox1.Controls.Add(this.rdo_OneAndHome);
            this.groupBox1.Controls.Add(this.rdo_Custom);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(32, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(445, 203);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运行方式设置";
            // 
            // num_CircleTimer
            // 
            this.num_CircleTimer.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.num_CircleTimer.Location = new System.Drawing.Point(265, 145);
            this.num_CircleTimer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.num_CircleTimer.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_CircleTimer.Name = "num_CircleTimer";
            this.num_CircleTimer.Size = new System.Drawing.Size(82, 27);
            this.num_CircleTimer.TabIndex = 5;
            this.num_CircleTimer.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // rdo_OneAndStop
            // 
            this.rdo_OneAndStop.AutoSize = true;
            this.rdo_OneAndStop.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.rdo_OneAndStop.Location = new System.Drawing.Point(102, 96);
            this.rdo_OneAndStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_OneAndStop.Name = "rdo_OneAndStop";
            this.rdo_OneAndStop.Size = new System.Drawing.Size(117, 24);
            this.rdo_OneAndStop.TabIndex = 3;
            this.rdo_OneAndStop.Text = "循环一次停止";
            this.rdo_OneAndStop.UseVisualStyleBackColor = true;
            // 
            // rdo_OneAndHome
            // 
            this.rdo_OneAndHome.AutoSize = true;
            this.rdo_OneAndHome.Checked = true;
            this.rdo_OneAndHome.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.rdo_OneAndHome.Location = new System.Drawing.Point(102, 47);
            this.rdo_OneAndHome.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_OneAndHome.Name = "rdo_OneAndHome";
            this.rdo_OneAndHome.Size = new System.Drawing.Size(117, 24);
            this.rdo_OneAndHome.TabIndex = 3;
            this.rdo_OneAndHome.TabStop = true;
            this.rdo_OneAndHome.Text = "循环一次归零";
            this.rdo_OneAndHome.UseVisualStyleBackColor = true;
            // 
            // rdo_Custom
            // 
            this.rdo_Custom.AutoSize = true;
            this.rdo_Custom.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.rdo_Custom.Location = new System.Drawing.Point(102, 145);
            this.rdo_Custom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_Custom.Name = "rdo_Custom";
            this.rdo_Custom.Size = new System.Drawing.Size(117, 24);
            this.rdo_Custom.TabIndex = 3;
            this.rdo_Custom.Text = "循环产品数量";
            this.rdo_Custom.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Cancel.Location = new System.Drawing.Point(297, 256);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(95, 33);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Sure
            // 
            this.btn_Sure.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Sure.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Sure.Location = new System.Drawing.Point(116, 256);
            this.btn_Sure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(95, 33);
            this.btn_Sure.TabIndex = 9;
            this.btn_Sure.Text = "确认";
            this.btn_Sure.UseVisualStyleBackColor = true;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // FrmAutoRunSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 322);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "FrmAutoRunSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动运行配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_CircleTimer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown num_CircleTimer;
        private System.Windows.Forms.RadioButton rdo_OneAndHome;
        private System.Windows.Forms.RadioButton rdo_Custom;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.RadioButton rdo_OneAndStop;
    }
}