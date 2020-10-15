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
        public Group(int x, int y, int width, int height) : base(x, y, width, height) { }

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
                if (figure == null) return false;

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

        public void Clear(){ 
            figures.Clear();
            X = 0;
            Y = 0;
            width = 0;
            height = 0;
        }

        public void Update()
        {
            X = figures.Min(f => f.X);
            Y = figures.Min(f => f.Y);

            width = figures.Max(f => f.X + f.width) - X;
            height = figures.Max(f => f.Y + f.height) - Y;

            //foreach (Figure figure in figures)
            //{

            //    if (figure.Y + figure.height > footer)
            //        footer = figure.Y + figure.height;

            //    if (figure == null) return;
            //        //X = figure.X < X ? figure.X : X;
            //        //Y = figure.Y < Y ? figure.Y : Y;
            //    if (figure.X < X)
            //        X = figure.X;
            //    if (figure.Y < Y)
            //        Y = figure.Y;
            //    //height = figure.Y + figure.height - Y;
            //    if (figure.X + figure.width > width)
            //        width = figure.X + figure.width - X;
            //    if (figure.Y + figure.height - Y > height)
            //        height = footer - Y;
            //}
        }
    }
}
