using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Figure.MinSize = 10;
        }

        enum FigureType
        {
            rectangle, ellipse
        }

        Figure f;
        Point point;
        bool isDown;
        Group group;
        Pen blackPen = new Pen(Brushes.Black);
        List<Figure> figures = new List<Figure>();
        List<FigureCreator> tools;
        FigureCreator currentTool;
        Manipulator manipulator;
        FigureHistory history;

        private void Form1_Load(object sender, EventArgs e)
        {
            Rectangle.RectCreator rectCreator = new Rectangle.RectCreator();
            Ellipse.EllipseCreator ellipseCreator = new Ellipse.EllipseCreator();
            tools = new List<FigureCreator>() {
            null, rectCreator, ellipseCreator};
            manipulator = new Manipulator(0, 0, 0, 0);
            group = new Group(0, 0, 0, 0);
            history = new FigureHistory();
        }

        private void cursorTool_Click(object sender, EventArgs e) { currentTool = tools[0]; }
        private void rectangleTool_Click(object sender, EventArgs e) { currentTool = tools[1]; }
        private void ellipseTool_Click(object sender, EventArgs e) { currentTool = tools[2]; }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            point = e.Location;

            if (currentTool != null)
            {
                group.Clear();
                manipulator.Clear();
                f = currentTool.Create(point.X, point.Y, 0, 0);
                history.History.Push((f, f.SaveState()));
            }

            else
            {
                f = null;
                if (manipulator.Touch(e.X, e.Y)) return;
                foreach (Figure figure in figures)
                {
                    if (figure.Touch(e.X, e.Y))
                    {
                        f = figure;
                        point = e.Location;

                        history.History.Push((f, f.SaveState()));

                        break;
                    }
                }

                if (Control.ModifierKeys == Keys.Control)
                {
                    group.Add(f);
                    group.Update();
                    manipulator.Attach(group);
                }
                else
                {
                    group.Clear();
                    manipulator.Attach(f);
                }

                manipulator.Touch(e.X, e.Y);
                manipulator.Update();
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown)
            {
                if (currentTool != null)
                {
                    f.width = e.X - point.X;
                    f.height = e.Y - point.Y;                    
                    canvas.Refresh();
                }

                if (currentTool == null)
                {

                    int dx = e.X - point.X;
                    int dy = e.Y - point.Y;

                    canvas.Refresh();

                    point = e.Location;

                    if (manipulator.IsAttached) 
                    {
                        manipulator.Drag(dx, dy);
                        manipulator.Update();
                    }                  
                }
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            if (f != null)
            {
                figures.Add(f);
                canvas.Refresh();
            }
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Figure figure in figures)
            {
                if (figure.Touch(e.X, e.Y))
                {
                    label1.Text = "попал";
                    return;
                }
                else
                    label1.Text = "НЕпопал";
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in figures)
                figure.Draw(e.Graphics, blackPen);
            if (f != null)
                f.Draw(e.Graphics, blackPen);
            if (manipulator.IsAttached) 
            {
                manipulator.Draw(e.Graphics, Pens.Red);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (history.History.Count > 0)
            {
                manipulator.Clear();
                (Figure, FigureMemento) top = history.History.Pop();
                f = top.Item1;
                f.RestoreState(top.Item2);
                if (f.width == 0)
                {
                    foreach (Figure item in figures)
                    {
                        if (item == f)
                        {
                            figures.Remove(item);
                            break;
                        }
                    }
                    
                }
                //manipulator.Update();
                canvas.Refresh();
            }
        }
    }
}
