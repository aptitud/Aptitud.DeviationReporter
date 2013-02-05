using Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Deviation> GetDeviationByReporterName(string reporterName)
        {
            return db.Deviations.FindAllByReporter(reporterName);
        }

        public void AddDeviations(IEnumerable<Deviation> deviations)
        {
            foreach (var d in deviations)
                db.Deviations.Insert(d);
        }

        public IEnumerable<Reporter> GetReporters()
        {
            var result = db.Reporters.All().ToList<Reporter>();
            return result;
        }

        public IEnumerable<Deviation> GetDeviations()
        {
            var result = db.Deviations.All().ToList<Deviation>();
            return result;
        }

        public IEnumerable<Deviation> GetCurrentDeviations(string reporterName)
        {
            IEnumerable<Deviation> result = db.Deviations.All().ToList<Deviation>();

            return result.Where(d => d.Reporter == reporterName
                        && d.ReportDate.Year == DateTime.Now.Year
                        && d.ReportDate.Month == DateTime.Now.Month);
        }
    }
}