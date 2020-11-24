using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.DragAlghoritm
{
    class LowRightDrag : IDragable
    {
        public void Drag(Figure figure, int dx, int dy)
        {
            figure.Resize(figure.width + dx, figure.height + dy);
        }
    }
}
