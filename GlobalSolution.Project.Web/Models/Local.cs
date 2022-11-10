using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_LOCAL")]
    public class Local
    {
        [Column("id_local"), HiddenInput]
        public int LocalId { get; set; }

        [Column("nm_local"), StringLength(90), Display(Name = "Nome do Local")]
        public string? Nome { get; set; }

        [Column("tp_local"), Display(Name = "Tipo"), Required]
        public TipoLocal? Tipo { get; set; }

        //Relacionamento 1:1
        public Telefone Telefone { get; set; }

        [Column("id_telefone")]
        public int TelefoneId { get; set; } //FK

        //Relacionamento N:1
        public Logradouro Logradouro { get; set; }

        [Column("id_logradouro")]
        public int LogradouroId { get; set; }

        //Relacionamento N:M
        public IList<AcessibilidadeLocal> AcessibilidadeLocal { get; set; }

    }

    public enum TipoLocal
    {
        Cinema, Teatro, Museu, Parque, Shopping, Mercado, Restaurante, Balada
    }

}
