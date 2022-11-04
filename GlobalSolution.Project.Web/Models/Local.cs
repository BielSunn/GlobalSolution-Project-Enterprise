using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_LOCAL")]
    public class Local
    {
        [Column("id_local")]
        public int LocalId { get; set; }

        [Column("nm_local"), StringLength(90), Display(Name = "Nome do Local")]
        public string? Nome { get; set; }

        [Column("tp_local"), StringLength(30), Display(Name = "Tipo")]
        public TipoLocal TipoLocal { get; set; }
    }

    public enum TipoLocal
    {
        Cinema, Teatro, Museu, Parque, Shopping, Mercado, Restaurante, Balada
    }

}
