using System.Linq;
using Aptitud.DeviationReporter.Controllers;
using Aptitud.DeviationReporter.Repositories;
using Models;
using NUnit.Framework;
using Simple.Data;

namespace Aptitud.DeviationReporter.UnitTests
{
    [TestFixture]
    public class ReporterControllerTests
    {
        private ReporterController _controllerUndertest;
        private static dynamic _db;

        private static void InsertReporterInDB(Reporter r)
        {
            _db.Reporters.Insert(r);
        }

        [SetUp]
        public void Setup()
        {
            var adapter = new InMemoryAdapter();
            Database.UseMockAdapter(adapter);
            _db = Database.Open();
            var repo = new SQLServerDeviationRepository(_db);

            _controllerUndertest = new ReporterController(repo);
        }

        [Test]
        public void GetReporters_Should_return_a_list_of_all_reporters()
        {
            //Arrange
            var reporter1 = new Reporter() {Id = "tore.toresson@aptitud.se"};
            var reporter2 = new Reporter() { Id = "ulf.ulfsson@aptitud.se" };

            InsertReporterInDB(reporter1);
            InsertReporterInDB(reporter2);
            
            //Act
            var result = _controllerUndertest.GetReporters();

            //Assert
            Assert.AreEqual(2, result.Count());

        }
    }
}
