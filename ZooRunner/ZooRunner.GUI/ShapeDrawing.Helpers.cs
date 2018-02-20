using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    public static class ShapeDrawingHelpers
    {
        public static void DrawTriangle(Graphics g, Pen pen, int x, int y, int size)
        {
            Point one = new Point(x, y);
            Point two = new Point(x + size, y);
            Point tree = new Point(x + size / 2, y + size);

            Point[] trianglePoints =
            {
                            one,
                            two,
                            tree
                        };

            g.DrawPolygon(pen, trianglePoints);
        }

        public static void DrawRhombus(Graphics g, Pen pen, int x, int y, int size)
        {
            Point one = new Point(x + size / 2, y);
            Point two = new Point(x + size, y + size / 2);
            Point tree = new Point(x + size / 2, y + size);
            Point four = new Point(x, y + size / 2);

            Point[] rhombusPoints =
            {
                            one,
                            two,
                            tree,
                            four
                        };

            g.DrawPolygon(pen, rhombusPoints);
        }

        public static void DrawStar(Graphics g, Pen pen, int x, int y, int size)
        {
            Point one = new Point(x + size / 2, y);
            Point two = new Point(x + size / 3 * 2, y + size / 4);
            Point tree = new Point(x + size, y + size / 4);
            Point four = new Point(x + size / 6 * 5, y + size / 2);
            Point five = new Point(x + size, y + size / 4 * 3);
            Point six = new Point(x + size / 3 * 2, y + size / 4 * 3);
            Point seven = new Point(x + size / 2, y + size);
            Point eight = new Point(x + size / 3, y + size / 4 * 3);
            Point nine = new Point(x, y + size / 4 * 3);
            Point ten = new Point(x + size / 6, y + size / 2);
            Point eleven = new Point(x, y + size / 4);
            Point twelve = new Point(x + size / 3, y + size / 4);

            Point[] starPoints =
            {
                            one,
                            two,
                            tree,
                            four,
                            five,
                            six,
                            seven,
                            eight,
                            nine,
                            ten,
                            eleven,
                            twelve
                        };

            g.DrawPolygon(pen, starPoints);
        }
    }
}
