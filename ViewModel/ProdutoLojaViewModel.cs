namespace Fiap.Web.AspNet3.ViewModel
{
    public class ProdutoLojaViewModel
    {

        public string? ProdutoNome { get; set; } // Cadastro do nome do Produto

        public ICollection<int> LojaId { get; set; } // Cadastro das lojas para o produto

        public IList<LojaViewModel> Lojas { get; set; } // View das Lojas 

    }
}
