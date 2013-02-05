using Aptitud.DeviationReporter.Controllers;
using Aptitud.DeviationReporter.Models;
using Aptitud.DeviationReporter.Repositories;
using Models;
using NUnit.Framework;
using Should.Fluent;
using Simple.Data;
using System;
using System.Linq;

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

        [Test]
        public void GetDefaultsForDeviationType_VAB_should_return_defaults_for_VAB()
        {
            //Arrange
            var expected = DeviationTypeDefaults.Factory.CreateDefault("vab");

            //Act
            var actual = _controllerUndertest.GetDefaultsForDeviationType("vab");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDefaultsForDeviationType_SJUK_should_return_defaults_for_SJUK()
        {
            //Arrange
            var expected = DeviationTypeDefaults.Factory.CreateDefault("sjuk");

            //Act
            var actual = _controllerUndertest.GetDefaultsForDeviationType("sjuk");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDefaultsForDeviationType_SEMESTER_should_return_defaults_for_SEMESTER()
        {
            //Arrange
            var expected = DeviationTypeDefaults.Factory.CreateDefault("semester");

            //Act
            var actual = _controllerUndertest.GetDefaultsForDeviationType("semester");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDefaultsForDeviationType_FLEX_should_return_defaults_for_FLEX()
        {
            //Arrange
            var expected = DeviationTypeDefaults.Factory.CreateDefault("flex");

            //Act
            var actual = _controllerUndertest.GetDefaultsForDeviationType("flex");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCurrentDeviationsByReporter()
        {
            // Arrange
            // Add some deviations for reporter
            InsertDeviationInDB(TestData.BuildTestDeviation(
                        TestData.TEST_REPORTER_NAME, 
                        DateTime.Now.AddMonths(-1)));
            var d = TestData.BuildTestDeviation(TestData.TEST_REPORTER_NAME);
            InsertDeviationInDB(d);
            InsertDeviationInDB(TestData.BuildTestDeviation(
                        TestData.TEST_REPORTER_NAME,
                        DateTime.Now.AddMonths(1)));

            // Get Current Deviations
            var deviationsFromDB = _controllerUndertest
                    .GetCurrentMonthDeviationsByReporter(TestData.TEST_REPORTER_NAME);
        
            // Assert
            deviationsFromDB.Count().Should().Equal(1);
            deviationsFromDB.Single().ReportDate.Month.Should()
                .Equal(DateTime.Now.Month);
        }
    }
}
