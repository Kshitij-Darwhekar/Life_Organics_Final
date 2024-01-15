using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicStore.Models;




namespace OrganicStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult SubmitCart(List<CartItem> cart)
        {
            try
            {
                foreach (var cartItem in cart)
                {
                    // You can customize the logic based on your database structure
                    var existingCartItem = _dbContext.CartItems.FirstOrDefault(c => c.ProductId == cartItem.ProductId);

                    if (existingCartItem != null)
                    {
                        existingCartItem.Quantity += cartItem.Quantity;
                        existingCartItem.Total = existingCartItem.Quantity * existingCartItem.Price;
                    }
                    else
                    {

                        _dbContext.CartItems.Add(new CartItem
                        {
                            ProductId = cartItem.ProductId,
                            ProductName = cartItem.ProductName,
                            Price = cartItem.Price,
                            Quantity = cartItem.Quantity,
                            Total = cartItem.Total
                        });
                    }
                }

                _dbContext.SaveChanges();

                return Json(new { success = true, message = "Cart submitted successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error submitting cart", error = ex.Message });
            }
        }
    
}
}
