using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.Models
{
  public   class ConfigInfo
    {
        //初始速度
        public double VelMin { get; set; }

        //运行速度
        public double  VelMax { get; set; }

        //加速时间
        public double Tac { get; set; }

        //S段时间
        public double  STac { get; set; }

        //X轴归零位置
        public int XAxisPosition { get; set; }

        //Y轴归零位置
        public int YAxisPosition { get; set; }

        //Z轴归零位置
        public int ZAxisPosition { get; set; }

        //取料口X轴
        public int ReclaimerXAxis { get; set; }

        //取料口Y轴
        public int ReclaimerYAxis { get; set; }

        //加工位X轴
        public int ProcessXAxis { get; set; }

        //加工位Y轴
        public int ProcessYAxis { get; set; }

        //出料口X轴
        public int OutletXAxis { get; set; }

        //出料口Y轴
        public int OutletYAxis { get; set; }

        //Z轴下降
        public int DownZAxis { get; set; }

        //Z轴上升
        public int LiftZAxis { get; set; }

        //自动锁屏
        public bool AutoLock { get; set; }

        //锁屏间隔
        public int LockPeriod { get; set; }

    }
}
