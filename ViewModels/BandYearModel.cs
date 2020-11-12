using System.Collections.Generic;

namespace Power_Monitoring.ViewModels
{
    public class BandYearModel
    {
        public IList<string> Years { get; set; } = new List<string>();
        public IList<BandModel> BandModels { get; set; } = new List<BandModel>();
    }

    public class BandModel
    {
        public string Name { get; set; }
        public IList<int> Years { get; set; } = new List<int>();
    }
}
