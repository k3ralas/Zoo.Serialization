using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner
{
    public class Box
    {
        readonly Map _map;
        readonly int _line;
        readonly int _column;

        public Box(Map map, int line, int column)
        {
            _map = map;
            _line = line;
            _column = column;
        }

        public Rectangle Area
        {
            get
            {
                int sz = _map.BoxWidth;
                return new Rectangle(_column * sz, _line * sz, sz, sz);
            }
        }

        public IBoxDriver Driver { get; set; }

        public Map Map => _map;

        public int Line => _line;

        public int Column => _column;

    }
}
