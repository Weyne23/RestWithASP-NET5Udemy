using System;

namespace RestWithAPSNETUdemy.Data.VO
{
    public class BooksVO
    {
        public long CD_book { get; set; }
        public string CH_author { get; set; }
        public DateTime DT_launch_date { get; set; }
        public decimal VR_price { get; set; }
        public string CH_title { get; set; }
        public DateTime DT_Criacao { get; set; }
        public DateTime? DT_Edicao { get; set; }
    }
}
