using AutoMapper;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly ILojaRepository lojaRepository;
        private readonly IMapper mapper;

        public ProdutoController(IProdutoRepository _produtoRepository, ILojaRepository _lojaRepository, IMapper _mapper)
        {
            produtoRepository = _produtoRepository;
            lojaRepository = _lojaRepository;
            mapper = _mapper;   
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

        [HttpGet]
        public IActionResult Novo()
        {
            var lojas = lojaRepository.FindAll();

            var vm = new ProdutoLojaViewModel();
            vm.Lojas = mapper.Map<IList<LojaViewModel>>(lojas);

            return View(vm);
        }


        [HttpPost]
        public IActionResult Novo(ProdutoLojaViewModel produtoLojaViewModel)
        {

            //var produtoModel = mapper.Map<ProdutoModel>(produtoLojaViewModel);
            try
            {
                var produtoModel = new ProdutoModel();
                produtoModel.ProdutoNome = produtoLojaViewModel.ProdutoNome;
                produtoModel.ProdutosLojas = new List<ProdutoLojaModel>();

                foreach (var item in produtoLojaViewModel.LojaId)
                {
                    var produtoLojaModel = new ProdutoLojaModel()
                    {
                        LojaId = item,
                        Produto = produtoModel
                    };

                    produtoModel.ProdutosLojas.Add(produtoLojaModel);
                }

                produtoRepository.Insert(produtoModel);

                TempData["mensagem"] = "Produto cadastrado com sucesso";

            }
            catch (Exception ex)
            {
                TempData["mensagem"] = $"Não foi possivel cadastrar o produto. Detalhe: {ex.Message}";
            }


            return RedirectToAction("Index");
        }


    }
}
