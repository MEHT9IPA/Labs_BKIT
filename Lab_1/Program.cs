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
        static void No_solutions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Действительных корней нет");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            Console.Title = "Аникин Филипп, ИУ5-33Б";
            Console.SetWindowSize(100, Console.WindowHeight);
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

            if (A != 0)
            {
                discr = B * B - 4 * A * C;
                Console.WriteLine($"D={discr}");
                if (discr >= 0)
                {
                    B = -B;
                    A = A+A;
                    discr = Math.Sqrt(discr);
                    double Q1 = (B + discr)/A;
                    double Q2 = (B - discr)/A;
                    discr = -1;

                    if (Q1 >= 0)
                    {
                        discr = 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Q1 = Math.Sqrt(Q1);
                        Console.Write($"X{discr++}={Q1}; X{discr++}={-Q1}");
                        Console.ResetColor();
                    }
                    if (Q2 >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Q2 = Math.Sqrt(Q2);
                        if (discr != -1)
                        {
                            Console.Write("; ");
                        }
                        else
                        {
                            discr = 1;
                        }
                        Console.Write($"X{discr++}={Q2}; X{discr}={-Q2}");
                        Console.ResetColor();
                    }


                    if (discr == -1)
                    {
                        No_solutions();
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
                else
                {
                    No_solutions();
                }
            }
            else
            {
                if (B != 0)
                {
                    double Q = -C / B;
                    if (Q >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Q = Math.Sqrt(Q);
                        Console.WriteLine($"X1={-Q}; X2={Q}");
                        Console.ResetColor();
                    }
                    else
                    {
                        No_solutions();
                    }
                }
                else
                {
                    if (C != 0)
                    {
                        No_solutions();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Решение — любое число");
                        Console.ResetColor();
                    }
                }
            }
            Console.Write("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
