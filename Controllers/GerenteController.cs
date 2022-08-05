﻿using Fiap.Web.AspNet3.Controllers.Filters;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    [FiapAuthFilter]
    public class GerenteController : Controller
    {
        private readonly IGerenteRepository gerenteRepository;

        public GerenteController(IGerenteRepository _gerenteRepository)
        {
            gerenteRepository = _gerenteRepository;
        }

        // GET: Gerente
        public IActionResult Index()
        {
              return View(gerenteRepository.FindAll());
        }

        public IActionResult Details(int id)
        {

            var gerenteModel = gerenteRepository.FindById(id);
            if (gerenteModel == null)
            {
                return NotFound();
            }

            return View(gerenteModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("GerenteId,Nome,Sobrenome")] GerenteModel gerenteModel)
        {
            if (ModelState.IsValid)
            {
                gerenteRepository.Insert(gerenteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(gerenteModel);
        }

        public IActionResult Edit(int id)
        {
            var gerenteModel = gerenteRepository.FindById(id);
            if (gerenteModel == null)
            {
                return NotFound();
            }
            return View(gerenteModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("GerenteId,Nome,Sobrenome")] GerenteModel gerenteModel)
        {
            if (id != gerenteModel.GerenteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                gerenteRepository.Update(gerenteModel);
                return RedirectToAction(nameof(Index));
            }
            return View(gerenteModel);
        }

        public IActionResult Delete(int id)
        {

            var gerenteModel = gerenteRepository.FindById(id);
            if (gerenteModel == null)
            {
                return NotFound();
            }

            return View(gerenteModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var gerenteModel = gerenteRepository.FindById(id); ;
            if (gerenteModel != null)
            {
                gerenteRepository.Delete(gerenteModel);
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
