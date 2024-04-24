using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.Models
{
    public enum CircleMode
    {
        //循环一次归零
        OneAndHome,

        //循环一次停止
        OneAndStop,

        //自定义循环次数
        CustomTime
    }

    public class AutoRunMode
    {
        //循环模式
        public CircleMode CircleMode { get; set; }

        //循环次数
        public int CircleTimes { get; set; }

    }
}
