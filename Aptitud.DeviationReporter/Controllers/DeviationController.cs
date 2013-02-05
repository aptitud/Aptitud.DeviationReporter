using Aptitud.DeviationReporter.Models;
using Aptitud.DeviationReporter.Repositories;
using Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Aptitud.DeviationReporter.Controllers
{
    public class DeviationController : ApiController
    {
        readonly IDeviationRepository repository;

        public DeviationController(IDeviationRepository repo)
        {
            repository = repo;
        }

        // POST api/deviation
        public void PostDeviation(IEnumerable<Deviation> value)
        {
            repository.AddDeviations(value);
        }

        // PUT api/deviation/5
        public void PutDeviation(Deviation value)
        {

        }

        // DELETE api/deviation/5
        public void DeleteDeviationById(int id)
        {

        }

        public IEnumerable<Deviation> GetDeviations()
        {
            return repository.GetDeviations();
        }

        public object GetDefaultsForDeviationType(string deviationType)
        {
            return DeviationTypeDefaults.Factory.CreateDefault(deviationType);
        }

        public IEnumerable<Deviation> GetCurrentMonthDeviationsByReporter(string reporterName)
        {
            return repository.GetCurrentDeviations(reporterName);
        }
    }
}
