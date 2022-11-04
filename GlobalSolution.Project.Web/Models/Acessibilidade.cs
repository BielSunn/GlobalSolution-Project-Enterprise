using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_ACESSIBILIDADE")]
    public class Acessibilidade
    {
        [Column("id_acessibilidade")]
        public int AcessibilidadeId { get; set; }

        [Column("tp_acessibilidade"), StringLength(90), Display(Name = "Tipo de Acessibilidade")]
        public string? TipoAcessibilidade { get; set; }



    }

}
