using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_ESTADO")]
    public class Estado
    {
        [Column("id_estado"), HiddenInput]
        public int EstadoId { get; set; }

        [Column("nm_estado"), StringLength(30), Required]
        public string? Nome { get; set; }

        [Column("sg_estado"), StringLength(2)]
        public string? Sigla { get; set; }

        //Relacionamento 1:N
        public IList<Cidade> Cidades { get; set; }
    }
}
