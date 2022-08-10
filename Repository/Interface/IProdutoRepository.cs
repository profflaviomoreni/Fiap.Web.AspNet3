using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface IProdutoRepository
    {
        public IList<ProdutoModel> FindAll();

        public ProdutoModel FindById(int id);

        public int Insert(ProdutoModel produtoModel);

        public void Delete(int id);

        public void Update(ProdutoModel produtoModelNovo);

    }
}
