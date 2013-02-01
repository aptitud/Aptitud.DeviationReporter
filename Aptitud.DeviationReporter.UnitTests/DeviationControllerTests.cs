using Aptitud.DeviationReporter.Controllers;
using Aptitud.DeviationReporter.Repositories;
using Models;
using NUnit.Framework;
using Should.Fluent;
using Simple.Data;
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
        public void GetDefaultHoursForDeviationType_VAB_should_return_8()
        {
            //Act
            var result = _controllerUndertest.GetDefaultHoursForDeviationType("VAB");

            //Assert
            Assert.AreEqual(8.0, result);
        }

        [Test]
        public void GetDefaultHoursForDeviationType_SJUK_should_return_8()
        {
            //Act
            var result = _controllerUndertest.GetDefaultHoursForDeviationType("SJUK");

            //Assert
            Assert.AreEqual(8.0, result);
        }

        [Test]
        public void GetDefaultHoursForDeviationType_SEMESTER_should_return_8()
        {
            //Act
            var result = _controllerUndertest.GetDefaultHoursForDeviationType("SEMESTER");

            //Assert
            Assert.AreEqual(8.0, result);
        }

        [Test]
        public void GetDefaultHoursForDeviationType_FLEX_should_return_0()
        {
            //Act
            var result = _controllerUndertest.GetDefaultHoursForDeviationType("FLEX");

            //Assert
            Assert.AreEqual(0.0, result);
        }
    }
}
