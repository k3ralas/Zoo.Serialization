using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    public class AnimalsTypeRendering
    {
        Shape _shape;
        Color _color;

        public AnimalsTypeRendering(Shape shape, Color color)
        {
            _shape = shape;
            _color = color;
        }

        public Color ChangeColor
        {
            get { return _color; }
            set { _color = value; }
        }

        public Shape Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }
    }
}
