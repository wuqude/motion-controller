using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xiketang.com.Models
{
    public class ConfigInfoExt : ConfigInfo
    {

        //当前处于原点，目标距离的X轴位移
        public int OrginX
        {
            get { return this.ReclaimerXAxis; }
        }

        //当前处于原点，目标距离的Y轴位移
        public int OrginY
        {
            get { return this.ReclaimerYAxis; }
        }

        //当前处于取料点，目标距离的X轴位移
        public int ReclaimerX
        {
            get { return this.ProcessXAxis-this.ReclaimerXAxis; }
        }

        //当前处于取料点，目标距离的Y轴位移
        public int ReclaimerY
        {
            get { return this.ProcessYAxis - this.ReclaimerYAxis; }
        }

        //当前处于加工处，目标距离的X轴位移
        public int ProcessX
        {
            get { return this.OutletXAxis - this.ProcessXAxis; }
        }

        //当前处于加工处，目标距离的Y轴位移
        public int ProcessY
        {
            get { return this.OutletYAxis - this.ProcessYAxis; }
        }


        //当前处于取料口，目标距离的X轴位移
        public int OutletX
        {
            get { return this.ReclaimerXAxis - this.OutletXAxis; }
        }

        //当前处于取料口，目标距离的Y轴位移
        public int OutletY
        {
            get { return this.ReclaimerYAxis - this.OutletYAxis; }
        }

    }
}
