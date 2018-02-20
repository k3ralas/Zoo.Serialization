using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner
{
    public class AnimalAdapter
    {
        readonly object _animal;
        readonly AnimalType _type;

        public AnimalAdapter( object animal, AnimalType type )
        {
            _animal = animal;
            _type = type;
        }

        public string Name => _type.GetNameFor( _animal );

        public double X => _type.GetPositionXFor( _animal );

        public double Y => _type.GetPositionYFor( _animal );

        public string TypeName => _type.Name;

        public AnimalType AnimalType => _type;

        public bool IsAlive => _type.GetIsAliveFor( _animal );
    }
}
