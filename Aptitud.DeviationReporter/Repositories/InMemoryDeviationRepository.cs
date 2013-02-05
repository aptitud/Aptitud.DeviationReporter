using Models;
using System;
using System.Collections.Generic;

namespace Aptitud.DeviationReporter.Repositories
{
    public class InMemoryDeviationRepository : IDeviationRepository
    {
        private List<Deviation> deviations = new List<Deviation>();

        public void AddDeviations(IEnumerable<Deviation> deviations)
        {
            this.deviations.AddRange(deviations);
        }

        public IEnumerable<Deviation> GetDeviations()
        {
            return deviations;
        }

        public IEnumerable<Reporter> GetReporters()
        {
            return new List<Reporter>() { new Reporter() { Id = "Kalle" }, new Reporter() { Id = "Anka" } };
        }

        public IEnumerable<Deviation> GetCurrentDeviations(string reporterName)
        {
            var results = new List<Deviation>();
            results.Add(new Deviation() { Reporter = reporterName, DeviationType = "VAB", ReportDate = DateTime.Now, Duration = new TimeSpan(0, 8, 0, 0, 0) });
            results.Add(new Deviation() { Reporter = reporterName, DeviationType = "SJUK", ReportDate = DateTime.Now, Duration = new TimeSpan(0, 8, 0, 0, 0) });
            results.Add(new Deviation() { Reporter = reporterName, DeviationType = "SEMESTER", ReportDate = DateTime.Now, Duration = new TimeSpan(0, 8, 0, 0, 0) });

            return results;

        }
    }
}