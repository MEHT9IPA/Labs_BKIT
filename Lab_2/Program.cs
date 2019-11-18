using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Аникин Филипп, ИУ5-33Б";
            Console.ForegroundColor = ConsoleColor.Green;

            Rectangle R = new Rectangle();
            R.width = 5;
            R.height = 8;
            R.Print();

            Square S = new Square(10);
            S.Print();

            Circle C = new Circle(3);
            C.radius = 5;
            C.Print();

            Console.ResetColor();
            Console.Write("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
