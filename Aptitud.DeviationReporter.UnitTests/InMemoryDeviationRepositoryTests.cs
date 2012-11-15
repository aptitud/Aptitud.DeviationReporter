
using System;
using Aptitud.DeviationReporter.Repositories;
using Models;
using NUnit.Framework;
using System.Linq;
using Should.Fluent;
using Simple.Data;


namespace Aptitud.DeviationReporter.UnitTests
{
    [TestFixture]
    public class InMemoryDeviationRepositoryTests
    {
        private IDeviationRepository repo;

        [SetUp]
        public void Setup()
        {
            repo = new InMemoryDeviationRepository();
            var adapter = new InMemoryAdapter();
            Database.UseMockAdapter(adapter);
        }

        [Test]
        public void AddDeviation_should_add_a_new_deviation()
        {
            // Act
            repo.AddDeviations(new[] { TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME) });

            // Assert
            var deviationFromRepo = repo.GetDeviationByReporterName(TestData.TEST_REPORTER_NAME).SingleOrDefault();
            deviationFromRepo.Reporter.Should().Equal(TestData.TEST_REPORTER_NAME);
        }

        [Test]
        public void GetDeviationByReporterName_should_return_the_deviations_with_the_reporter_name()
        {
            // Arrange
            repo.AddDeviations(new[]
                {  
                    TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME), 
                    TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "1"),
                    TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME +"3"),
                    TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME +"2")
                });

            // Act
            var ds = repo.GetDeviationByReporterName(TestData.TEST_REPORTER_NAME);

            // Assert
            ds.Count().Should().Equal(1);
            ds.First().Reporter.Should().Equal(TestData.TEST_REPORTER_NAME);
        }
    }
}
