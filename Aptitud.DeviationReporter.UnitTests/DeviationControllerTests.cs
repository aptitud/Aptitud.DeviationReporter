using System.Linq;
using Aptitud.DeviationReporter.Controllers;
using Aptitud.DeviationReporter.Repositories;
using NUnit.Framework;
using Simple.Data;
using Should.Fluent;
using Models;
using System.Collections.Generic;

namespace Aptitud.DeviationReporter.UnitTests
{
    [TestFixture]
    public class DeviationControllerTests
    {
        private static void InsertDeviationInDB(Deviation d)
        {
            _db.Deviations.Insert(d);
        }

        private DeviationController _controllerUndertest;
        private static dynamic _db;

        [SetUp]
        public void Setup()
        {
            var adapter = new InMemoryAdapter();
            Database.UseMockAdapter(adapter);
            _db = Database.Open();
            var repo = new SQLServerDeviationRepository(_db);

            _controllerUndertest = new DeviationController(repo);
        }

        [Test]
        public void GetDeviationByReporter_should_return_a_list_for_the_reporter()
        {
            // Arrange
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "1"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "1"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "2"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "2"));

            // Act
            var result = _controllerUndertest.GetDeviationByReporter(TestData.TEST_REPORTER_NAME);

            // Assert
            result.Count().Should().Equal(2);
        }

        [Test]
        public void PostDeviation_should_add_a_deviation_to_the_repository()
        {
            // Arrange

            // Act
             _controllerUndertest.PostDeviation(new[] { TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME) });

            // Assert
            Deviation deviationFromDb = _db.Deviations.FindByReporter(TestData.TEST_REPORTER_NAME);
            deviationFromDb.Should().Not.Be.Null();
            deviationFromDb.Reporter.Should().Equal(TestData.TEST_REPORTER_NAME);
        }

        [Test]
        public void GetDeviation_should_return_all_deviations()
        { 
            //Arrange
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "1"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "1"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "2"));
            InsertDeviationInDB(TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME + "2"));

            //Act
            var result = _controllerUndertest.GetDeviations();

            //Assert
            Assert.AreEqual(6, result.Count());
        }
    }
}
