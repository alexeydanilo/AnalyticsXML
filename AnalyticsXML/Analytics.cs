

using System.Collections.Generic;

namespace AnalyticsXML
{
    public class Analytics
    {
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public int CdsCount { get; set; }
        public double PricesSum { get; set; }
        public List<string> Titles { get; set; }
        public List<string> Artists { get; set; }
        public List<string> Countries { get; set; }
        public List<string> Companies { get; set; }

    }
}
