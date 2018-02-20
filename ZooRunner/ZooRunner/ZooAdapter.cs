using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ZooRunner
{
    public class ZooAdapter
    {
        readonly object _zoo;
        readonly Type _zooType;
        readonly List<AnimalType> _animalTypes;
        readonly Action _update;
        readonly Func<double, double, Color> _colorAt;
        readonly double _meterDefinition;
        readonly int _widthInMeter;
        readonly int _mapSize;

        ZooAdapter( object zoo, Type zooType )
        {
            Debug.Assert( zoo != null );
            _zoo = zoo;
            _zooType = zooType;
            _animalTypes = CreateAnimalTypes( zoo, zooType );
            _update = BuildUpdate( zooType, zoo );
            CollectColorAtMethod = TryBuildColorAt( zooType, zoo, out _colorAt );
            _meterDefinition = RetrieveMeterDefinition( _zoo );
            _widthInMeter = ( int )( 1 / _meterDefinition ) * 2;
            _mapSize = _widthInMeter * 1000;
        }

        static bool TryBuildColorAt( Type zooType, object zoo, out Func<double, double, Color> colorAt )
        {
            colorAt = null;
            MethodInfo colorAtInfo = zooType.GetMethod("ColorAt");
            if( colorAtInfo == null ) return false;

            var xParam = Expression.Parameter( typeof( double ), "x" );
            var yParam = Expression.Parameter( typeof( double ), "y" );
            colorAt = Expression.Lambda<Func<double, double, Color>>(
                Expression.Call(
                    Expression.Constant( zoo ),
                    colorAtInfo,
                    xParam,
                    yParam ),
                xParam,
                yParam ).Compile();

            return true;
        }

        static Action BuildUpdate( Type zooType, object zoo )
        {
            MethodInfo updateInfo = zooType.GetMethod( "Update" );
            if( updateInfo == null ) return () => { };
            return Expression.Lambda<Action>( Expression.Call( Expression.Constant( zoo ), updateInfo ) ).Compile();
        }

        public static ZooAdapter Load( string fileName )
        {
            Assembly a = Assembly.LoadFile( fileName );
            var zooType = a.GetExportedTypes().Where( t => t.Name == "Zoo" ).Single();
            object zoo = Activator.CreateInstance( zooType );
            return new ZooAdapter( zoo, zooType );
        }

        static List<AnimalType> CreateAnimalTypes( object zoo, Type zooType )
        {
            List<AnimalType> result = new List<AnimalType>();
            var allMethods = zooType.GetMethods( BindingFlags.Instance | BindingFlags.Public );
            var createMethods = allMethods.Where( m => m.Name.StartsWith( "Create" )
                                                        && m.ReturnType != typeof( void ) );
            foreach( var m in createMethods )
            {
                var parameters = m.GetParameters();
                if( parameters.Length == 1 && parameters[ 0 ].ParameterType == typeof( string ) )
                {
                    Type animalType = m.ReturnType;
                    MethodInfo factoryMethod = m;
                    MethodInfo getName = animalType.GetProperty( "Name" ).GetGetMethod();
                    MethodInfo getX = animalType.GetProperty( "X" ).GetGetMethod();
                    MethodInfo getY = animalType.GetProperty( "Y" ).GetGetMethod();
                    MethodInfo isAlive = animalType.GetProperty( "IsAlive" ).GetGetMethod();
                    result.Add( new AnimalType( zoo, animalType, factoryMethod, getName, getX, getY, isAlive ) );
                }
            }
            return result;
        }

        public IReadOnlyList<AnimalType> AnimalTypes => _animalTypes;

        public void Update() => _update.Invoke();

        public Color ColorAt( double x, double y ) => _colorAt( x, y );

        private double RetrieveMeterDefinition( object zoo )
        {
            double meterDefinition;

            try
            {
                meterDefinition = ( double )_zooType.GetProperty( "MeterDefinition" )?.GetGetMethod()?.Invoke( zoo, null );
                if( meterDefinition == 0.0 ) meterDefinition = 0.01;
                else if( meterDefinition > 1.0 ) meterDefinition = 1.0;
                else if( meterDefinition < 4e-5 ) meterDefinition = 4e-5;
            }
            catch
            {
                meterDefinition = 0.01;
            }

            return meterDefinition;
        }

        public int WithInMeter => _widthInMeter;

        public int MapSize => _mapSize;

        public double MeterDefinition => _meterDefinition;

        public bool CollectColorAtMethod { get; }
    }
}
