using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ZooSample;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

namespace ZooSample.Tests
{
    [TestFixture]
    public class SampleTests
    {
        [Test]
        public void Initialize_Animals()
        {
            Zoo z = new Zoo();
            z.CreateBird( "Titi" );
            z.CreateCat( "Minnet" );

            z.Find<Cat>( "Minnet" ).Should().NotBeNull();
            z.Find<Bird>( "Titi" ).Should().NotBeNull();

        }

        [Test]

        public void Serialize_zoo_Json()
        {
            Zoo z = new Zoo();
            z.CreateBird( "Titi" );

            Bird myBird = z.Find<Bird>( "Titi" );
            myBird.Should().NotBeNull();
            var position = new Point( 0.5, 0.6 );
            myBird.MoveTo( position, 1 );
            myBird.Should().NotBeNull();
            myBird.X.Should().Be( 0.5 );

            JObject o = JObject.FromObject( z.Find<Bird>("Titi" ));
            o["type"] = typeof( Bird ).Name;

            var deserializedAnimal = z.Read( o );

            deserializedAnimal.Should().BeOfType(typeof(Bird));
          
            deserializedAnimal.Name.Should().Be( "Titi" );
            deserializedAnimal.X.Should().Be( 0.5 );
            deserializedAnimal.Y.Should().Be( 0.6 );

        }

        [Test]
        public void Serialize_zoo_XML()
        {
            Zoo z = new Zoo();          
            z.CreateCat("Minnet");

            z.Find<Cat>("Minnet").Should().NotBeNull();
            XElement e;
            Cat myCat = z.Find<Cat>("Minnet");

            var position = new Point( 0.5, 0.6 );
            myCat.MoveTo( position, 1 );
            myCat.Should().NotBeNull();
            myCat.X.Should().Be( 0.5 );

            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(Cat));
                    xmlSerializer.Serialize(streamWriter, myCat);
                    e = XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
            XAttribute attribute = new XAttribute("type", typeof(Cat).Name);
            e.Add(attribute);

            var deserializedAnimal = z.Read(e);
            deserializedAnimal.Should().BeOfType( typeof( Cat ) );
            deserializedAnimal.Name.Should().Be( "Minnet" );
            deserializedAnimal.X.Should().Be( 0.5 );
            deserializedAnimal.Y.Should().Be( 0.6 );
            deserializedAnimal.Should().BeOfType(typeof(Cat));




        }
        [Test]
        public void Serialize_zoo_Binary()
        {
            Zoo z = new Zoo();
            z.CreateBird( "Titi" );                     
            var Bird = z.Find<Bird>( "Titi" );                    
            var position = new Point( 0.5, 0.6 );
            Bird.MoveTo( position, 1 );          
            Bird.Should().NotBeNull();
            Bird.X.Should().Be( 0.5 );          
            using( var stream = new MemoryStream() )
            {
                using( var formatter = new BinaryWriter( stream ) )
                {
                    formatter.Write( Bird.Name );
                    formatter.Write( Bird.X );
                    formatter.Write( Bird.Y );
                    formatter.Write( typeof( Bird ).Name );

                    var deserializedAnimal = z.Read( stream );

                    deserializedAnimal.Should().BeOfType( typeof( Bird ) );
                    deserializedAnimal.Name.Should().Be( "Titi" );
                    deserializedAnimal.X.Should().Be( 0.5 );
                    deserializedAnimal.Y.Should().Be( 0.6 );
                }
            }
        }
    }
}
