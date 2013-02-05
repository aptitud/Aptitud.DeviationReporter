using Aptitud.DeviationReporter.Repositories;
using Models;
using NUnit.Framework;
using Should.Fluent;
using Simple.Data;

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
    }
}
