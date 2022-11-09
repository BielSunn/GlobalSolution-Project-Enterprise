using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_ACESSIBILIDADE")]
    public class Acessibilidade
    {
        [Column("id_acessibilidade"), HiddenInput]
        public int AcessibilidadeId { get; set; }

        [Column("tp_acessibilidade"), StringLength(90), Display(Name = "Tipo de Acessibilidade"), Required]
        public string? TipoAcessibilidade { get; set; }

        [Column("ds_acessibilidade"), StringLength(500), Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Column("st_acessibilidade"), Display(Name = "Disponível")]
        public bool Status { get; set; }

        //Relacionamento N:M
        public IList<AcessibilidadeLocal> AcessibilidadeLocal { get; set; }

    }

}
