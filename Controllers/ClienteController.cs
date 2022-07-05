using Fiap.Web.AspNet3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class ClienteController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            // Simulando uma busca no banco de dados
            
            var listaClientes = new List<ClienteModel>();
            
            listaClientes.Add(new ClienteModel {
                ClienteId = 1,
                Nome = "Flávio",
                Email = "fmoreni@gmail.com",
                DataNascimento = DateTime.Now,  
                Observacao = "OBS1"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 2,
                Nome = "Eduardo",
                Email = "eduardo@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 3,
                Nome = "Moreni",
                Email = "moreni@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS3"
            });
            listaClientes.Add(new ClienteModel
            {
                ClienteId = 4,
                Nome = "Luan",
                Email = "luan@gmail.com",
                DataNascimento = DateTime.Now,
                Observacao = "OBS4"
            });


            return View(listaClientes);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(ClienteModel clienteModel)
        {
            // Recuperar as informações do cliente digitado

            // Cadastrar no banco de dados (Fake)
            // bancoDados.Cliente.Save(clienteModel);

            // Exibir uma tela de sucesso. OK

            TempData["mensagem"] = "Cliente cadastrado com sucesso";

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            //var clienteModel = bancoDados.Cliente.Search(id);
            var clienteModel = new ClienteModel();

            if (id == 1)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 1,
                    Nome = "Flavio",
                    Email = "fmoreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS1"
                };
            }
            else if (id == 2)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 2,
                    Nome = "Eduardo",
                    Email = "eduardo@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }
            else 
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 3,
                    Nome = "Moreni",
                    Email = "moreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }


            return View(clienteModel);
        }


        


        [HttpPost]
        public IActionResult Editar(ClienteModel clienteModel)
        {
            return View("Sucesso");
        }



        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var clienteModel = new ClienteModel();

            if (id == 1)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 1,
                    Nome = "Flavio",
                    Email = "fmoreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS1"
                };
            }
            else if (id == 2)
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 2,
                    Nome = "Eduardo",
                    Email = "eduardo@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }
            else
            {
                clienteModel = new ClienteModel
                {
                    ClienteId = 3,
                    Nome = "Moreni",
                    Email = "moreni@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "OBS3"
                };
            }


            return View(clienteModel);
        }


        [HttpPost]
        public IActionResult Help()
        {
            return View();
        }

    }
}
