using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Rectangle: Geometric_figure, IPrint
    {
        public double height { get; set; }
        public double width { get; set; }
        public override double Area()
        {
            double area = this.height * this.width;
            return area;
        }
        public Rectangle(double Height, double Width)
        {
            this.Type = "Прямоугольник";
            this.height = Height;
            this.width = Width;
        }
        public Rectangle()
        {
            this.Type = "Прямоугольник";
        }
        public override string ToString()
        {
            return this.Type + " со сторонами " + this.width + " и " + this.height + " имеет площадь " + this.Area().ToString() + " кв. ед.";
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
