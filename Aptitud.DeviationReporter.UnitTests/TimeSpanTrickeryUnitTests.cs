using System;
using Models;
using NUnit.Framework;
using Should.Fluent;

namespace Aptitud.DeviationReporter.UnitTests
{
    [TestFixture]
    public class TimeSpanTrickeryUnitTests
    {
        [Test]
        public void Duration_should_set_DurationTicks()
        {
            var d = new Deviation { Duration = TimeSpan.FromTicks(100) };

            d.DurationTicks.Should().Equal((Int64)100);
        }

        [Test]
        public void setting_DurationTicks_should_read_same_from_Duration()
        {
            var ts =  TimeSpan.FromTicks(100);
            var d = new Deviation { DurationTicks = 100 };

            d.Duration.Should().Equal(ts);
        }
    }
}
