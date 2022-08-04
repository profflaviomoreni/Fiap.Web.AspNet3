using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet3.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteRepository clienteRepository;
        private readonly IRepresentanteRepository representanteRepository;

        public ClienteController(IClienteRepository _clienteRepository, IRepresentanteRepository _representanteRepository)
        {
            clienteRepository = _clienteRepository;
            representanteRepository = _representanteRepository;
        }



        [HttpGet]
        public IActionResult Index()
        {
            var vm = new ClientePesquisaViewModel();
            vm.Representantes = ComboRepresentantes();

            return View(vm);
        }


        [HttpPost]
        public IActionResult Pesquisar(ClientePesquisaViewModel clientePesquisaViewModel)
        {
            

            var listaClientes = clienteRepository
                                    .FindByNomeAndEmailAndRepresentante(
                                        clientePesquisaViewModel.ClienteNome,
                                        clientePesquisaViewModel.ClienteEmail,
                                        clientePesquisaViewModel.RepresentanteId);

            var listaClientesVM = new List<ClienteViewModel>();
            foreach (var cliente in listaClientes)
            {
                var clienteVM = new ClienteViewModel();
                clienteVM.ClienteId = cliente.ClienteId;
                clienteVM.Nome = cliente.Nome;

                var representanteVM = new RepresentanteViewModel();
                representanteVM.RepresentanteId = cliente.Representante.RepresentanteId;
                representanteVM.NomeRepresentante = cliente.Representante.NomeRepresentante;

                clienteVM.Representante = representanteVM;

                listaClientesVM.Add(clienteVM);
            }


            clientePesquisaViewModel.Clientes = listaClientesVM;
            clientePesquisaViewModel.Representantes = ComboRepresentantes();

            return View("Index", clientePesquisaViewModel);
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

            var listaRepresentantesVM = new List<RepresentanteViewModel>();
            foreach (var representante in listaRepresentantes)
            {
                var representanteViewModel = new RepresentanteViewModel();
                representanteViewModel.RepresentanteId = representante.RepresentanteId;
                representanteViewModel.NomeRepresentante = representante.NomeRepresentante;

                listaRepresentantesVM.Add(representanteViewModel);
            }

            var selectListRepresentantes = new SelectList(listaRepresentantesVM, "RepresentanteId", "NomeRepresentante");
            return selectListRepresentantes;
        }


    }
}
