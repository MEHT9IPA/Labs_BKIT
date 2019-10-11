using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        static void Input(ref double coeff)
        {
            string input = Console.ReadLine();
            while (!double.TryParse(input, out coeff))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Некорректный ввод коэффициента, повторите попытку: ");
                Console.ResetColor();
                input = Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Аникин Филипп, ИУ5-33Б";

            double A=0, B=0, C=0, discr;
            Console.WriteLine("Введите коэффициенты биквадратного уравнения");
            Console.Write("A = ");
            Input(ref A);
            Console.Write("B = ");
            Input(ref B);
            Console.Write("C = ");
            Input(ref C);

            Console.ReadKey();
        }
    }
}
