using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class Rectangle : Figure
    {
        Rectangle(int x, int y, int width, int height) : base(x, y, width, height) { }

        public override void Draw(Graphics gr, Pen p) { gr.DrawRectangle(p, X, Y, width, height); }

        public override bool Touch(int x, int y)
        {
            if (x >= this.X && x <= this.X + width
                && y >= this.Y && y <= this.Y + height)
                return true;
            return false;
        }
        public class RectCreator : FigureCreator
        {
            public override Figure Create(int x, int y, int width, int height)
            {
                Figure rect = new Rectangle(x, y, width, height);
                return rect;
            }
        }
    }
}
