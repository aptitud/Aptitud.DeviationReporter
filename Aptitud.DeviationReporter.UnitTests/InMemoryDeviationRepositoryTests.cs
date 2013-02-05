
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
    }
}
