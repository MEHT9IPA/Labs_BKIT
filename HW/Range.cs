using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class Range
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Range(int s, int e)
        {
            this.Start = s;
            this.End = e;
        }
    }
}
