using Business.concrete;
using DataAccess.concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
           ProductManager productManager = new ProductManager(new InMemoryProductDal());
        
            foreach(var product in productManager.GelAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}