using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner
{
    internal struct BoxRenderInfo
    {
        public readonly Box Box;
        public readonly Rectangle RectSource;
        public readonly int OffsetX;
        public readonly int OffsetY;

        public BoxRenderInfo(Box b, Rectangle r, int offsetX, int offsetY)
        {
            Box = b;
            RectSource = r;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

        static Pen _gridPen = new Pen(Color.Black, 1.0f);

        public void Draw( Graphics g, float scaleFactor, bool showGridLines)
        {
            if (Box.Driver != null) Box.Driver.Draw(Box, g, RectSource, scaleFactor);
            if (showGridLines)
            {
                Rectangle r = new Rectangle(0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth);
                g.DrawRectangle(_gridPen, r);
            }
        }
    }
}
