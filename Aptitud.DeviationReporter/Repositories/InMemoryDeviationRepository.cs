using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Data;

namespace Aptitud.DeviationReporter.Repositories
{
    public class InMemoryDeviationRepository : IDeviationRepository
    {
        private List<Models.Deviation> deviations = new List<Models.Deviation>();
        public IEnumerable<Models.Deviation> GetDeviationByReporterName(string reporterName)
        {
            return deviations.Where(d => d.Reporter == reporterName);
        }

        public void AddDeviations(IEnumerable<Models.Deviation> deviations)
        {


            this.deviations.AddRange(deviations);
        }
    }

    
}