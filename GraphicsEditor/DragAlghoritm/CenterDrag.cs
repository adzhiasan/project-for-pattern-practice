using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.DragAlghoritm
{
    class CenterDrag : IDragable
    {
        public void Drag(Figure figure, int dx, int dy)
        {
            figure.Move(figure.X + dx, figure.Y + dy);
        }
    }
}
