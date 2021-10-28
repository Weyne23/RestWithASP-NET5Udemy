using RestWithAPSNETUdemy.Hypermedia;
using RestWithAPSNETUdemy.Hypermedia.Abstract;
using System;
using System.Collections.Generic;

namespace RestWithAPSNETUdemy.Data.VO
{
    public class BooksVO : ISupportsHypermedia
    {
        public long CD_book { get; set; }
        public string CH_author { get; set; }
        public DateTime DT_launch_date { get; set; }
        public decimal VR_price { get; set; }
        public string CH_title { get; set; }
        public DateTime DT_Criacao { get; set; }
        public DateTime? DT_Edicao { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
