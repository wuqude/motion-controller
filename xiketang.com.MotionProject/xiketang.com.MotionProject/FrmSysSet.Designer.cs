namespace xiketang.com.MotionProject
{
    partial class FrmSysSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSysSet));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.pointCurve1 = new xiketang.com.MotionProject.PointCurve();
            this.btn_Licence = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.num_LiftZ = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.num_DownZ = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.num_outletY = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.num_outletX = new System.Windows.Forms.NumericUpDown();
            this.num_processY = new System.Windows.Forms.NumericUpDown();
            this.num_processX = new System.Windows.Forms.NumericUpDown();
            this.num_reclaimerY = new System.Windows.Forms.NumericUpDown();
            this.num_reclaimerX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_AutoLock = new XKTControl.xktToggle();
            this.num_LockPeriod = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.num_STac = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.num_Tac = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.num_MaxVel = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.num_ZAxis = new System.Windows.Forms.NumericUpDown();
            this.num_YAxis = new System.Windows.Forms.NumericUpDown();
            this.num_XAxis = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.num_MinVel = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_LiftZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DownZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_outletY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_outletX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_processY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_processX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reclaimerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reclaimerX)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_LockPeriod)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_STac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxVel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ZAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_YAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_XAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinVel)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.pointCurve1);
            this.MainPanel.Controls.Add(this.btn_Licence);
            this.MainPanel.Controls.Add(this.btn_OK);
            this.MainPanel.Controls.Add(this.groupBox3);
            this.MainPanel.Controls.Add(this.groupBox2);
            this.MainPanel.Controls.Add(this.groupBox1);
            this.MainPanel.Location = new System.Drawing.Point(55, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1154, 650);
            this.MainPanel.TabIndex = 0;
            // 
            // pointCurve1
            // 
            this.pointCurve1.LineColor = System.Drawing.Color.Black;
            this.pointCurve1.LineThickness = 1;
            this.pointCurve1.Location = new System.Drawing.Point(701, 39);
            this.pointCurve1.MaxXAxis = 70000F;
            this.pointCurve1.MaxYAxis = 70000F;
            this.pointCurve1.MaxZAxis = 70000F;
            this.pointCurve1.Name = "pointCurve1";
            this.pointCurve1.OrginGap = 20;
            this.pointCurve1.OutletColor = System.Drawing.Color.Red;
            this.pointCurve1.OutletStr = "出料口";
            this.pointCurve1.OutletXAxis = 10000;
            this.pointCurve1.OutletYAxis = 10000;
            this.pointCurve1.Pointdiameter = 5;
            this.pointCurve1.ProcessColor = System.Drawing.Color.Green;
            this.pointCurve1.ProcessStr = "加工处";
            this.pointCurve1.ProcessXAxis = 0;
            this.pointCurve1.ProcessYAxis = 0;
            this.pointCurve1.ReclaimerColor = System.Drawing.Color.Blue;
            this.pointCurve1.ReclaimerStr = "取料口";
            this.pointCurve1.ReclaimerXAxis = 0;
            this.pointCurve1.ReclaimerYAxis = 0;
            this.pointCurve1.Size = new System.Drawing.Size(425, 545);
            this.pointCurve1.TabIndex = 9;
            // 
            // btn_Licence
            // 
            this.btn_Licence.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Licence.Location = new System.Drawing.Point(457, 575);
            this.btn_Licence.Name = "btn_Licence";
            this.btn_Licence.Size = new System.Drawing.Size(126, 36);
            this.btn_Licence.TabIndex = 8;
            this.btn_Licence.Text = "授权激活";
            this.btn_Licence.UseVisualStyleBackColor = true;
            this.btn_Licence.Visible = false;
            this.btn_Licence.Click += new System.EventHandler(this.btn_Licence_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OK.Location = new System.Drawing.Point(457, 521);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(126, 36);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "保存配置";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.num_LiftZ);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.num_DownZ);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.num_outletY);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.num_outletX);
            this.groupBox3.Controls.Add(this.num_processY);
            this.groupBox3.Controls.Add(this.num_processX);
            this.groupBox3.Controls.Add(this.num_reclaimerY);
            this.groupBox3.Controls.Add(this.num_reclaimerX);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(371, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(322, 480);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自动运行轨迹";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(63, 438);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 3;
            this.label17.Text = "上升Z轴：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(63, 383);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "下降Z轴：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(63, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "出料口Y轴：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(63, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "加工位Y轴：";
            // 
            // num_LiftZ
            // 
            this.num_LiftZ.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_LiftZ.Location = new System.Drawing.Point(165, 433);
            this.num_LiftZ.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_LiftZ.Name = "num_LiftZ";
            this.num_LiftZ.Size = new System.Drawing.Size(96, 26);
            this.num_LiftZ.TabIndex = 10;
            this.num_LiftZ.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(63, 273);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "出料口X轴：";
            // 
            // num_DownZ
            // 
            this.num_DownZ.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_DownZ.Location = new System.Drawing.Point(165, 378);
            this.num_DownZ.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_DownZ.Name = "num_DownZ";
            this.num_DownZ.Size = new System.Drawing.Size(96, 26);
            this.num_DownZ.TabIndex = 10;
            this.num_DownZ.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(63, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "加工位X轴：";
            // 
            // num_outletY
            // 
            this.num_outletY.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_outletY.Location = new System.Drawing.Point(165, 323);
            this.num_outletY.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_outletY.Name = "num_outletY";
            this.num_outletY.Size = new System.Drawing.Size(96, 26);
            this.num_outletY.TabIndex = 10;
            this.num_outletY.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_outletY.ValueChanged += new System.EventHandler(this.num_outletY_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(63, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "取料口Y轴：";
            // 
            // num_outletX
            // 
            this.num_outletX.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_outletX.Location = new System.Drawing.Point(165, 268);
            this.num_outletX.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_outletX.Name = "num_outletX";
            this.num_outletX.Size = new System.Drawing.Size(96, 26);
            this.num_outletX.TabIndex = 10;
            this.num_outletX.Value = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.num_outletX.ValueChanged += new System.EventHandler(this.num_outletX_ValueChanged);
            // 
            // num_processY
            // 
            this.num_processY.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_processY.Location = new System.Drawing.Point(165, 213);
            this.num_processY.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_processY.Name = "num_processY";
            this.num_processY.Size = new System.Drawing.Size(96, 26);
            this.num_processY.TabIndex = 10;
            this.num_processY.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.num_processY.ValueChanged += new System.EventHandler(this.num_processY_ValueChanged);
            // 
            // num_processX
            // 
            this.num_processX.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_processX.Location = new System.Drawing.Point(165, 158);
            this.num_processX.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_processX.Name = "num_processX";
            this.num_processX.Size = new System.Drawing.Size(96, 26);
            this.num_processX.TabIndex = 10;
            this.num_processX.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.num_processX.ValueChanged += new System.EventHandler(this.num_processX_ValueChanged);
            // 
            // num_reclaimerY
            // 
            this.num_reclaimerY.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_reclaimerY.Location = new System.Drawing.Point(165, 103);
            this.num_reclaimerY.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_reclaimerY.Name = "num_reclaimerY";
            this.num_reclaimerY.Size = new System.Drawing.Size(96, 26);
            this.num_reclaimerY.TabIndex = 10;
            this.num_reclaimerY.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_reclaimerY.ValueChanged += new System.EventHandler(this.num_reclaimerY_ValueChanged);
            // 
            // num_reclaimerX
            // 
            this.num_reclaimerX.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_reclaimerX.Location = new System.Drawing.Point(165, 48);
            this.num_reclaimerX.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.num_reclaimerX.Name = "num_reclaimerX";
            this.num_reclaimerX.Size = new System.Drawing.Size(96, 26);
            this.num_reclaimerX.TabIndex = 10;
            this.num_reclaimerX.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.num_reclaimerX.ValueChanged += new System.EventHandler(this.num_reclaimerX_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(63, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "取料口X轴：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_AutoLock);
            this.groupBox2.Controls.Add(this.num_LockPeriod);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(17, 482);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 138);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "系统锁屏设置";
            // 
            // btn_AutoLock
            // 
            this.btn_AutoLock.Checked = false;
            this.btn_AutoLock.CircleDiameter = 10;
            this.btn_AutoLock.CirclePosition = 10;
            this.btn_AutoLock.ClickEnable = true;
            this.btn_AutoLock.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.btn_AutoLock.FalseText = "";
            this.btn_AutoLock.Location = new System.Drawing.Point(164, 35);
            this.btn_AutoLock.Name = "btn_AutoLock";
            this.btn_AutoLock.Size = new System.Drawing.Size(83, 32);
            this.btn_AutoLock.SliderColor = System.Drawing.Color.White;
            this.btn_AutoLock.Switchtype = XKTControl.xktToggle.SwitchType.Rectangle;
            this.btn_AutoLock.TabIndex = 10;
            this.btn_AutoLock.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.btn_AutoLock.TrueText = "";
            // 
            // num_LockPeriod
            // 
            this.num_LockPeriod.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_LockPeriod.Location = new System.Drawing.Point(160, 89);
            this.num_LockPeriod.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.num_LockPeriod.Name = "num_LockPeriod";
            this.num_LockPeriod.Size = new System.Drawing.Size(96, 26);
            this.num_LockPeriod.TabIndex = 9;
            this.num_LockPeriod.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(59, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "锁屏间隔：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(59, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "自动锁屏：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.num_STac);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.num_Tac);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.num_MaxVel);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.num_ZAxis);
            this.groupBox1.Controls.Add(this.num_YAxis);
            this.groupBox1.Controls.Add(this.num_XAxis);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.num_MinVel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(17, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 439);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动运动参数";
            // 
            // num_STac
            // 
            this.num_STac.DecimalPlaces = 2;
            this.num_STac.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_STac.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_STac.Location = new System.Drawing.Point(161, 219);
            this.num_STac.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_STac.Name = "num_STac";
            this.num_STac.Size = new System.Drawing.Size(96, 26);
            this.num_STac.TabIndex = 7;
            this.num_STac.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(67, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "S段时间：";
            // 
            // num_Tac
            // 
            this.num_Tac.DecimalPlaces = 2;
            this.num_Tac.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Tac.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.num_Tac.Location = new System.Drawing.Point(161, 162);
            this.num_Tac.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Tac.Name = "num_Tac";
            this.num_Tac.Size = new System.Drawing.Size(96, 26);
            this.num_Tac.TabIndex = 8;
            this.num_Tac.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(59, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "加速时间：";
            // 
            // num_MaxVel
            // 
            this.num_MaxVel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_MaxVel.Location = new System.Drawing.Point(161, 105);
            this.num_MaxVel.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.num_MaxVel.Name = "num_MaxVel";
            this.num_MaxVel.Size = new System.Drawing.Size(96, 26);
            this.num_MaxVel.TabIndex = 9;
            this.num_MaxVel.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(59, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "运行速度：";
            // 
            // num_ZAxis
            // 
            this.num_ZAxis.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_ZAxis.Location = new System.Drawing.Point(161, 390);
            this.num_ZAxis.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.num_ZAxis.Name = "num_ZAxis";
            this.num_ZAxis.Size = new System.Drawing.Size(96, 26);
            this.num_ZAxis.TabIndex = 10;
            this.num_ZAxis.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // num_YAxis
            // 
            this.num_YAxis.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_YAxis.Location = new System.Drawing.Point(161, 333);
            this.num_YAxis.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.num_YAxis.Name = "num_YAxis";
            this.num_YAxis.Size = new System.Drawing.Size(96, 26);
            this.num_YAxis.TabIndex = 10;
            this.num_YAxis.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // num_XAxis
            // 
            this.num_XAxis.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_XAxis.Location = new System.Drawing.Point(161, 276);
            this.num_XAxis.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.num_XAxis.Name = "num_XAxis";
            this.num_XAxis.Size = new System.Drawing.Size(96, 26);
            this.num_XAxis.TabIndex = 10;
            this.num_XAxis.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(35, 395);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 16);
            this.label16.TabIndex = 6;
            this.label16.Text = "Z轴原限距离：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(35, 338);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(112, 16);
            this.label15.TabIndex = 6;
            this.label15.Text = "Y轴原限距离：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(35, 281);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "X轴原限距离：";
            // 
            // num_MinVel
            // 
            this.num_MinVel.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_MinVel.Location = new System.Drawing.Point(161, 48);
            this.num_MinVel.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_MinVel.Name = "num_MinVel";
            this.num_MinVel.Size = new System.Drawing.Size(96, 26);
            this.num_MinVel.TabIndex = 10;
            this.num_MinVel.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(59, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "初始速度：";
            // 
            // FrmSysSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 650);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSysSet";
            this.Text = "系统设置";
            this.Resize += new System.EventHandler(this.FrmSysSet_Resize);
            this.MainPanel.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_LiftZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DownZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_outletY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_outletX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_processY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_processX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reclaimerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_reclaimerX)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_LockPeriod)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_STac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Tac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MaxVel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_ZAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_YAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_XAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MinVel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button btn_Licence;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_LiftZ;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown num_DownZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_outletY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_outletX;
        private System.Windows.Forms.NumericUpDown num_processY;
        private System.Windows.Forms.NumericUpDown num_processX;
        private System.Windows.Forms.NumericUpDown num_reclaimerY;
        private System.Windows.Forms.NumericUpDown num_reclaimerX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private XKTControl.xktToggle btn_AutoLock;
        private System.Windows.Forms.NumericUpDown num_LockPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown num_STac;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown num_Tac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_MaxVel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown num_ZAxis;
        private System.Windows.Forms.NumericUpDown num_YAxis;
        private System.Windows.Forms.NumericUpDown num_XAxis;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown num_MinVel;
        private System.Windows.Forms.Label label4;
        private PointCurve pointCurve1;
    }
}