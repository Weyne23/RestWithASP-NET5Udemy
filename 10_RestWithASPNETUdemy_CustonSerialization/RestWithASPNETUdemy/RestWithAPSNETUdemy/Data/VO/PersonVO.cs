using System;
using System.Text.Json.Serialization;

namespace RestWithAPSNETUdemy.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("Code")]
        public long CD_pessoa { get; set; }
        [JsonPropertyName("Name")]
        public string CH_firstName { get; set; }
        [JsonPropertyName("Last_Name")]
        public string CH_lastName { get; set; }
        [JsonIgnore]
        public string CH_address { get; set; }
        [JsonPropertyName("Sex")]
        public string CH_gender { get; set; }
        [JsonPropertyName("Criation_Date")]
        public DateTime DT_Criacao { get; set; }
        [JsonPropertyName("Edition_Date")]
        public DateTime? DT_Edicao { get; set; }
    }
}
