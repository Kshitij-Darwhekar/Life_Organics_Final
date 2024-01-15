using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OrganicStore.Models;
using System.Data;
using Newtonsoft.Json;

namespace OrganicStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(Products products)
        {
            Products pd = new Products();
            /*pd.id = products.id;*/
            pd.name = products.name;
            pd.original_price = products.original_price;
            pd.selling_price = products.selling_price;
            pd.category = products.category;
            pd.details = products.details;
            pd.pic = products.pic;
            
            
            List<Products> res = pd.GetProducts();  
            string productsJson = JsonConvert.SerializeObject(res);
            TempData["Products"] = productsJson;

            return RedirectToAction("Products","Home" , res);
 
        }
                    
    }
                
}
      
