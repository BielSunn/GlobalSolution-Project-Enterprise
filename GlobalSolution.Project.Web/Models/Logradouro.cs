using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_LOGRADOURO")]
    public class Logradouro
    {
        [Column("id_logradouro"), HiddenInput]
        public int LogradouroId { get; set; }

        [Column("ds_logradouro"), StringLength(90), Display(Name = "Descrição Logradouro"), Required]
        public string? Descricao { get; set; }

        [Column("nr_cep"), StringLength(20), Display(Name = "CEP")]
        public string? Cep { get; set; }

        //Relacionamento N:1
        public Bairro Bairro { get; set; }
        public int BairroId { get; set; }

        //Relacionamento 1:N
        public IList<Local> Locais { get; set; }
    }
}
