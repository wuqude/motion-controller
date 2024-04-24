namespace WindowsFormsApp1
{
    partial class FormNav
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
            this.button_Monitor = new System.Windows.Forms.Button();
            this.button_SysSet = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Monitor
            // 
            this.button_Monitor.Location = new System.Drawing.Point(38, 21);
            this.button_Monitor.Name = "button_Monitor";
            this.button_Monitor.Size = new System.Drawing.Size(116, 55);
            this.button_Monitor.TabIndex = 0;
            this.button_Monitor.Text = "集中监控";
            this.button_Monitor.UseVisualStyleBackColor = true;
            this.button_Monitor.Click += new System.EventHandler(this.button_Monitor_Click);
            // 
            // button_SysSet
            // 
            this.button_SysSet.Location = new System.Drawing.Point(38, 126);
            this.button_SysSet.Name = "button_SysSet";
            this.button_SysSet.Size = new System.Drawing.Size(116, 55);
            this.button_SysSet.TabIndex = 1;
            this.button_SysSet.Text = "系统设置";
            this.button_SysSet.UseVisualStyleBackColor = true;
            this.button_SysSet.Click += new System.EventHandler(this.button_SysSet_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(38, 219);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 55);
            this.button3.TabIndex = 2;
            this.button3.Text = "系统日志";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(38, 297);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 55);
            this.button4.TabIndex = 3;
            this.button4.Text = "数据统计";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(38, 376);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 55);
            this.button5.TabIndex = 4;
            this.button5.Text = "数据记录";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(38, 458);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(116, 55);
            this.button6.TabIndex = 5;
            this.button6.Text = "用户管理";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(38, 533);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(116, 55);
            this.button7.TabIndex = 6;
            this.button7.Text = "注销系统";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // FormNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 600);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button_SysSet);
            this.Controls.Add(this.button_Monitor);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FormNav";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "FormNav";
            this.Load += new System.EventHandler(this.FormNav_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Monitor;
        private System.Windows.Forms.Button button_SysSet;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}