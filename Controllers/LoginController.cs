using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrganicStore.Models;
/*using System.Web.UI;*/

namespace OrganicStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user) {
            
            SqlConnection conn = new SqlConnection(DBConnection.getConnectionString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users where username='" + user.username + "'and password='" + user.password + "'");
            cmd.Connection = conn;
            int OBJ = Convert.ToInt32(cmd.ExecuteScalar());
            if (OBJ > 0)
            {
                //Session["name"] = user.username;
                //Response.Redirect("Products.cshtml");
                return RedirectToAction("Details", "Product");
            }
            else
            {
                /* Response.WriteAsync("<script>alert('User Not Found ! ')</script>");
                 *//*return RedirectToAction("Index", "Home", user);*/
                /*Response.Redirect("Signup.cshtml");*/

                var script = "alert('User Not Found!'); window.location.href = '/Home/Signup';";
                Response.WriteAsync("<script>" + script + "</script>");
                return View("Signup"); // Assuming "Signup.cshtml" is the name of your signup view

            }

            /*string username = user.username;
            string password = user.password;

            return RedirectToAction("Products","Home", user);*/

            return RedirectToAction("Index", "Home");
        }   

        public IActionResult Details() { 
            return View();
        }

    }
}
