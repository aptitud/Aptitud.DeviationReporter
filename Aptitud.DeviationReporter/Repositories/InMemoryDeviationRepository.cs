using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aptitud.DeviationReporter.Repositories
{
    public class InMemoryDeviationRepository : IDeviationRepository
    {
        private List<Deviation> deviations = new List<Deviation>();
        public IEnumerable<Deviation> GetDeviationByReporterName(string reporterName)
        {
            return deviations.Where(d => d.Reporter == reporterName);
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
            return deviations.Where(d => d.Reporter == reporterName
                        && d.ReportDate.Year == DateTime.Now.Year
                        && d.ReportDate.Month == DateTime.Now.Month);

        }
    }
}