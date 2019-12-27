using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class FigureMatrixCheckEmpty : IMatrixCheckEmpty<Geometric_figure>
    {
        public Geometric_figure getEmptyElement()
        {
            return null;
        }
        public bool checkEmptyElement(Geometric_figure element)
        {
            bool Result = false;
            if (element == null)
            {
                Result = true;
            }
            return Result;
        }
    }
}
