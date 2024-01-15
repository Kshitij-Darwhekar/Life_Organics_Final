using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OrganicStore.Models
{
    public class DBConnection
    {
        public static string getConnectionString()
        {
            var conbuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true);
            var configobj = conbuilder.Build();
            string constring = configobj.GetConnectionString("UserProfile");
            return constring;
        }
    }
}
