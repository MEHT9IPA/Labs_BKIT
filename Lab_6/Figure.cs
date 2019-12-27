using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Figure : IComparable
    {
        public Figure() { }
        public Figure(int i) { }
        public Figure(string str) { }

        public int Add(int x, int y) { return x + y; }
        public int DeAdd(int x, int y) { return x - y; }

        [MyAtr("Описание для 1 атрибута")]
        public string myProp1
        {
            get { return _myProp1; }
            set { _myProp1 = value; }
        }
        private string _myProp1;

        public int myProp2 { get; set; }
        [MyAtr(Description = "Описание для 3 атрибута")]
        public double myProp3 { get; private set; }
        public int var1;
        public float var2;

        public int CompareTo(object obj)
        {
            return 0;
        }
    }
}
