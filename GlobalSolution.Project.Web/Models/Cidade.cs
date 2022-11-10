using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_CIDADE")]
    public class Cidade
    {
        [Column("id_cidade"), HiddenInput]
        public int CidadeId { get; set; }

        [Column("nm_cidade"), StringLength(80), Required]
        public string? Nome { get; set; }

        //Relacionamento N:1
        public Estado Estado { get; set; }

        [Column("id_estado")]
        public int EstadoId { get; set; }

        //Relacionamento 1:N
        public IList<Bairro> Bairros { get; set; }
    }
}
