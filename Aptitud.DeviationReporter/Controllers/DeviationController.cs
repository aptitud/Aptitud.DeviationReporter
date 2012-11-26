using System.Collections.Generic;
using System.Web.Http;
using Aptitud.DeviationReporter.Repositories;
using Simple.Data;

namespace Aptitud.DeviationReporter.Controllers
{
    public class DeviationController : ApiController
    {
        readonly IDeviationRepository repository;

        public DeviationController(IDeviationRepository repository)
        {
            this.repository = repository;
        }

        // HACK: Until we get Ninject or something in place
        public DeviationController()
        {
            repository = new SQLServerDeviationRepository(WebApiApplication.DB);
        }

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
