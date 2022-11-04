using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Project.Web.Models
{
    [Table("T_USUARIO")]
    public class Usuario
    {
        [Column("id_usuario")]
        public int UsuarioId { get; set; }

        [Column("nm_usuario"), StringLength(50)]
        public string? Nome { get; set; }

        [Column("ds_email"), StringLength(50), EmailAddress, Display(Name = "E-mail")]
        public string? Email { get; set; }

        [Column("dt_nascimento"), DataType(DataType.Date), Display(Name = "Data de Nascimento") ]
        public DateTime DataNascimento { get; set; }

        [Column("ds_senha"), MinLength(8), MaxLength(20), DataType(DataType.Password)]
        public string? Senha { get; set; }


    }
}
