using System;

namespace Models
{
    public class Deviation
    {
        public int Id { get; set; }
        public string Reporter { get; set; }
        public DateTime ReportDate { get; set; }
        public string DeviationType { get; set; }
        public TimeSpan Duration { get; set; }
    }
}