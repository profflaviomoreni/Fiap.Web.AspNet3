using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{

    [Table("Fornecedor")]
    public class FornecedorModel
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FornecedorId { get; set; }

        [Required]
        [StringLength(70)]
        public string? FornecedorNome { get; set; }

        [Required]
        [StringLength(14)]
        public string? Cnpj { get; set; }

        [StringLength(11)]
        public string? Telefone { get; set; }


        [Required]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
