using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace OccupantShelter.Controllers
{
    public class OccupantsController : Controller
    {
        private readonly AnimalShelterContext _db;

        public OccupantsController(AnimalShelterContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Occupant> model = _db.Occupants.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Occupant Occupant)
        {
            _db.Occupants.Add(Occupant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Occupant thisOccupant = _db.Occupants.FirstOrDefault(Occupants => Occupants.OccupantId == id);
            return View(thisOccupant);
        }

        public ActionResult Show()
        {
            List<Occupant> model = _db.Occupants.OrderBy(Occupants => Occupants.Type).ToList();
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var thisOccupant = _db.Occupants.FirstOrDefault(Occupants => Occupants.OccupantId == id);
            return View(thisOccupant);
        }

        [HttpPost]
        public ActionResult Edit(Occupant Occupant)
        {
            _db.Entry(Occupant).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisOccupant = _db.Occupants.FirstOrDefault(Occupants => Occupants.OccupantId == id);
            return View(thisOccupant); 
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisOccupant = _db.Occupants.FirstOrDefault(Occupants => Occupants.OccupantId == id);
            _db.Occupants.Remove(thisOccupant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}