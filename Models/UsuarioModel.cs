using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string? UsuarioNome { get; set; }

        [Required]
        [StringLength(70)]
        public string? UsuarioEmail { get; set; }

        [Required]
        [StringLength(12)]
        public string? UsuarioSenha { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

    }
}
