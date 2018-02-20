using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooRunner;

namespace ZooRunner
{
    public interface IBoxDriver
    {
        void Draw(Box box ,Graphics g, Rectangle rectSource, float scaleFactor);

        void AddAnimal(AnimalAdapter animal);

        void ClearAnimals();

        object CastAnimalsRedering { set; } // <= circular dependency

        Bitmap BackGround { get; }
    }
}
