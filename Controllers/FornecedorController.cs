using Fiap.Web.AspNet3.Controllers.Filters;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet3.Controllers
{
    [FiapAuthFilter, FiapLogFilter]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepository fornecedorRepository;

        public FornecedorController(IFornecedorRepository _fornecedorRepository)
        {
            fornecedorRepository = _fornecedorRepository;
        }

        public IActionResult Index()
        {
            var fornecedores = fornecedorRepository.FindAll();
            return View(fornecedores);
        }

        public IActionResult Details(int id)
        {

            var fornecedorModel = fornecedorRepository.FindById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FornecedorId,FornecedorNome,Cnpj,Telefone,Email")] FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                fornecedorRepository.Insert(fornecedorModel);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var fornecedorModel = fornecedorRepository.FindById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }
            return View(fornecedorModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FornecedorId,FornecedorNome,Cnpj,Telefone,Email")] FornecedorModel fornecedorModel)
        {
            if (id != fornecedorModel.FornecedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    fornecedorRepository.Update(fornecedorModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorModel);
        }

        public IActionResult Delete(int id)
        {

            var fornecedorModel = fornecedorRepository.FindById(id);
            if (fornecedorModel == null)
            {
                return NotFound();
            }

            return View(fornecedorModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            fornecedorRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
