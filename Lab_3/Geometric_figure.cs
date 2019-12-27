using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public abstract class Geometric_figure : IComparable
    {
        public string Type { get; protected set; }
        public abstract double Area();

        public int CompareTo(object obj)
        {
            Geometric_figure p = (Geometric_figure)obj;
            if (this.Area() < p.Area())
            {
                return -1;
            }
            else if (this.Area() == p.Area())
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
