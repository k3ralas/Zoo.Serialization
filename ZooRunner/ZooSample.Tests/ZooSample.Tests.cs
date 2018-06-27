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
        public void Serialize_zoo()
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
            z.CreateCat( "Minnet" );

            z.Find<Cat>( "Minnet" ).Should().NotBeNull();
            z.Find<Bird>( "Titi" ).Should().NotBeNull();
       
            JObject o = JObject.FromObject( z.Find<Bird>("Titi" ));
            o["type"] = typeof( Bird ).Name;

            var deserialzation = z.Read( o );

            deserialzation.Should().BeOfType(typeof(Bird));
           
   
        
      
        }

        [Test]

        public void Serialize_zoo_XML()
        {
            Zoo z = new Zoo();          
            z.CreateCat("Minnet");

            z.Find<Cat>("Minnet").Should().NotBeNull();
            XElement e;
            Cat myCat = z.Find<Cat>("Minnet");

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

            var deserialzation = z.Read(e);

            deserialzation.Should().BeOfType(typeof(Cat));




        }
    }
}
