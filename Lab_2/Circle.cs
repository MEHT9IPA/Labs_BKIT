using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Circle: Geometric_figure, IPrint
    {

        public double radius { get; set; }
        public override double Area()
        {
            double area = Math.PI * this.radius * this.radius;
            return area;
        }
        public Circle(double Radius)
        {
            this.Type = "Круг";
            this.radius = Radius;
        }
        public Circle()
        {
            this.Type = "Круг";
        }
        public override string ToString()
        {
            return this.Type + " с радиусом " + this.radius + " имеет площадь " + this.Area().ToString() + " кв. ед.";
        }
        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
