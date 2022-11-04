using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_LOGRADOURO")]
    public class Logradouro
    {
        [Column("id_logradouro")]
        public int LogradouroId { get; set; }

        [Column("ds_logradouro"), StringLength(90), Display(Name = "Logradouro")]
        public string? DescricaoLogradouro { get; set; }

        [Column("nr_cep"), StringLength(20), Display(Name = "CEP")]
        public string? Cep { get; set; }
    }
}
