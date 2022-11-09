using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_BAIRRO")]
    public class Bairro
    {
        [Column("id_bairro"), HiddenInput]
        public int BairroId { get; set; }

        [Column("nm_cidade"), StringLength(90), Required]
        public string? Nome { get; set; }

        //Relacionamento N:1
        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }

        //Relacionamento 1:N
        public IList<Logradouro> Logradouros { get; set; }
    }
}
