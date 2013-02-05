using Models;
using System.Collections.Generic;

namespace Aptitud.DeviationReporter.Repositories
{
    public interface IDeviationRepository
    {
        IEnumerable<Deviation> GetDeviationByReporterName(string reporterName);
        IEnumerable<Deviation> GetDeviations();
        void AddDeviations(IEnumerable<Deviation> deviations);
        IEnumerable<Reporter> GetReporters();
        IEnumerable<Deviation> GetCurrentDeviations(string reporterName);
    }
}