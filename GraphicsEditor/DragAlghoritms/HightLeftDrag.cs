using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.DragAlghoritms
{
    class HightLeftDrag : IDragable
    {
        public void Drag(figure figure, int dx, int dy)
        {
            figure.Move(figure.X + dx, figure.Y + dy);
            figure.Resize(figure.width - dx, figure.height - dy);
        }
    }
}
