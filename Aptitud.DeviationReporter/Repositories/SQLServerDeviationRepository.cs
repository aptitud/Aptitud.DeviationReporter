using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Simple.Data;
using Models;

namespace Aptitud.DeviationReporter.Repositories
{
    public class SQLServerDeviationRepository : IDeviationRepository
    {
        private dynamic db;

        public SQLServerDeviationRepository()
        {
            this.db = WebApiApplication.DB;
        }

        public SQLServerDeviationRepository(dynamic db)
        {
            this.db = db;
        }

        public IEnumerable<Models.Deviation> GetDeviationByReporterName(string reporterName)
        {
            return db.Deviations.FindAllByReporter(reporterName);
        }

        public void AddDeviations(IEnumerable<Deviation> deviations)
        {
            foreach (var d in deviations)
                db.Deviations.Insert(d);
        }

        public IEnumerable<Deviation> GetDeviations()
        {
            var result = db.Deviations.All().ToList<Deviation>();

            return result;
        }
    }
}