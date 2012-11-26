using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using System;


namespace Aptitud.DeviationReporter.UnitTests
{
    public static class TestData
    {
        public const string TEST_REPORTER_NAME = "Marcus";

        public static Deviation BuildTestDeviation(string reporterName)
        {
            return new Deviation
            {
                Id = 1,
                Reporter = reporterName,
                DeviationType = "Type1",
                ReportDate = DateTime.Now,
                Duration = TimeSpan.FromDays(1.0)
            };
        }

    }
}
