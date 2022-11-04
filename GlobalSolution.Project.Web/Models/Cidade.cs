using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_CIDADE")]
    public class Cidade
    {
        [Column("id_cidade")]
        public int CidadeId { get; set; }

        [Column("nm_cidade"), StringLength(80), Display(Name = "Cidade")]
        public string? Nome { get; set; }

    }
}
