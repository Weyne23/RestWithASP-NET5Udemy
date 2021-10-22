using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAPSNETUdemy.Model
{
    [Table("books")]
    public class Books
    {
        [Key]
        [Column("CD_boock")]
        public long CD_book { get; set; }
        [Column("CH_author")]
        public string CH_author { get; set; }
        [Column("DT_launch_date")]
        public DateTime DT_launch_date { get; set; }
        [Column("VR_price")]
        public decimal VR_price { get; set; }
        [Column("CH_title")]
        public string CH_title { get; set; }

    }
}
