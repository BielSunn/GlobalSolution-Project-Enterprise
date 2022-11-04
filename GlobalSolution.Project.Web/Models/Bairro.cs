using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{

    [Table("T_BAIRRO")]
    public class Bairro
    {

        [Column("id_bairro")]
        public int BairroId { get; set; }

        [Column("nm_bairro"), StringLength(90), Display(Name = "Bairro")]
        public string? Nome { get; set; }

    }
}
