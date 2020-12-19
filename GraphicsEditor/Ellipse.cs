using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
class Ellipse : Figure
    {
        private Ellipse(int x, int y, int width, int height) : base(x, y, width, height) { }

        public override void Draw(Graphics gr, Pen p) { gr.DrawEllipse(p, X, Y, width, height); }

        public override bool Touch(int x, int y)
        {
            int x0 = x - width / 2 - X;
            int y0 = y - height / 2 - Y;
            int halfWidth = width / 2;
            int halfHeight = height / 2;
            double affiliation = (Math.Pow(x0, 2)/Math.Pow(halfWidth, 2)) + (Math.Pow(y0, 2) / Math.Pow(halfHeight, 2));
            if (affiliation <= 1)
                return true;
            return false;
        }

        public override Figure Clone()
        {
            return new Ellipse(X, Y, width, height);
        }
        public class EllipseCreator : FigureCreator
        {
            public override Figure Create(int x, int y, int width, int height)
            {
                Figure ellipse = new Ellipse(x, y, width, height);
                return ellipse;
            }
        }
    }
}
