using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Square: Rectangle, IPrint
    {
        public Square(double side)
            : base(side, side)
        {
            this.Type = "Квадрат";
        }
        public Square()
            : base()
        {
            this.Type = "Квадрат";
        }
        public override string ToString()
        {
            return this.Type + " со стороной " + this.height + " имеет площадь " + this.Area().ToString() + " кв. ед.";
        }
    }
}
