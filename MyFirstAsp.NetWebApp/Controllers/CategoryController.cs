using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFirstAsp.NetWebApp.Data;
using MyFirstAsp.NetWebApp.Models;

namespace MyFirstAsp.NetWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _db;

        public CategoryController( DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> cateories = _db.Categories;
            return View(cateories);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category categoory)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Add(categoory);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(categoory);
            }
        }

        // GET - EDIT

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            var edit = _db.Categories.Find(id);
            if(edit == null)
            {
                return NotFound();
            }

            return View(edit);
        }

        // POST - EDIT

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if(ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET - DELETE

        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var delete = _db.Categories.Find(id);
            if(delete == null)
            {
                return NotFound();
            }

            return View(delete);
        }

        // POST - DELETE

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var delete = _db.Categories.Find(id);
            
            if (delete == null)
            {
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(delete);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}
