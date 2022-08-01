using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoController(IProdutoRepository _produtoRepository)
        {
            produtoRepository = _produtoRepository;
        }


        public IActionResult Index()
        {
            var listaProdutos = produtoRepository.FindAll();

            return View(listaProdutos);
        }


        public IActionResult Details(int id)
        {
            var produto = produtoRepository.FindById(id);

            return View(produto);
        }

    }
}
