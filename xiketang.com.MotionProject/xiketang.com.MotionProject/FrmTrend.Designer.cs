namespace xiketang.com.MotionProject
{
    partial class FrmTrend

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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rdo_Month = new System.Windows.Forms.RadioButton();
            this.rdo_Quarter = new System.Windows.Forms.RadioButton();
            this.rdo_year = new System.Windows.Forms.RadioButton();
            this.cmb_Quarter = new System.Windows.Forms.ComboBox();
            this.cmb_Month = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_Year = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Query = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.splitContainer1);
            this.MainPanel.Location = new System.Drawing.Point(55, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1154, 650);
            this.MainPanel.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rdo_Month);
            this.splitContainer1.Panel1.Controls.Add(this.rdo_Quarter);
            this.splitContainer1.Panel1.Controls.Add(this.rdo_year);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_Quarter);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_Month);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.cmb_Year);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Export);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Query);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.zedGraphControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1154, 650);
            this.splitContainer1.SplitterDistance = 54;
            this.splitContainer1.TabIndex = 0;
            // 
            // rdo_Month
            // 
            this.rdo_Month.AutoSize = true;
            this.rdo_Month.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_Month.Location = new System.Drawing.Point(295, 15);
            this.rdo_Month.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdo_Month.Name = "rdo_Month";
            this.rdo_Month.Size = new System.Drawing.Size(97, 23);
            this.rdo_Month.TabIndex = 20;
            this.rdo_Month.TabStop = true;
            this.rdo_Month.Text = "月度统计表";
            this.rdo_Month.UseVisualStyleBackColor = true;
            this.rdo_Month.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdo_Quarter
            // 
            this.rdo_Quarter.AutoSize = true;
            this.rdo_Quarter.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_Quarter.Location = new System.Drawing.Point(162, 15);
            this.rdo_Quarter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdo_Quarter.Name = "rdo_Quarter";
            this.rdo_Quarter.Size = new System.Drawing.Size(97, 23);
            this.rdo_Quarter.TabIndex = 21;
            this.rdo_Quarter.TabStop = true;
            this.rdo_Quarter.Text = "季度统计表";
            this.rdo_Quarter.UseVisualStyleBackColor = true;
            this.rdo_Quarter.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdo_year
            // 
            this.rdo_year.AutoSize = true;
            this.rdo_year.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_year.Location = new System.Drawing.Point(29, 16);
            this.rdo_year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdo_year.Name = "rdo_year";
            this.rdo_year.Size = new System.Drawing.Size(97, 23);
            this.rdo_year.TabIndex = 22;
            this.rdo_year.TabStop = true;
            this.rdo_year.Text = "年度统计表";
            this.rdo_year.UseVisualStyleBackColor = true;
            this.rdo_year.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // cmb_Quarter
            // 
            this.cmb_Quarter.FormattingEnabled = true;
            this.cmb_Quarter.Location = new System.Drawing.Point(664, 16);
            this.cmb_Quarter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Quarter.Name = "cmb_Quarter";
            this.cmb_Quarter.Size = new System.Drawing.Size(54, 22);
            this.cmb_Quarter.TabIndex = 17;
            // 
            // cmb_Month
            // 
            this.cmb_Month.FormattingEnabled = true;
            this.cmb_Month.Location = new System.Drawing.Point(801, 16);
            this.cmb_Month.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Month.Name = "cmb_Month";
            this.cmb_Month.Size = new System.Drawing.Size(54, 22);
            this.cmb_Month.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(604, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "季度：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(751, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "月份：";
            // 
            // cmb_Year
            // 
            this.cmb_Year.FormattingEnabled = true;
            this.cmb_Year.Location = new System.Drawing.Point(507, 16);
            this.cmb_Year.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Year.Name = "cmb_Year";
            this.cmb_Year.Size = new System.Drawing.Size(74, 22);
            this.cmb_Year.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(457, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "年份：";
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.Location = new System.Drawing.Point(1036, 12);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(80, 30);
            this.btn_Export.TabIndex = 12;
            this.btn_Export.Text = "导出";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Query.Location = new System.Drawing.Point(935, 12);
            this.btn_Query.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(80, 30);
            this.btn_Query.TabIndex = 13;
            this.btn_Query.Text = "查询";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1154, 592);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // FrmTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 650);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTrend";
            this.Text = "数据记录";
            this.Resize += new System.EventHandler(this.FrmReport_Resize);
            this.MainPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rdo_Month;
        private System.Windows.Forms.RadioButton rdo_Quarter;
        private System.Windows.Forms.RadioButton rdo_year;
        private System.Windows.Forms.ComboBox cmb_Quarter;
        private System.Windows.Forms.ComboBox cmb_Month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_Year;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Query;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}