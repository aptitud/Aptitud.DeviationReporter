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

        public IEnumerable<Deviation> GetDeviations()
        {
            return repository.GetDeviations();
        }

        public double GetDefaultHoursForDeviationType(string deviationType)
        {
            double defaultHours = 8;

            if (deviationType.ToUpperInvariant() == "FLEX")
            {
                defaultHours = 0;
            }

            return defaultHours;
        }
    }
}
