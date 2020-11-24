using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    interface IDragable
    {
        void Drag(figure figure, int dx, int dy);
    }
}
