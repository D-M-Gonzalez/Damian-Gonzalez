using CursoCoder;
using CursoCoder.Controller;

namespace Proyecto1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=DESKTOP-QR97TGF;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            List<Product> products = new List<Product>();
            Product product = new Product();

            products = ProductController.GetProducts(connectionString);
            product = ProductController.GetProduct(connectionString, 2);
            

            Console.WriteLine(product.Description);

        }
    }
}