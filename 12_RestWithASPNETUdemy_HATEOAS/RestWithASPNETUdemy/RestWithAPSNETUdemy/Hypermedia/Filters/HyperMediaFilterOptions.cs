using System.Collections.Generic;
using RestWithAPSNETUdemy.Hypermedia.Abstract;

namespace RestWithAPSNETUdemy.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
