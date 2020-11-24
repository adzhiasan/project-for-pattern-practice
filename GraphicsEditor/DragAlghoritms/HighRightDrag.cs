using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor.DragAlghoritms
{
    class HighRightDrag : IDragable
    {
        public void Drag(figure figure, int dx, int dy)
        {
            GraphicsEditor.figure.Move(GraphicsEditor.figure.X, GraphicsEditor.figure.Y + dy);
            GraphicsEditor.figure.Resize(GraphicsEditor.figure.width + dx, GraphicsEditor.figure.height - dy); ;
        }
    }
}
