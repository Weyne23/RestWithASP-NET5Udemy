using System.Collections.Generic;

namespace RestWithAPSNETUdemy.Hypermedia.Abstract
{
    public interface ISupportsHypermedia
    {
        List<HyperMediaLink> Links { get; set;  }
    }
}
