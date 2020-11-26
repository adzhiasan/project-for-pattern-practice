using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class FigureHistory
    {
        public Stack<(Figure, FigureMemento)> History { get; private set; }
        public FigureHistory()
        {
            History = new Stack<(Figure, FigureMemento)>();
        }
    }
}
