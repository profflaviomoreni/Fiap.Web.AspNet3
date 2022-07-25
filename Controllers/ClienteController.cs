using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.representantes = ComboRepresentantes();
            return View(new ClienteModel());
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
                ViewBag.representantes = ComboRepresentantes();
                return View(clienteModel);
            }

            
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewBag.representantes = ComboRepresentantes();
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
                ViewBag.representantes = ComboRepresentantes();
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


        private SelectList ComboRepresentantes()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            var selectListRepresentantes = new SelectList(listaRepresentantes, "RepresentanteId", "NomeRepresentante");
            return selectListRepresentantes;
        }


    }
}
