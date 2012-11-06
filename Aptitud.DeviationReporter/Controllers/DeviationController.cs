using System.Collections.Generic;
using System.Web.Http;
using Aptitud.DeviationReporter.Repositories;

namespace Aptitud.DeviationReporter.Controllers
{
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
