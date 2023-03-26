using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstMVC.Models;
using MyFirstMVC.ViewModels;

namespace MyFirstMVC.Controllers
{
    public class ChurchesController : Controller
    {

        private ApplicationDbContext _context;

        public ChurchesController()
        {
            _context = new ApplicationDbContext();

        }



        // GET: Church
        public ActionResult Index()
        {
            ViewBag.Message = "Churches";

            var churches = _context.Churches.OrderBy(c => c.Name).ToList();
                 

            var viewModel = new PriestsModel
            {
                Churches = churches,
            };

            return View(viewModel);

        }

        public ActionResult New()
        {
            return View();
        }


        public ActionResult Edit(int id)
        {

            var church = _context.Churches.SingleOrDefault(x => x.Id == id);

            if (church == null) { return HttpNotFound(); }


            return View("New", church);

        }

        public ActionResult Details(int id)
        {
            var church = GetChurches().FirstOrDefault(x => x.Id == id);
            if (church == null) { return HttpNotFound(); }

            return View(church);

        }

        /// <summary>
        /// Αποθηκεύει τα στοιχεία της εκκλησίας είτε δημιουργεί μια νέα.
        /// </summary>
        /// <param name="church"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(Church church)
        {

            if (ModelState.ContainsKey("Id"))
                ModelState["Id"].Errors.Clear();

            if (!ModelState.IsValid)
            {

                var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();


                return View("New", church);

            }

            //Έλεγχος νέας εκκλησίας.

            if (church.Id == 0)
            {
                _context.Churches.Add(church);
            }
            else
            {
                var churchInDb = _context.Churches.Single(c => c.Id == church.Id);


                churchInDb.Name = church.Name;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Churches");
        }




        public ActionResult Delete(int id)
        {
            var Churches = _context.Churches.ToList();


            var church = Churches.SingleOrDefault(x => x.Id == id);

            if (church == null) { return HttpNotFound(); }

            _context.Churches.Remove(church);
            _context.SaveChanges();



            return RedirectToAction("Index", "Churches");

        }










        private List<Church> GetChurches()
        {
            var churches = new List<Church> {
            new Church
            {
                Id = 1,
                Name = "ΑΓ.ΠΑΡΑΣΚΕΥΗ"
            },
                new Church
                {
                    Id = 2,
                    Name = "ΑΓ.ΔΗΜΗΤΡΙΟΣ"
                }
                };
            return churches;
        }

    }
}
