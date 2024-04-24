using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace xiketang.com.MotionProject
{
    public partial class PointCurve : UserControl
    {
        public PointCurve()
        {
            InitializeComponent();

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        #region 绘制对象的创建

        //画布
        private Graphics g;

        //画笔
        private Pen p;

        #endregion

        #region 控件属性

        private int orginGap = 20;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("原点坐标")]
        public int OrginGap
        {
            get { return orginGap; }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                orginGap = value;
                this.Invalidate();
            }
        }

        private float maxXAxis = 100000.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("X轴最大坐标值")]
        public float MaxXAxis
        {
            get { return maxXAxis; }
            set
            {
                maxXAxis = value;
                this.Invalidate();
            }
        }

        private float maxYAxis = 100000.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("Y轴最大坐标值")]
        public float MaxYAxis
        {
            get { return maxYAxis; }
            set
            {
                maxYAxis = value;
                this.Invalidate();
            }
        }

        private float maxZAxis = 70000.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("Z轴最大坐标值")]
        public float MaxZAxis
        {
            get { return maxYAxis; }
            set { maxYAxis = value; }
        }


        private int reclaimerXAxis = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("取料口X轴坐标")]
        public int ReclaimerXAxis
        {
            get { return reclaimerXAxis; }
            set
            {
                reclaimerXAxis = value;
                this.Invalidate();
            }
        }


        private int reclaimerYAxis = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("取料口Y轴坐标")]
        public int ReclaimerYAxis
        {
            get { return reclaimerYAxis; }
            set
            {
                reclaimerYAxis = value;
                this.Invalidate();
            }
        }

        private int processXAxis = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("加工处X轴坐标")]
        public int ProcessXAxis
        {
            get { return processXAxis; }
            set
            {
                processXAxis = value;
                this.Invalidate();
            }
        }


        private int processYAxis = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("加工处Y轴坐标")]
        public int ProcessYAxis
        {
            get { return processYAxis; }
            set
            {
                processYAxis = value;
                this.Invalidate();
            }
        }


        private int outletXAxis = 0;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("出料口X轴坐标")]
        public int OutletXAxis
        {
            get { return outletXAxis; }
            set
            {
                outletXAxis = value;
                this.Invalidate();
            }
        }

        private int outletYAxis = 0;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("出料口Y轴坐标")]
        public int OutletYAxis
        {
            get { return outletYAxis; }
            set
            {
                outletYAxis = value;
                this.Invalidate();
            }
        }


        private Color reclaimerColor = Color.Blue;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("取料口点颜色")]
        public Color ReclaimerColor
        {
            get { return reclaimerColor; }
            set
            {
                reclaimerColor = value;
                this.Invalidate();
            }
        }


        private Color processColor = Color.Green;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("加工处点颜色")]
        public Color ProcessColor
        {
            get { return processColor; }
            set
            {
                processColor = value;
                this.Invalidate();
            }
        }


        private Color outletColor = Color.Red;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("出料口点颜色")]
        public Color OutletColor
        {
            get { return outletColor; }
            set
            {
                outletColor = value;
                this.Invalidate();
            }
        }

        private string reclaimerStr = "取料口";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("取料口字符串")]
        public string ReclaimerStr
        {
            get { return reclaimerStr; }
            set
            {
                reclaimerStr = value;
                this.Invalidate();
            }
        }


        private string processStr = "加工处";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("加工处字符串")]
        public string ProcessStr
        {
            get { return processStr; }
            set
            {
                processStr = value;
                this.Invalidate();
            }
        }


        private string outletStr = "出料口";

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("出料口字符串")]
        public string OutletStr
        {
            get { return outletStr; }
            set
            {
                outletStr = value;
                this.Invalidate();
            }
        }

        private int pointdiameter = 5;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("绘制点直径")]
        public int Pointdiameter
        {
            get { return pointdiameter; }
            set
            {
                pointdiameter = value;
                this.Invalidate();
            }
        }

        private Color lineColor = Color.Black;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("绘制曲线颜色")]
        public Color LineColor
        {
            get { return lineColor; }
            set
            {
                lineColor = value;
                this.Invalidate();
            }
        }

        private int lineThickness = 1;

        [Browsable(true)]
        [Category("自定义属性")]
        [Description("绘制曲线宽度")]
        public int LineThickness
        {
            get { return lineThickness; }
            set
            {
                lineThickness = value;
                this.Invalidate();
            }
        }


        private List<PointF> pointList = new List<PointF>();

        public void AddSinglePoint(PointF point)
        {
            pointList.Add(point);
            this.Invalidate();
        }

        public void AddMultiPoints(List<PointF> list)
        {
            AddMultiPoints(list.ToArray());
            this.Invalidate();
        }

        public void AddMultiPoints(PointF[] list)
        {
            pointList.AddRange(list);
            this.Invalidate();
        }

        public void ClearAllPoints()
        {
            pointList = new List<PointF>();
            this.Invalidate();
        }

        #endregion


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //绘制过程

            //获取画布
            g = e.Graphics;

            //设置画布
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            //正式绘制

            //设置画笔
            p = new Pen(Color.Black, 1.5f);

            p.CustomEndCap = new AdjustableArrowCap(p.Width * 3, p.Width * 4, true);

            //绘制X轴

            g.DrawLine(p, new Point(orginGap, this.Height - orginGap), new Point(this.Width - orginGap, this.Height - orginGap));


            //绘制Y轴

            g.DrawLine(p, new Point(orginGap, this.Height - orginGap), new Point(orginGap, orginGap));


            //绘制原点

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString("0", this.Font, new SolidBrush(Color.Black), new Rectangle(0, this.Height - orginGap, orginGap, orginGap), sf);


            //绘制X轴最大
            g.DrawString(maxXAxis.ToString(), this.Font, new SolidBrush(Color.Black), new Rectangle(this.Width - 50, this.Height - (orginGap - 5), 50, orginGap - 5), sf);

            //绘制Y轴最大
            g.DrawString(maxYAxis.ToString(), this.Font, new SolidBrush(Color.Black), new Rectangle(0, 0, 50, orginGap), sf);

            //绘制取料点

            float reclaimerX = (this.Width - 2 * orginGap) / maxXAxis * reclaimerXAxis + orginGap;

            float reclaimerY = this.Height - ((this.Height - 2 * orginGap) / maxYAxis * reclaimerYAxis + orginGap);

            g.FillEllipse(new SolidBrush(reclaimerColor), new RectangleF(reclaimerX - 0.5f * pointdiameter, reclaimerY - 0.5f * pointdiameter, pointdiameter, pointdiameter));

            g.DrawString(reclaimerStr, this.Font, new SolidBrush(reclaimerColor), new RectangleF(reclaimerX - 25.0f, reclaimerY - 20.0f, 50.0f, 20.0f), sf);

            //绘制加工点

            float processX = (this.Width - 2 * orginGap) / maxXAxis * processXAxis + orginGap;

            float processY = this.Height - ((this.Height - 2 * orginGap) / maxYAxis * processYAxis + orginGap);

            g.FillEllipse(new SolidBrush(processColor), new RectangleF(processX - 0.5f * pointdiameter, processY - 0.5f * pointdiameter, pointdiameter, pointdiameter));

            g.DrawString(processStr, this.Font, new SolidBrush(processColor), new RectangleF(processX - 25.0f, processY - 20.0f, 50.0f, 20.0f), sf);

            //绘制出料点

            float outletX = (this.Width - 2 * orginGap) / maxXAxis * outletXAxis + orginGap;

            float outletY = this.Height - ((this.Height - 2 * orginGap) / maxYAxis * outletYAxis + orginGap);

            g.FillEllipse(new SolidBrush(outletColor), new RectangleF(outletX - 0.5f * pointdiameter, outletY - 0.5f * pointdiameter, pointdiameter, pointdiameter));

            g.DrawString(outletStr, this.Font, new SolidBrush(outletColor), new RectangleF(outletX - 25.0f, outletY - 20.0f, 50.0f, 20.0f), sf);


            //绘制所有点
            if (this.pointList.Count > 1)
            {
                PointF[] points = new PointF[pointList.Count];
                for (int i = 0; i < pointList.Count; i++)
                {
                    points[i].X = pointList[i].X * (this.Width - 2 * orginGap) / maxXAxis + orginGap;

                    points[i].Y = this.Height - (pointList[i].Y * (this.Height - 2 * orginGap) / maxYAxis + orginGap);
                }

                using (Pen p = new Pen(lineColor, lineThickness))
                {
                    g.DrawLines(p, points);
                }
            }
        }
    }
}
