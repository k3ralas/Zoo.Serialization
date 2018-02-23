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
         

            var deserialzation = z.Read( o );


            var allAnimals = z.SelectAll<List<KeyValuePair<string, Animal>>>();

           var output = Newtonsoft.Json.JsonConvert.SerializeObject( allAnimals );
        //JArray array  = JArray.Parse( output );
            
        //        JObject o1 = JObject.Parse( array[1].ToString() );
        //    //o1["Animals"] = JObject.FromObject( allAnimals );


   
        }
        [Test]
        public void PetConverter()
        {
            Zoo z = new Zoo();
            z.CreateBird( "Titi" );
           

            var json = JsonConvert.SerializeObject( z.Find<Bird>( "Titi" ) );

            var converter = new Zoo.PetConverter();
            var deserializedArray = JsonConvert.DeserializeObject<Animal>(
                json,
                converter );

            

            //for( var i = 0; i < originalArray.Length; i++ )
            //{
            //    var original = originalArray[i];
            //    var deserialized = deserializedArray[i];

            //    Assert.Equal( original.GetType(), deserialized.GetType() );
            //    Assert.Equal( original.Name, deserialized.Name );
            //}
        }
    }
}
