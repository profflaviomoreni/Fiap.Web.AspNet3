using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{
    [Table("Produto")]
    public class ProdutoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoId { get; set; }

        public string ProdutoNome { get; set; }

        public ICollection<ProdutoLojaModel> ProdutosLojas { get; set; }

    }
}
