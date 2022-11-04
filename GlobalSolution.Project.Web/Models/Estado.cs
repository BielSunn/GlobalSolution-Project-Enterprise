using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_ESTADO")]
    public class Estado
    {
        [Column("id_estado")]
        public int EstadoId { get; set; }

        [Column("nm_estado"), StringLength(30), Display(Name = "Estado")]
        public string? Nome { get; set; }

        [Column("sg_estado"), StringLength(2), Display(Name = "Sigla")]
        public string? Sigla { get; set; }


    }
}
