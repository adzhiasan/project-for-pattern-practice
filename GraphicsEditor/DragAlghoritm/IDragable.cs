using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.DragAlghoritm
{
    interface IDragable
    {
        void Drag(Figure figure, int dx, int dy);
    }
}
