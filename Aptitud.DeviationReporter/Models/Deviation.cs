using System;

namespace Models
{
    public class Deviation
    {
        private bool isReported = false;

        public int Id { get; set; }
        public string Reporter { get; set; }
        public DateTime ReportDate { get; set; }
        public string DeviationType { get; set; }
        public Int64 DurationTicks { get; set; }

        public TimeSpan Duration {
            get
            {
                return TimeSpan.FromTicks(DurationTicks);
            }
            set
            {
                DurationTicks = value.Ticks;
            }
        }

        public bool IsReported { get{return isReported;} set {isReported = value;} }
    }
}