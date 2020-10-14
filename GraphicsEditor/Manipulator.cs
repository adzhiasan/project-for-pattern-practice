using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEditor
{
    class Manipulator : Figure
    {
        enum Corner
        {
            HighLeft = 1,
            HighRight,
            LowRight,
            LowLeft,
            Center,
            None
        }
        private Corner corner;

        public Manipulator(int x, int y, int width, int height) : base(x, y, width, height) { }

        public Figure Figure { get; private set; }

        public bool IsAttached
        {
            get
            {
                return Figure != null;
            }
        }

        public override void Draw(Graphics gr, Pen p)
        {
            gr.DrawRectangle(p, X, Y, width, height);
            gr.DrawRectangle(p, X, Y, 5, 5);
            gr.DrawRectangle(p, X + width - 5, Y + height - 5, 5, 5);
            gr.DrawRectangle(p, X + width - 5, Y, 5, 5);
            gr.DrawRectangle(p, X, Y + height - 5, 5, 5);
        }

        public override bool Touch(int x, int y)
        {
            corner = Corner.None;

            if (x >= X && x <= X + 5)
            {
                if (y >= Y && y <= Y + 5)
                    corner = Corner.HighLeft;
                if (y >= Y + height - 5 && y <= Y + height)
                    corner = Corner.LowLeft;
            }

            else if (x >= X + width - 5 && x <= X + width)
            {
                if (y >= Y && y <= Y + 5)
                    corner = Corner.HighRight;
                if (y >= Y + height - 5 && y <= Y + height)
                    corner = Corner.LowRight;
            }

            else if (IsAttached && Figure.Touch(x, y))
            {
                corner = Corner.Center;
            }

            return corner != Corner.None;

        }

        public void Attach(Figure figure) { Figure = figure; }

        public void Clear() { Figure = null; }

        public void Update()
        {
            if (Figure == null) return;
            this.X = Figure.X;
            this.Y = Figure.Y;
            this.width = Figure.width;
            this.height = Figure.height;
        }

        public void Drag(int dx, int dy)
        {
            switch (corner)
            {
                case Corner.HighLeft:
                    Figure.Move(Figure.X + dx, Figure.Y + dy);
                    Figure.Resize(Figure.width - dx, Figure.height - dy);
                    break;
                case Corner.HighRight:
                    Figure.Move(Figure.X, Figure.Y + dy);
                    Figure.Resize(Figure.width + dx, Figure.height - dy);
                    break;
                case Corner.LowRight:
                    Figure.Resize(Figure.width + dx, Figure.height + dy);
                    break;
                case Corner.LowLeft:
                    Figure.Move(Figure.X + dx, Figure.Y);
                    Figure.Resize(Figure.width - dx, Figure.height + dy);
                    break;
                case Corner.Center:
                    Figure.Move(Figure.X + dx, Figure.Y + dy);
                    break;
                default:
                    break;
            }
        }
    }
}
