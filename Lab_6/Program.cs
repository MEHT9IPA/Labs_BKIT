using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Lab_6
{
    delegate string AddM(char ch, int i);
    class Program
    {
        static string Add(char ch, int i) { return ch + i.ToString(); }
        static string Mult(char ch, int i) { string str = ""; for (int k = 0; k < i; k++) { str += ch; } return str; }
        static void task4(char ch, int i, AddM addm)
        {
            Console.WriteLine(addm(ch, i));
        }
        static void task5(char ch, int i, Func<char, int, string> addm)
        {
            string str = addm(ch, i);
            Console.WriteLine(str);
        }
        static void DelegatExample()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Выполнение части с делегатами");
            Console.ResetColor();
            task4('a', 5, Add);
            task4('a', 5, Mult);

            AddM task4b = (char ch, int i) =>
            {
                string str = ch + "->" + (char)(ch + i);
                return str;
            };

            task4('b', 5, task4b);

            Console.WriteLine("Использование обощенного делегата Func<>");
            task5('c', 7, Mult);


        }
        static void AssemblyInfo()
        {
            Console.WriteLine("Вывод информации о сборке:");
            Assembly i = Assembly.GetExecutingAssembly();
            Console.WriteLine("Полное имя:" + i.FullName);
            Console.WriteLine("Исполняемый файл:" + i.Location);
        }
        static void TypeInfo()
        {
            Figure obj = new Figure();
            Type t = obj.GetType();


            Console.WriteLine("\nИнформация о типе:");
            Console.WriteLine("Тип " + t.FullName + " унаследован от " + t.BaseType.FullName);
            Console.WriteLine("Пространство имен " + t.Namespace);
            Console.WriteLine("Находится в сборке " + t.AssemblyQualifiedName);

            Console.WriteLine("\nКонструкторы:");
            foreach (var x in t.GetConstructors())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nМетоды:");
            foreach (var x in t.GetMethods())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nСвойства:");
            foreach (var x in t.GetProperties())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nПоля данных (public):");
            foreach (var x in t.GetFields())
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\nForInspection реализует IComparable -> " +
            t.GetInterfaces().Contains(typeof(IComparable))
            );
        }
        static void InvokeMemberInfo()
        {
            Type t = typeof(Figure);
            Console.WriteLine("\nВызов метода:");
            Figure fi = (Figure)t.InvokeMember(null, BindingFlags.CreateInstance, null, null, new object[] { });

            object[] parameters = new object[] { 10, 20 };
            object Result = t.InvokeMember("Add", BindingFlags.InvokeMethod, null, fi, parameters);
            Console.WriteLine("Add(10,20)={0}", Result);
        }
        static void ReflectionExample()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\nРефлексия\n");
            Console.ResetColor();
            AssemblyInfo();
            TypeInfo();
            InvokeMemberInfo();
            AttributeInfo();

        }
        public static bool GetPropertyAttribute(PropertyInfo checkType, Type attributeType, out object attribute)
        {
            bool Result = false;
            attribute = null;

            var isAttribute = checkType.GetCustomAttributes(attributeType, false);
            if (isAttribute.Length > 0)
            {
                Result = true;
                attribute = isAttribute[0];
            }

            return Result;
        }
        static void AttributeInfo()
        {
            Type t = typeof(Figure);
            Console.WriteLine("\nОтмеченниые свойства:");
            foreach (var x in t.GetProperties())
            {
                object attrObj;
                if (GetPropertyAttribute(x, typeof(MyAtr), out attrObj))
                {
                    MyAtr attr = attrObj as MyAtr;
                    Console.WriteLine(x.Name + " - " + attr.Description);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Аникин Филипп, ИУ5-33Б";
            DelegatExample();
            ReflectionExample();
            Console.Write("\nНажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
