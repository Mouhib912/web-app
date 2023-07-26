using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            var ViewModel = new FormationFormViewModel();
            return View("FormationForm", ViewModel);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var formation = _context.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }

            var viewModel = new FormationFormViewModel
            {
                Id = formation.Id,
                Nom = formation.Nom,
                Description = formation.Description,
                IsActive = formation.IsActive
            };



            return View("EditFormation", viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var formation = _context.Formations.Find(id);
            if (formation == null)
            {
                return HttpNotFound();
            }

            // Assuming you have a method to remove the formation from the database.
            // For example, if you are using Entity Framework, you might have something like:
            // _context.Formations.Remove(formation);

            // Replace the above line with the actual code to delete the record from your data store.
            // For the sake of this example, let's assume the record is deleted successfully.

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the delete operation.
                // You might want to log the error or show an error message to the user.
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            // Redirect to the index or any other appropriate page after successful deletion.
            return RedirectToAction("Index");
        }


        public ActionResult Evaluer(int? id)
        {
            var ViewModel = new FormationFormViewModel();
            return View("Evaluer");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(FormationFormViewModel model, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View("FormationForm", model);
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