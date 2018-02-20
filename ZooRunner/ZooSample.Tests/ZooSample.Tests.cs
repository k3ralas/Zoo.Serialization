using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ZooSample;


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
       
    }
}
