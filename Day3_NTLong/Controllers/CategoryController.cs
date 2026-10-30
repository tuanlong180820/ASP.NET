using Day3_NTLong.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3_NTLong.Controllers
{
    public class CategoryController : Controller
    {
        //gia lap csdl
        private static List<category> _categories = new List<category>()
        {
            new category(){Id=1, Name="Category 1"},
            new category(){Id=2, Name="Category 2"},
            new category(){Id=3, Name="Category 3"},
            
        };

        // GET: CategoryControllers
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: CategoryControllers/Details/5
        public ActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryControllers/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: CategoryControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] category category)
        {
            if (ModelState.IsValid) { 
             int newId = _categories.Any() ? _categories.Max(c =>  c.Id) + 1 : 1;
                category.Id = newId;
                _categories.Add(category);
                return RedirectToAction(nameof(Index));

            }
            return View(category);
        }

        // GET: CategoryControllers/Edit/5
        public ActionResult Edit([FromRoute]int id)
        {
            var category = _categories.FirstOrDefault(c=> c.Id == id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(category category)
        {
            var exisingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (exisingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                exisingCategory.Name = category.Name;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoryControllers/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if( category == null)
            {
                return NotFound();
            }
            _categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
