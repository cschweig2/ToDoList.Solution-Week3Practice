using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.Include(animals => animals.Name).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.OccupantId = new SelectList(_db.Occupants, "OccupantId", "Type");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      return View(thisAnimal);
    }

    public ActionResult Show()
    {
      List<Animal> model = _db.Animals.OrderBy(Animals => Animals.Breed).ToList();
      return View(model);
    }

    public ActionResult Edit(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      ViewBag.OccupantId = new SelectList(_db.Occupants, "OccupantId", "Type");
      return View(thisAnimal);
    }

    [HttpPost]
    public ActionResult Edit(Animal animal)
    {
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(Animals => Animals.AnimalId == id);
      return View(thisAnimal); 
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(Animals => Animals.AnimalId == id);
      _db.Animals.Remove(thisAnimal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}