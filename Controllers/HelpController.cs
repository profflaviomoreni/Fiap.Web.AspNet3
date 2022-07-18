using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class HelpController : Controller
    {

        private DataContext dataContext;

        public HelpController(DataContext ctx)
        {
            dataContext = ctx;
        }


        public IActionResult Index()
        {
            /*
            var fornecedor = new FornecedorModel();
            fornecedor.FornecedorId = 2;

            dataContext.Fornecedores.Remove(fornecedor);
            dataContext.Historico.Add(fornecedor);
            dataContext.SaveChanges();
            */


            /*
            var id = 1;
            var fornecedor = dataContext.Fornecedores.Find(id);
            */

            /*
            var fornecedor = new FornecedorModel();
            fornecedor.FornecedorId = 2;
            fornecedor.FornecedorNome = "idwall.co";
            fornecedor.Cnpj = "43443761002417";
            fornecedor.Email = "idwall@idwall.co";
            fornecedor.Telefone = "1199995656";

            dataContext.Fornecedores.Update(fornecedor);
            dataContext.SaveChanges();
            */

            //var fornecedores = dataContext.Fornecedores.ToList<FornecedorModel>();


            /*
            var fornecedor = new FornecedorModel();
            fornecedor.FornecedorNome = "idwall";
            fornecedor.Cnpj = "43443761002417";
            fornecedor.Email = "fiap@fiap.com.br";
            fornecedor.Telefone = "1199995656";


            dataContext.Fornecedores.Add(fornecedor);
            dataContext.SaveChanges();  
            */


            return View();
        }

        public IActionResult About()
        {

            // Fluxo 1

            // Fluxo 2

            // Fluxo 3

            /*
            dataContext.Fornecedores.Remove(null);
            dataContext.SaveChanges();
            */


            return View("AboutUs");
        }

        public IActionResult Content()
        {
            //return Content("Retornando o conteudo em formato String");
            //return View("Index");
            return RedirectToAction("Index","Home");
        }


    }
}
