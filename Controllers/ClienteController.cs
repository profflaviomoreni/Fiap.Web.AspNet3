using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ClienteRepository clienteRepository;
        private readonly RepresentanteRepository representanteRepository;

        public ClienteController(DataContext dataContext)
        {
            clienteRepository = new ClienteRepository(dataContext);
            representanteRepository = new RepresentanteRepository(dataContext);
        }



        [HttpGet]
        public IActionResult Index()
        {
            var listaClientes = clienteRepository.FindAll();
            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            ViewBag.representantes = listaRepresentantes;

            return View( new ClienteModel() );
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {

            if (ModelState.IsValid)
            {
                clienteRepository.Insert(clienteModel);

                TempData["mensagem"] = $"Cliente {clienteModel.Nome} cadastrado com sucesso";
                return RedirectToAction("Index");
            } 
            else
            {
                var listaRepresentantes = representanteRepository.FindAll();
                ViewBag.representantes = listaRepresentantes;

                return View(clienteModel);
            }

            
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            var listaRepresentantes = representanteRepository.FindAll();
            ViewBag.representantes = listaRepresentantes;

            var clienteModel = clienteRepository.FindById(id);

            return View(clienteModel);
        }


        


        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                clienteRepository.Update(clienteModel);

                TempData["mensagem"] = $"Cliente {clienteModel.Nome} editado com sucesso";
                return RedirectToAction("Index");
            }
            else
            {
                var listaRepresentantes = representanteRepository.FindAll();
                ViewBag.representantes = listaRepresentantes;

                return View(clienteModel);
            }

        }



        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = clienteRepository.FindById(id); 
            return View(clienteModel);
        }


        [HttpPost]
        public IActionResult Help()
        {
            return View();
        }

    }
}
