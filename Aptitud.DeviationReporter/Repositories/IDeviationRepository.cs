using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitud.DeviationReporter.Repositories
{
    public interface IDeviationRepository
    {
        IEnumerable<Models.Deviation> GetDeviationByReporterName(string reporterName);
        void AddDeviations(IEnumerable<Models.Deviation> deviations);
    }
}