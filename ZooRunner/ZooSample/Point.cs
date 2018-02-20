using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSample
{
    public struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets whether this position lies outside any zoo.
        /// </summary>
        public bool IsOutsideZoo => X < -1.0 || X > 1.0 || Y < -1.0 || Y > 1.0;
    }
}
