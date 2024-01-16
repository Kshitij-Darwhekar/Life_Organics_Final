using Microsoft.AspNetCore.Mvc;
using OrganicStore.Models;
using System.Collections.Generic;

namespace OrganicStore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Products products)
        {
            if (ModelState.IsValid)
            {
                products.AddProduct();
                TempData["SuccessMessage"] = "Products added succesfully";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add the product. Please check the input";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteProduct()
        {
            try
            {
                Products products = new Products();
                List<string> productNames = products.GetProductNames();
                ViewData["ProductNames"] = productNames;


                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error fetching product names: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult DeleteProduct(string name)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Received product name: {name}");


                if (!string.IsNullOrEmpty(name))
                {
                    Products.DeleteProductByName(name);
                    TempData["SuccessMessage"] = "Product deleted successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete the product. Please provide a valid product name.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting product: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

    }
}
