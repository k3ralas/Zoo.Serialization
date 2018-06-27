using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooSample
{
    public class Zoo
    {
        readonly Dictionary<string, Animal> _animals;
        readonly List<Animal> _animalsThatWillDie;
        readonly Random _random;

        public Zoo()
            : this( new Random() )
        {
        }

        public Zoo( int randomSeed )
            : this( new Random( randomSeed ) )
        {
        }

        Zoo( Random random )
        {
            _random = random;
            _animals = new Dictionary<string, Animal>();
            _animalsThatWillDie = new List<Animal>();
        }

        internal bool Probability( double p )
        {
            return _random.NextDouble() < p;
        }

        internal Random Randomizer => _random;

        public Cat CreateCat( string name )
        {
            Cat cat = new Cat( this, name );
            _animals[name] = cat;
            return cat;
        }

        internal bool Rename( Animal a, string newName )
        {
            if( _animals.ContainsKey( newName ) ) return false;
            _animals.Remove( a.Name );
            _animals.Add( newName, a );
            return true;
        }

        public Bird CreateBird( string name )
        {
            Bird bird = new Bird( this, name );
            _animals[name] = bird;
            return bird;
        }

        public T Find<T>( string name ) where T : Animal
        {
            Animal b;
            _animals.TryGetValue( name, out b );
            return b as T;
        }

        public void Die( Animal a )
        {
            _animalsThatWillDie.Add( a );
        }

        public void Update()
        {
            foreach( Animal a in _animals.Values ) a.Update();

            foreach( Animal a in _animalsThatWillDie )
            {
                _animals.Remove( a.Name );
            }
        }

        public double MeterDefinition => 0.001;

        public Color ColorAt( double x, double y )
        {
            var sinX = Math.Sin( x ) + 1.0;
            var sinY = Math.Sin( y ) + 1.0;
            var sinXY = Math.Sin( x * y ) + 1.0;
            return Color.FromArgb( (int)(sinX * 255) % 256, (int)(sinY * 200) % 256, (int)(sinXY * 250) % 256 );
        }

        public Animal Read( BinaryReader r )
        {
            throw new NotImplementedException();
        }

        public Animal Read( XElement e )
        {
            
            var type = (string)e.Attribute("type");
            var methodName = $"Create{type}";
            var name = e.Element("Name").Value;

            var method = typeof(Zoo).GetMethod(methodName);

            Animal a = (Animal)method.Invoke(this, new object[] { name });
            Type t = Type.GetType(typeof(Animal).Namespace + "." + type);

            t.GetMethod(nameof(Cat.MoveTo)).Invoke(a, new object[] { new Point((double)e.Element("X"), (double)e.Element("Y")), 1 });
            return a;
        }


        public Animal Read( JObject o )
        {
            var type = (string)o["type"];
            var methodName = $"Create{type}";
            var name = (string)o["Name"];

            var method = typeof( Zoo ).GetMethod( methodName );

            Animal a = (Animal)method.Invoke( this, new object[] { name } );
            Type t = Type.GetType( typeof( Animal ).Namespace + "." + type );

            t.GetMethod( nameof( Bird.MoveTo ) ).Invoke( a, new object[] { new Point( (double)o["X"], (double)o["Y"] ), 1 } );
            return a;
        }
    }
        
    }


