using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Data;
using Models;

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
            throw new NotImplementedException();
        }
    }    
}