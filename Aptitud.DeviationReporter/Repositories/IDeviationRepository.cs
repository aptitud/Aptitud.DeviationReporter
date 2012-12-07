using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aptitud.DeviationReporter.Repositories
{
    public interface IDeviationRepository
    {
        IEnumerable<Deviation> GetDeviationByReporterName(string reporterName);
        IEnumerable<Deviation> GetDeviations();
        void AddDeviations(IEnumerable<Deviation> deviations);
    }
}