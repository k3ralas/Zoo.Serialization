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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ZooSample.Tests
{
    [Serializable]
    [TestFixture]
    public class SampleTests
    {

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
                    deserializedAnimal.Y.Should().Be( 0.6);
                }
            }
        }

        [Test]
        public void Serialize_zoo_Json()
        {
            Zoo z = new Zoo();
            z.CreateBird( "Titi" );
            z.CreateCat( "Minnet" );

            z.Find<Cat>( "Minnet" ).Should().NotBeNull();
            var Bird = z.Find<Bird>( "Titi" );

            Bird.Should().NotBeNull();

            var position = new Point( 0.5, 0.6 );
            Bird.MoveTo( position, 1.0 );

            Bird.X.Should().Be( 0.5 );
            JObject o = JObject.FromObject( z.Find<Bird>( "Titi" ) );
            o["type"] = typeof( Bird ).Name;

            var deserialzation = z.Read( o );

            deserialzation.Should().BeOfType( typeof( Bird ) );
            deserialzation.Name.Should().Be( "Titi" );
            deserialzation.X.Should().Be( 0.5 );
        }

        [Test]
        public void Serialize_zoo_Xml()
        {
            Zoo z = new Zoo();
            z.CreateBird( "Titi" );
            z.CreateCat( "Minnet" );

            z.Find<Cat>( "Minnet" ).Should().NotBeNull();
            z.Find<Bird>( "Titi" ).Should().NotBeNull();

            JObject o = JObject.FromObject( z.Find<Bird>( "Titi" ) );
            o["type"] = typeof( Bird ).Name;

            var deserialzation = z.Read( o );

            deserialzation.Should().BeOfType( typeof( Bird ) );
            deserialzation.Name.Should().Be( "Titi" );
        }
    }
}
