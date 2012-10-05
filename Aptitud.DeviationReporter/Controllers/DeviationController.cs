using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aptitud.DeviationReporter.Controllers
{
    public interface IDeviationRepository
    {
        IEnumerable<Models.Deviation> GetDeviationByReporterName(string reporterName);
        void AddDeviations(IEnumerable<Models.Deviation> deviations);
    }

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

    public class DeviationController : ApiController
    {
        private static readonly IDeviationRepository repository = new InMemoryDeviationRepository();
        // GET api/deviation
        public IEnumerable<Models.Deviation> GetDeviationByReporter(string reporterName)
        {
            return repository.GetDeviationByReporterName(reporterName);
        }

        // POST api/deviation
        public void PostDeviation(IEnumerable<Models.Deviation> value)
        {
            repository.AddDeviations(value);
        }

        // PUT api/deviation/5
        public void PutDeviation(Models.Deviation value)
        {

        }

        // DELETE api/deviation/5
        public void DeleteDeviationById(int id)
        {

        }
    }
}
