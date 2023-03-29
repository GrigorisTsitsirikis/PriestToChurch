
using MyFirstMVC.Models;
using MyFirstMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.Controllers
{
    public class PriestsController : Controller
    {

        private ApplicationDbContext _context;

        public PriestsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Priest
        public ActionResult Index()
        {
            ViewBag.Message = "Priests";

            var priests = _context.Priests.OrderBy(x => x.LastName).ToList();
            var churches = _context.Churches.OrderBy(x => x.Name).ToList();

            var viewModel = new PriestsModel
            {
                Priests = priests,
                Churches=churches

            };
            return View(viewModel);
        }

        // Get: Priest Categories
        public ActionResult AvailableByCategory()
        {
            ViewBag.Message = "AvailableByCategory";
            var Priests = _context.Priests;

            var availableEfimerioi = Priests.Where(x => x.IsEfimerios == true && x.Available == true).OrderBy(x => x.LastName).ToList();
            var availableIerokyrikes = Priests.Where(x => x.IsIerokirikas == true && x.Available == true).OrderBy(x => x.LastName).ToList();
            var availableEpoxiakoi = Priests.Where(x => x.IsEpoxiakos == true && x.Available == true).OrderBy(x => x.LastName).ToList();
            var churches = _context.Churches.OrderBy(x => x.Name).ToList();
            var availablePriests = new List<Priest>();
            availablePriests.AddRange(availableEfimerioi);
            availablePriests.AddRange(availableEpoxiakoi);
            availablePriests.AddRange(availableIerokyrikes);

            var viewModel = new PriestCategories
            {
                AssignedChurches = churches,
                Efimerioi = availableEfimerioi,
                Epoxiakoi = availableEpoxiakoi,
                Ierokyrikes = availableIerokyrikes,
                AllAvailablePriests=availablePriests.OrderBy(x=>x.LastName).ToList()

            };
            return View(viewModel);
        }

        public ActionResult AssignPriestToChurch()
        {
            ViewBag.Message = "AssignPriestToChurch";
            var model=AvailableByCategory();

            return model;
        }

        /// <summary>
        /// Assign Priests To Churches
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PriestΤοChurch(FormCollection form, DateTime datepicker)
        {
            ViewBag.Message = "test";

            string priestLastName = form["AllAvailablePriests"].ToString();
            string churchName = form["AssignedChurches"].ToString();


            var priestInDb = _context.Priests.Single(p => p.LastName == priestLastName);
            priestInDb.Available = false;
            priestInDb.DatePicker = datepicker;

            var churchInDb = _context.Churches.Single(c => c.Name == churchName);
            priestInDb.Church = churchInDb;
            

            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("AssignPriestToChurch", "Priests");
        }

        /// <summary>
        /// Creates a New Priest and adds in the List of Priests.
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            return View();
        }

        /// <summary>
        /// Αποθηκεύει τα στοιχεία του ιερέα είτε δημιουργεί έναν νέο.
        /// </summary>
        /// <param name="priest"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(Priest priest)
        {

            if (ModelState.ContainsKey("Id"))
                ModelState["Id"].Errors.Clear();

            if (!ModelState.IsValid)
            {

                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
                return View("New", priest);
            }

            //Έλεγχος νέου ιερέα.

            if (priest.Id==0)
            {
                _context.Priests.Add(priest);
            }
            else
            {
                var priestInDb = _context.Priests.Single(p => p.Id == priest.Id);

                //TryUpdateModel(priestInDb); //official approach secur issues.
                //Mapper.Map(priest,priestInDb) ///dto in request. dont pass all arguments

                priestInDb.Name = priest.Name;
                priestInDb.LastName = priest.LastName;
                priestInDb.IsEfimerios = priest.IsEfimerios;
                priestInDb.IsEpoxiakos = priest.IsEpoxiakos;
                priestInDb.IsIerokirikas = priest.IsIerokirikas;
                priestInDb.PhoneNumber = priest.PhoneNumber;
                priestInDb.Available = priest.Available;
                //new
               // priestInDb.Church.Name = priest.Church.Name;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Priests");
        }

        public ActionResult Details(int id)
        {
            var priest = _context.Priests.SingleOrDefault(x => x.Id == id); 
            if (priest == null) { return HttpNotFound(); }
            return View(priest);
        }

        public ActionResult Edit(int id)
        {
            var priest = _context.Priests.SingleOrDefault(x => x.Id == id);

            if (priest == null) { return HttpNotFound(); }
            return View("New", priest);
        }

        public ActionResult Delete(int id)
        {
            var Priests = _context.Priests.ToList();

            var priest = Priests.SingleOrDefault(x => x.Id == id);

            if (priest == null) { return HttpNotFound(); }

            _context.Priests.Remove(priest);
            _context.SaveChanges();
            return RedirectToAction("Index", "Priests");
        }

        public ActionResult PriestForm()
        {
            var viewModel = new PriestFormViewModel
            {
                Churches = _context.Churches.ToList()
            };
            return View("PriestForm", viewModel);
        }
    }
}