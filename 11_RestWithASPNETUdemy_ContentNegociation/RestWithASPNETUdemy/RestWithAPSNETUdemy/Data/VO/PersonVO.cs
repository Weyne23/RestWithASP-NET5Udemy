using System;
using System.Text.Json.Serialization;

namespace RestWithAPSNETUdemy.Data.VO
{
    public class PersonVO
    {
        public long CD_pessoa { get; set; }
        public string CH_firstName { get; set; }
        public string CH_lastName { get; set; }
        public string CH_address { get; set; }
        public string CH_gender { get; set; }
        public DateTime DT_Criacao { get; set; }
        public DateTime? DT_Edicao { get; set; }
    }
}
