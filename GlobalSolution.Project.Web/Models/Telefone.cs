using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_TELEFONE")]
    public class Telefone
    {
        [Column("id_telefone")]
        public int TelefoneId { get; set; }

        [Column("nr_ddd"), Display(Name = "DDD")]
        public int NumeroDDD { get; set; }

        [Column("nr_telefone"), Display(Name = "Telefone"), Phone]
        public int Numero { get; set; }

    }
}
