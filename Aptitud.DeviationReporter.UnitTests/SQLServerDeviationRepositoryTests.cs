using System;
using System.Collections.Generic;
using Aptitud.DeviationReporter.Repositories;
using NUnit.Framework;
using Simple.Data;
using Should.Fluent;
using Models;
using System.Linq;

namespace Aptitud.DeviationReporter.UnitTests
{
    [TestFixture]
    public class SQLServerDeviationRepositoryTests
    {
        private IDeviationRepository repo;

        private static int NumberOfDeviationsInDB()
        {
            var db = Database.Open();
            int numberOfDeviations = db.Deviations.GetCount();
            return numberOfDeviations;
        }

        private static void InsertDeviationInDB(Deviation d)
        {
            var db = Database.Open();
            db.Deviations.Insert(d);
        }

        [SetUp]
        public void Setup()
        {
            var adapter = new InMemoryAdapter();
            Database.UseMockAdapter(adapter);
            repo = new SQLServerDeviationRepository(Database.Open());
        }

        [Test]
        public void AddDeviation_should_add_a_new_deviation_in_the_database()
        {
            // Act
            repo.AddDeviations(new[] { TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME) });

            // Assert
            NumberOfDeviationsInDB().Should().Equal(1);
        }

        [Test]
        public void GetDeviationByReporterName_should_return_only_the_reports_with_the_reportername_from_the_db()
        {
            // Arrange
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "1"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "1"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "2"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "2"));

            // Act
            var deviations = repo.GetDeviationByReporterName(TestData.TEST_REPORTER_NAME);

            // Arrange
            deviations.Count().Should().Equal(2);
            
        }
    }
}
