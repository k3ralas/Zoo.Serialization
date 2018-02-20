using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZooRunner
{
    public class AnimalType
    {
        readonly Type _animalType;
        readonly object _zoo;
        readonly Func<object, string> _getName;
        readonly Func<object, double> _getPositionX;
        readonly Func<object, double> _getPositionY;
        readonly Func<object, bool> _isAlive;
        readonly Func<string, object> _create;

        public AnimalType(
            object zoo,
            Type animalType,
            MethodInfo factoryMethod,
            MethodInfo getNameMethod,
            MethodInfo getPositionXMethod,
            MethodInfo getPositionYMethod,
            MethodInfo getIsAliveMethod )
        {
            _zoo = zoo;
            _animalType = animalType;
            _create = BuildCreate( zoo, factoryMethod, animalType );
            _getName = BuildAnimalGetter<string>( getNameMethod, animalType );
            _getPositionX = BuildAnimalGetter<double>( getPositionXMethod, animalType );
            _getPositionY = BuildAnimalGetter<double>( getPositionYMethod, animalType );
            _isAlive = BuildAnimalGetter<bool>( getIsAliveMethod, animalType );
        }

        static Func<string, object> BuildCreate( object zoo, MethodInfo factoryMethod, Type animalType )
        {
            var name = Expression.Parameter( typeof( string ) );
            return Expression.Lambda<Func<string, object>>(
               Expression.Call(
                   Expression.Constant( zoo ),
                   factoryMethod,
                   name ),
               name ).Compile();
        }

        static Func<object, T> BuildAnimalGetter<T>( MethodInfo getMethod, Type animalType )
        {
            var animal = Expression.Parameter( typeof( object ) );
            return Expression.Lambda<Func<object, T>>(
                Expression.Call(
                    Expression.Convert( animal, animalType ),
                    getMethod ),
                animal ).Compile();
        }

        internal string GetNameFor( object animal )
        {
            return _getName( animal );
        }

        internal double GetPositionXFor( object animal )
        {
            return _getPositionX( animal );
        }

        internal double GetPositionYFor( object animal )
        {
            return _getPositionY( animal );
        }

        public string Name => _animalType.Name;

        public AnimalAdapter CreateInstance( string name )
        {
            return new AnimalAdapter( _create( name ), this );
        }

        public Type Type => _animalType;

        internal bool GetIsAliveFor( object animal )
        {
            return _isAlive( animal );
        }
    }
}
