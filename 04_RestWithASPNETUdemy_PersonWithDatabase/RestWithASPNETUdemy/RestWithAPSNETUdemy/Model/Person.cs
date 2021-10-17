using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("person")]
    public class Person
    {
        [Key]
        [Column("CD_Pessoa")]
        public long CD_pessoa { get; set; }
        [Column("CH_FirstName")]
        public string CH_firstName { get; set; }
        [Column("CH_LastName")]
        public string CH_lastName { get; set; }
        [Column("CH_Address")]
        public string CH_address { get; set; }
        [Column("CH_Gender")]
        public string CH_gender { get; set; }
    }
}
