using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.ViewModels;

namespace WebApplication2.Controllers
{
    public class FormationController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FormationController()
        {
            _context = new ApplicationDBContext();
        }

        // GET: Formation
        public ActionResult IndexF()
        {
            var formations = _context.Formations.ToList();

            return View(formations);
        }

        public ActionResult Create()
        {
            var model = new FormationFormViewModel();
            return View(model);
        }

        public ActionResult Edit(int? id) {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var Formation = _context.Formations.Find(id);
            if (Formation == null) { return HttpNotFound(); }

            var ViewModel = new FormationFormViewModel
            {
                Id = Formation.Id, 
                Description = Formation.Description,
                ImgUrl = Formation.ImgUrl,
                IsActive = Formation.IsActive
            }; 
            return View("FormationForm", ViewModel);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormationFormViewModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            var formation = new Formation
            {
                Nom = model.Nom,
                Description = model.Description,
                ImgUrl = model.ImgUrl,
                IsActive = model.IsActive
            };

            _context.Formations.Add(formation);
            _context.SaveChanges();

            return RedirectToAction("IndexF");
        }



    }
}