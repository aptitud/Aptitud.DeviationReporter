using System.Collections.Generic;
using System.Web.Http;
using Aptitud.DeviationReporter.Repositories;
using Models;

namespace Aptitud.DeviationReporter.Controllers
{
    public class ReporterController : ApiController
    {
        readonly IDeviationRepository repository;

        public ReporterController(IDeviationRepository repo)
        {
            repository = repo;
        }

        // GET api/reporter
        public IEnumerable<Reporter> GetReporters()
        {
            return repository.GetReporters();
        }

        // GET api/reporter/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/reporter
        public void Post([FromBody]string value)
        {
        }

        //// PUT api/reporter/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/reporter/5
        //public void Delete(int id)
        //{
        //}
    }
}
