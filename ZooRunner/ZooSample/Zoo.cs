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
            _animals[ name ] = cat;
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
            _animals[ name ] = bird;
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
            return Color.FromArgb( (int)(sinX*255) % 256, (int)(sinY*200) % 256, (int)(sinXY * 250) % 256 );
        }

        public Animal Read( BinaryReader r )
        {
            throw new NotImplementedException();
        }

        public Animal Read( XElement e )
        {
            throw new NotImplementedException();
        }
        public T SelectAll<T>(  ) where T : List<KeyValuePair<string, Animal>>
        {
            var list = new List<KeyValuePair<string, Animal>>();
           
            var a = _animals.ToList();
            foreach(var z in a )
            {
                list.Add( z );
            }
            return list as T;
        }
        public Animal Read( JObject o )
        {

            string typeName = (o["Type"]).ToString();
            switch( typeName )
            {
                case "Bird":
                    
                   
                   Bird b2 =  o.ToObject<Bird>();
                    return b2;
                case "Cat":
                    return new Cat( this, o["Name"].ToString() );
                default:
                    return null;
            }

            var a = (Bird)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance("Bird" );
            var arr = new object[] { this, "tott" };
            Animal b = (Animal)Activator.CreateInstance(typeof(Bird), arr);
            
            //_animals[obj.Name] = obj;



            List<string> keys = o.Properties().Select( p => p.Name ).ToList();
            List<JToken> values = new List<JToken>();

            var props = typeof( Animal ).GetProperties();
            
            foreach( string k in keys )
            {
               
              props.Where( p => p.Name == k ).FirstOrDefault().SetValue(b, o.GetValue(k));
                

                //var value = o.GetValue( k );
                //values.Add( value );
            }
            
            return null;
        }
        public abstract class AbstractJsonConverter<T> : JsonConverter
        {
            protected abstract T Create( Type objectType, JObject jObject );

            public override bool CanConvert( Type objectType )
            {
                return typeof( T ).IsAssignableFrom( objectType );
            }

            public override object ReadJson(
                JsonReader reader,
                Type objectType,
                object existingValue,
                JsonSerializer serializer )
            {
                var jObject = JObject.Load( reader );

                T target = Create( objectType, jObject );
                serializer.Populate( jObject.CreateReader(), target );

                return target;
            }

            public override void WriteJson(
                JsonWriter writer,
                object value,
                JsonSerializer serializer )
            {
                throw new NotImplementedException();
            }

            protected static string TypeOfAnimal(JObject jObject, string name)
            {          
                return jObject.GetValue( name ).ToString();
            }
        }

        public class PetConverter : AbstractJsonConverter<Animal>
        {
            protected override Animal Create( Type objectType, JObject jObject )
            {
                if( TypeOfAnimal( jObject, "Type" ) == "Bird")
                    return null;
                if( TypeOfAnimal( jObject, "Type" ) == "Cat" )
                    return null;

                throw new InvalidOperationException();
            }
        }
    }


}
