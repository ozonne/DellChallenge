using System;
using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            ValidateProduct(newProduct);
            if (ModelState.IsValid)
            {
                _productService.Add(newProduct);
                return RedirectToAction("Index");
            }
            return View(newProduct);
        }

        [HttpPost]
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var model = _productService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var model = _productService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Update", model);
        }

        [HttpPost]
        public IActionResult Update(ProductModel product)
        {
            ValidateProduct(product);
            if (ModelState.IsValid)
            {
                var model = _productService.Update(product);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return RedirectToAction("Index");
            }
            return View(product);
    }

        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var model = _productService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var result = _productService.Delete(id);
            if (result == false)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        private void ValidateProduct(NewProductModel newProduct)
        {
            if (string.IsNullOrEmpty(newProduct.Name))
            {
                ModelState.AddModelError("Name", "Please enter name");
            }
        }
    }
}