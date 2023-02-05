using CursoCoder;
using CursoCoder.Controller;

namespace Proyecto1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            Product product = new Product();

            products = ProductController.GetProducts();
            product = ProductController.GetProduct(2);


            Console.WriteLine(products[1].Description);

        }
    }
}