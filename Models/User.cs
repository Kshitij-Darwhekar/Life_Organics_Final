using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace OrganicStore.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(255)]
        public string username { get; set; }
        [Required]
        [MaxLength(255)]
        public string email { get; set; }
        [Required]
        [MaxLength(255)]
        public string password { get; set; }
        
        public int SaveUserDetails()
        {
            SqlConnection conn = new SqlConnection(DBConnection.getConnectionString()) ;
            string query = "INSERT INTO Users (username,email,password) values('" + username + "','" + email + "','" + password + "' )";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected;
            
        }
        

        public int AuthenticateUserDetails()
        {
            SqlConnection conn = new SqlConnection(DBConnection.getConnectionString());
            string query = "SELECT (*) FROM Users WHERE username = @username";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            var auth = cmd.ExecuteScalar();
            if (auth == null)
            {

            }
            else
            {
                return (int) auth;
            }
            conn.Close();
            return /*RedirectToAction("Products", "Home");*/ 0;
        }

    }
}
