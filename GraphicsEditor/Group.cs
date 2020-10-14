using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    class Group : Figure
    {
        private Group(int x, int y, int width, int height) : base(x, y, width, height) { }

        List<Figure> figures = new List<Figure>();

        public override void Draw(Graphics gr, Pen p)
        {
            foreach (Figure figure in figures)
                figure.Draw(gr, p);
        }

        public override bool Touch(int x, int y)
        {
            foreach (Figure figure in figures)
            {
                if (figure.Touch(x, y))
                    return true;
            }
            return false;
        }

        public override void Move(int dx, int dy)
        {
            foreach (Figure figure in figures)
            {
                figure.X += dx;
                figure.Y += dy;
            }
        }

        public override void Resize(int width, int height)
        {
            int dx = this.width - width;
            int dy = this.height - height;

            double propX = width / this.width;
            double propY = height / this.height;

            foreach (Figure figure in figures)
            {
                figure.X += dx;
                figure.Y += dy;
                figure.width = (int)(figure.width * propX);
                figure.height = (int)(figure.height * propY);
            }
        }

        public void Add(Figure figure){ figures.Add(figure); }

        public void Clear(){ figures.Clear(); }

        public void Update()
        {
            foreach(Figure figure in figures)
            {
                //X = figure.X < X ? figure.X : X;
                //Y = figure.Y < Y ? figure.Y : Y;
                if (figure.X < X)
                    X = figure.X;
                if (figure.Y < Y)
                    Y = figure.Y;
                if (figure.X + figure.width - X > width)
                    width = figure.X + figure.width - X;
                if (figure.Y + figure.height - Y > height)
                    height = figure.Y + figure.height - Y;
            }
        }
    }
}
