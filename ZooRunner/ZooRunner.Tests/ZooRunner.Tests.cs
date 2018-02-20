using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooRunner;
using FluentAssertions;

namespace ZooRunner.Tests
{
    [TestFixture]
    class RunnerTests
    {
        [Test]
        public void create_zoo_and_animal()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path); AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");

            AnimalAdapter roger = sut.AnimalTypes[0].CreateInstance("Roger");
            AnimalAdapter loic = sut.AnimalTypes[1].CreateInstance("Loïc");
            AnimalAdapter suarez = sut.AnimalTypes[1].CreateInstance("Suarez");

            bob.Name.Should().BeEquivalentTo( "Bob" );
            roger.Name.Should().BeEquivalentTo( "Roger" );
            loic.Name.Should().BeEquivalentTo( "Loïc" );
            suarez.Name.Should().BeEquivalentTo( "Suarez" );

        }

        [Test]
        public void initial_position_works()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path);

            AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");
            AnimalAdapter roger = sut.AnimalTypes[0].CreateInstance("Roger");
            AnimalAdapter loic = sut.AnimalTypes[1].CreateInstance("Loïc");
            AnimalAdapter suarez = sut.AnimalTypes[1].CreateInstance("Suarez");

            double initialPositionXY = 0;

            bob.X.Should().Be( initialPositionXY );
            roger.X.Should().Be( initialPositionXY );
            loic.X.Should().Be( initialPositionXY );
            suarez.X.Should().Be( initialPositionXY );
            bob.Y.Should().Be( initialPositionXY );
            roger.Y.Should().Be( initialPositionXY );
            loic.Y.Should().Be( initialPositionXY );
            suarez.Y.Should().Be( initialPositionXY );
        }

        [Test]
        public void meter_definition_works()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path); AnimalAdapter bob = sut.AnimalTypes[0].CreateInstance("Bob");

            double meterDefinition = 0.001;

            sut.MeterDefinition.Should().Be( meterDefinition );
        }

        [Test]
        public void map_size_works()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path);

            int mapSize = 2000000;

            sut.MapSize.Should().Be( mapSize );
        }

        [Test]
        public void with_in_meter_works()
        {
            var path = TestHelper.SolutionPath + @"\ZooSample\obj\Debug\ZooSample.dll";

            ZooAdapter sut = ZooAdapter.Load(path);

            int withInMeter = 2000;

            sut.WithInMeter.Should().Be( withInMeter );
        }
    }
}
