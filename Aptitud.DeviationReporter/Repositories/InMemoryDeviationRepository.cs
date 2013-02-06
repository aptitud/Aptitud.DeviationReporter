using System.Linq;
using Models;
using System;
using System.Collections.Generic;

namespace Aptitud.DeviationReporter.Repositories
{
    public class InMemoryDeviationRepository : IDeviationRepository
    {
        private List<Deviation> deviations = new List<Deviation>();

        public InMemoryDeviationRepository()
        {
            deviations.Add(new Deviation() { Reporter = "Kalle", DeviationType = "VAB", ReportDate = DateTime.Now, Duration = new TimeSpan(0, 8, 0, 0, 0) });
            deviations.Add(new Deviation() { Reporter = "Kalle", DeviationType = "SJUK", ReportDate = DateTime.Now, Duration = new TimeSpan(0, 8, 0, 0, 0) });
            deviations.Add(new Deviation() { Reporter = "Kalle", DeviationType = "SEMESTER", ReportDate = DateTime.Now, Duration = new TimeSpan(0, 8, 0, 0, 0) });
            deviations.Add(new Deviation() { Reporter = "Anka", DeviationType = "VAB", ReportDate = DateTime.Now, Duration = new TimeSpan(0, 8, 0, 0, 0) });
        }

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
            return deviations.Where(x => x.Reporter == reporterName);
        }
    }
}