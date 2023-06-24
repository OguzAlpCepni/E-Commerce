using Business.concrete;
using DataAccess.concrete.EntitiyFramework;
using DataAccess.concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
           ProductManager productManager = new ProductManager(new EfProductDal() );

            foreach (var product in productManager.GetByUnitPrice(50,200))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}