using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class RepresentanteController : Controller
    {

        private readonly RepresentanteRepository representanteRepository;

        public RepresentanteController(DataContext context)
        {
            representanteRepository = new RepresentanteRepository(context);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var listaRepresentantes = representanteRepository.FindAll();
            return View(listaRepresentantes);
        }


        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var representanteModel = representanteRepository.FindById(id);
            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RepresentanteId,NomeRepresentante")] RepresentanteModel representanteModel)
        {
            if (ModelState.IsValid)
            {
                representanteRepository.Insert(representanteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }


        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var representanteModel = representanteRepository.FindById(id);
            if (representanteModel == null)
            {
                return NotFound();
            }
            return View(representanteModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepresentanteId,NomeRepresentante")] RepresentanteModel representanteModel)
        {
            if (id != representanteModel.RepresentanteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                representanteRepository.Update(representanteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(representanteModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var representanteModel = representanteRepository.FindById(id);
            if (representanteModel == null)
            {
                return NotFound();
            }

            return View(representanteModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            representanteRepository.Delete(id);            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
