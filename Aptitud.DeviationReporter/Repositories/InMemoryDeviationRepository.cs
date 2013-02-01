using Models;
using System.Collections.Generic;
using System.Linq;

namespace Aptitud.DeviationReporter.Repositories
{
    public class InMemoryDeviationRepository : IDeviationRepository
    {
        private List<Models.Deviation> deviations = new List<Models.Deviation>();
        public IEnumerable<Deviation> GetDeviationByReporterName(string reporterName)
        {
            return deviations.Where(d => d.Reporter == reporterName);
        }

        public void AddDeviations(IEnumerable<Models.Deviation> deviations)
        {
            this.deviations.AddRange(deviations);
        }

        public IEnumerable<Deviation> GetDeviations()
        {
            return deviations;
        }

        public IEnumerable<Reporter> GetReporters()
        {
            return new List<Reporter>();
        }
    }
}