using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner.GUI
{
    public class AnimalsRedering
    {
        readonly Dictionary<string, AnimalsTypeRendering> _animalsRedering;

        public AnimalsRedering()
        {
            _animalsRedering = new Dictionary<string, AnimalsTypeRendering>();
        }

        public void Add(string typeName, Shape shape, Color color)
        {
            if(!_animalsRedering.ContainsKey(typeName))
            {
                AnimalsTypeRendering newtype = new AnimalsTypeRendering(shape, color);
                _animalsRedering.Add(typeName, newtype); 
            }
            else
            {
                _animalsRedering[typeName].ChangeColor = color;
                _animalsRedering[typeName].Shape = shape;
            }
        }
        public Dictionary<string, AnimalsTypeRendering> AnimalsRepresentation => _animalsRedering;
    }
}
