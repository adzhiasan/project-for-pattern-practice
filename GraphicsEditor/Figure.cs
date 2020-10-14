using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraphicsEditor
{
    abstract class Figure
    {
        public static uint MinSize = 2;

        private int _x, _y, _width, _height;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int height
        {
            get { return _height; }
            set { _height = value; }
        }

        public Figure(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            this.width = width;
            this.height = height;
        }

        public abstract void Draw(Graphics gr, Pen p);

        public virtual void Resize(int width, int height)
        {
            //this.X = x;
            //this.Y = y;
            if (width >= MinSize)
            {
                this.width = width;
            }
            if (height >= MinSize)
            {
                this.height = height;
            }
        }

        public abstract bool Touch(int x, int y);

        public virtual void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    abstract class FigureCreator
    {
        public abstract Figure Create(int x, int y, int width, int height);
    }

}

    


