using Day3_NTLong.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Day3_NTLong.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _product = new List<Product>()
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.0m, Description = "Description 1", CategoryId = 1 },
            new Product { Id = 2, Name = "Product 2", Price = 20.0m, Description = "Description 2", CategoryId = 2 },
            new Product { Id = 3, Name = "Product 3", Price = 30.0m, Description = "Description 3", CategoryId = 3 }

        };
        // GET: ProductController
        public ActionResult Index()
        {
            
            return View(_product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var Product = _product.FirstOrDefault(x => x.Id == id);
            if (Product == null)
            {
                return NotFound();
            } 
            return View(Product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product product)
        {
            if (ModelState.IsValid) { 
                int newId = _product.Any() ? _product.Max(x => x.Id) +1 : 1;
                product.Id = newId;
                _product.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }

        // GET: ProductController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var Product = _product.FirstOrDefault(x => x.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = _product.FirstOrDefault(c => c.Id == product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingProduct.Name = product.Name;
                return RedirectToAction(nameof(Index));

            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var Product = _product.FirstOrDefault(x => x.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
           
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var Product = _product.FirstOrDefault(x => x.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            _product.Remove(Product);
            return RedirectToAction(nameof(Index));
        }
    }
}
