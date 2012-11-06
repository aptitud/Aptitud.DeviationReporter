
using System;
using Aptitud.DeviationReporter.Repositories;
using Models;
using NUnit.Framework;
using System.Linq;
using Should.Fluent;

namespace Aptitud.DeviationReporter.UnitTests
{
    [TestFixture]
    public class InMemoryDeviationRepositoryTests
    {
        const string TEST_REPORTER_NAME = "Marcus";
        private IDeviationRepository repo;
        
        [SetUp]
        public void Setup()
        {
            repo = new InMemoryDeviationRepository();
        }

        private Deviation CreateTestDeviation(string reporterName)
        {
            return new Deviation
            {
                Reporter = reporterName
            };
        }

        [Test]
        public void AddDeviation_should_add_a_new_deviation()
        {
            // Act
            repo.AddDeviations(new[] { CreateTestDeviation(TEST_REPORTER_NAME) });

            // Assert
            var deviationFromRepo = repo.GetDeviationByReporterName(TEST_REPORTER_NAME).SingleOrDefault();
            deviationFromRepo.Reporter.Should().Equal(TEST_REPORTER_NAME);
        }

        [Test]
        public void GetDeviationByReporterName_should_return_the_deviations_with_the_reporter_name()
        {
            // Arrange
            repo.AddDeviations(new[]
                {  
                    CreateTestDeviation(TEST_REPORTER_NAME), 
                    CreateTestDeviation(TEST_REPORTER_NAME + "1"),
                    CreateTestDeviation(TEST_REPORTER_NAME +"3"),
                    CreateTestDeviation(TEST_REPORTER_NAME +"2")
                });

            // Act
            var ds = repo.GetDeviationByReporterName(TEST_REPORTER_NAME);

            // Assert
            ds.Count().Should().Equal(1);
            ds.First().Reporter.Should().Equal(TEST_REPORTER_NAME);


        }
    }
}
