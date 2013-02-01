using System;

namespace Aptitud.DeviationReporter.Models
{
    public class DeviationTypeDefaults : IEquatable<DeviationTypeDefaults>
    {
        public double DefaultHours { get; set; }
        public double MinimumHours { get; set; }
        public double MaximumHours { get; set; }

        private DeviationTypeDefaults()
        {
            DefaultHours = 8.0;
            MinimumHours = 0.0;
            MaximumHours = 8.0;
        }

        private DeviationTypeDefaults(double defaultHours
            , double minimumHours
            , double maximumHours)
        {
            DefaultHours = defaultHours;
            MinimumHours = minimumHours;
            MaximumHours = maximumHours;
        }

        public static class Factory
        {
            public static DeviationTypeDefaults CreateDefault(string deviationType)
            {
                if (deviationType.ToUpperInvariant() == "FLEX")
                {
                    return new DeviationTypeDefaults(0.0, -8.0, 8.0);
                }
                else if (deviationType.ToUpperInvariant() == "VAB")
                {
                    return new DeviationTypeDefaults();
                }
                else if (deviationType.ToUpperInvariant() == "SJUK")
                {
                    return new DeviationTypeDefaults();
                }
                else if (deviationType.ToUpperInvariant() == "SEMESTER")
                {
                    return new DeviationTypeDefaults();
                }

                return null;
            }
        }

        public bool Equals(DeviationTypeDefaults other)
        {
            if (this == null && other == null)
            {
                return true;
            }

            if (this != null && other == null)
            {
                return false;
            }

            if (this == null && other != null)
            {
                return false;
            }

            return this.DefaultHours == other.DefaultHours
                && this.MaximumHours == other.MaximumHours
                && this.MinimumHours == other.MinimumHours;
        }
    }
}