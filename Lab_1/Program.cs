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
        static void Args_incorrect()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Некорректный ввод аргументов консоли, повторите попытку");
            Console.ResetColor();
            Console.Write("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
            Environment.Exit(0);
        }

            static void Main(string[] args)
        {
            Console.Title = "Аникин Филипп, ИУ5-33Б";
            double A = 0, B = 0, C = 0, discr;

            if (args.Length == 0)
            {
                Console.WriteLine("Введите коэффициенты биквадратного уравнения");
                Console.Write("A = ");
                Input(ref A);
                Console.Write("B = ");
                Input(ref B);
                Console.Write("C = ");
                Input(ref C);
                Console.WriteLine("===================");
            }
            else if (args.Length == 3)
            {
                if (!double.TryParse(args[0], out A))
                {
                    Args_incorrect();
                }
                if (!double.TryParse(args[1], out B))
                {
                    Args_incorrect();
                }
                if (!double.TryParse(args[2], out C))
                {
                    Args_incorrect();
                }
            }
            else
            {
                Args_incorrect();
            }

            
            Console.WriteLine($"A={A}; B={B}; C={C}");
            Console.Write("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
