using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAPSNETUdemy.Model.Base
{
    public class BaseEntity
    {
        [Column("DT_Criacao")]
        public DateTime DT_Criacao {  get; set; }
        [Column("DT_Edicao")]
        public DateTime? DT_Edicao { get; set; }
    }
}
