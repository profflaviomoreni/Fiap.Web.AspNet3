using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{
    [Table("ProdutoLoja")]
    public class ProdutoLojaModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoLojaId { get; set; }

        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; }

        public int LojaId { get; set; }

        [ForeignKey("LojaId")]
        public LojaModel Loja { get; set; }


    }
}
