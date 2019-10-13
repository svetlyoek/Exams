using Microsoft.AspNetCore.Mvc;
using WildlifeRefuge.Models;
using System.Linq;

namespace WildlifeRefuge.Controllers
{
    public class AnimalController : Controller
    {
        private readonly WildlifeRefugeDbContext context;

        public AnimalController(WildlifeRefugeDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                var allAnimals = db.Animals.ToList();
                return View(allAnimals);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string gender,int chipNumber,string kind)
        {
            if (string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(kind) 
                  || chipNumber <= 0)
            {
                return RedirectToAction("Index");

            }
          Animal animal = new Animal
            {
               ChipNumber=chipNumber,
               Kind=kind,
               
                Gender = gender

            };
            using (var db = new WildlifeRefugeDbContext())
            {
                db.Animals.Add(animal);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                var taskToEdit = db.Animals.FirstOrDefault(b => b.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new WildlifeRefugeDbContext())
            {
                var taskToEdit = db.Animals.FirstOrDefault(b => b.Id == animal.Id);
                taskToEdit.Kind = animal.Kind;
                taskToEdit.Gender = animal.Gender;
                taskToEdit.ChipNumber= animal.ChipNumber;
               
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                var taskToDelete = db.Animals.FirstOrDefault(b => b.Id == id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Animal animal)
        {
            using (var db = new WildlifeRefugeDbContext())
            {
                var taskToDelete = db.Animals.FirstOrDefault(b => b.Id == animal.Id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                db.Animals.Remove(taskToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}