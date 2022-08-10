using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet3.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext ctx)
        {
            dataContext = ctx;
        }

        public IList<ProdutoModel> FindAll()
        {
            return dataContext.Produtos.ToList<ProdutoModel>();
        }

        public ProdutoModel? FindById(int id)
        {
            return dataContext.Produtos // FROM
                    .Include(p => p.ProdutosLojas) // INNER JOIN
                        .ThenInclude( pl => pl.Loja ) // INNER JOIN
                    .SingleOrDefault( p => p.ProdutoId == id ); // WHERE
        }


        public int Insert(ProdutoModel produtoModel)
        {
            dataContext.Produtos.Add(produtoModel);
            dataContext.SaveChanges();
            return produtoModel.ProdutoId;
        }

        public void Delete(int id)
        {
            dataContext.Produtos.Remove(new ProdutoModel() { ProdutoId = id });
            dataContext.SaveChanges();
        }

        public void Update(ProdutoModel produtoModelNovo)
        {
            var produtoAtual = FindById(produtoModelNovo.ProdutoId);
            produtoAtual.ProdutoNome = produtoModelNovo.ProdutoNome;
            produtoAtual.ProdutosLojas = produtoModelNovo.ProdutosLojas;

            dataContext.Produtos.Update(produtoAtual);
            dataContext.SaveChanges();

        }

    }
}
