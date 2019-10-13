using RescueRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RescueRegister.Controllers
{
    public class MountaineerController : Controller
    {
        private readonly RescueRegisterDbContext context;

        public MountaineerController(RescueRegisterDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new RescueRegisterDbContext())
            {
                var allMountaineers = db.Mountaineers.ToList();
                return View(allMountaineers);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name, string lastSeenDate, int age, string gender)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lastSeenDate)||string.IsNullOrEmpty(gender)
                || age <= 0)
            {
                return RedirectToAction("Index");

            }
           Mountaineer mountaineer = new Mountaineer
            {
                Name = name,
               LastSeenDate=lastSeenDate,
               Age=age,
               Gender=gender

            };
            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Add(mountaineer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var taskToEdit = db.Mountaineers.FirstOrDefault(b => b.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Mountaineer mountaineer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new RescueRegisterDbContext())
            {
                var taskToEdit = db.Mountaineers.FirstOrDefault(b => b.Id == mountaineer.Id);
                taskToEdit.Name = mountaineer.Name;
                taskToEdit.LastSeenDate = mountaineer.LastSeenDate;
                taskToEdit.Age = mountaineer.Age;
                taskToEdit.Gender = mountaineer.Gender;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var taskToDelete = db.Mountaineers.FirstOrDefault(b => b.Id == id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Mountaineer mountaineer)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var taskToDelete = db.Mountaineers.FirstOrDefault(b => b.Id == mountaineer.Id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }

                db.Mountaineers.Remove(taskToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}