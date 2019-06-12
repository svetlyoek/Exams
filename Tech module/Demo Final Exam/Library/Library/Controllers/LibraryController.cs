using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            {
                var allBooks = db.Books.ToList();
                return View(allBooks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string author, double price,string title)
        {
            if(string.IsNullOrEmpty(author)||string.IsNullOrEmpty(title)||price==0)
            {
                return RedirectToAction("Index");
            }
            Book book = new Book
            {
                Author = author,
                Title = title,
                Price = price

            };
            using (var db = new LibraryDbContext())
            {
                db.Books.Add(book);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var taskToEdit = db.Books.FirstOrDefault(b => b.Id == id);
                if(taskToEdit==null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
           if(!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            using (var db = new LibraryDbContext())
            {
                var taskToEdit = db.Books.FirstOrDefault(b => b.Id == book.Id);
                taskToEdit.Author = book.Author;
                taskToEdit.Title = book.Title;
                taskToEdit.Price = book.Price;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var taskToDelete = db.Books.FirstOrDefault(b => b.Id == id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToDelete);
            }

        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
          
            using (var db = new LibraryDbContext())
            {
                var taskToDelete = db.Books.FirstOrDefault(b => b.Id == book.Id);
                if (taskToDelete == null)
                {
                    return RedirectToAction("Index");
                }
               
                db.Books.Remove(taskToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
    }
