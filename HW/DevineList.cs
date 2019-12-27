using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class DevineList
    {
        public static List<Range> DivideSubArrays(int beginIndex, int endIndex, int subArraysCount)
        {
            List<Range> result = new List<Range>();

            if ((endIndex - beginIndex) <= subArraysCount)
            {
                result.Add(new Range(0, (endIndex - beginIndex)));
            }
            else
            {
                int delta = (endIndex - beginIndex) / subArraysCount;
                int currentBegin = beginIndex;
                while ((endIndex - currentBegin) >= 2 * delta)
                {
                    result.Add(new Range(currentBegin, currentBegin + delta));
                    currentBegin += delta;
                }
                result.Add(new Range(currentBegin, endIndex));
            }
            return result;
        }
    }
}
