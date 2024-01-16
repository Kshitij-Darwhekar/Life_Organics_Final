using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;
using System.Data;




namespace OrganicStore.Models
{
    public class Products
    {
        /*id, p_name, details, category, s_price, o_price, img*/
        public int product_id { get; set; }

        public string name { get; set; }

        public int original_price { get; set; }

        public int selling_price {  get; set; }

        public string category {  get; set; }

        public string details { get; set; }

        public string pic { get; set; }

        /*public int quantity { get; set; }*/


        public List<Products> GetProducts()
        {
            List<Models.Products> list = new List<Models.Products>();

            SqlConnection conn = new SqlConnection(DBConnection.getConnectionString());
            string query = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Products products = new Products();
                    Products pd = new Models.Products();
                    pd.product_id = reader.GetInt32("product_id");
                    pd.name = reader.GetString("name");
                    pd.original_price = reader.GetInt32("original_price");
                    pd.selling_price = reader.GetInt32("selling_price");
                    pd.category = reader.GetString("category");
                    pd.details = reader.GetString("details");

                    pd.pic = reader.GetString("pic");

              

                    list.Add(pd);
                }
            }
            return list;
        }
        public void AddProduct()
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.getConnectionString()))
            {
                string query = "INSERT INTO Products (name, original_price, selling_price, category, details, pic) VALUES (@Name, @OriginalPrice, @SellingPrice, @Category, @Details, @Pic)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@OriginalPrice", original_price);
                    cmd.Parameters.AddWithValue("@SellingPrice", selling_price);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.Parameters.AddWithValue("@Pic", pic);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteProductByName(string productName)
        {
            using (SqlConnection conn = new SqlConnection(DBConnection.getConnectionString()))
            {
                string query = "DELETE FROM Products WHERE name = @Name";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", productName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<string> GetProductNames()
        {
            List<string> productNames = new List<string>();

            using (SqlConnection conn = new SqlConnection(DBConnection.getConnectionString()))
            {
                string query = "SELECT name FROM Products";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productNames.Add(reader.GetString("name"));
                        }
                    }
                }
            }
            return productNames;
        }
    }
}
