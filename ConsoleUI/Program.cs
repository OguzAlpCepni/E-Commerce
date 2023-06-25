using Business.concrete;
using DataAccess.concrete.EntitiyFramework;
using DataAccess.concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal);
            foreach (var cateogry in categoryManager.GetAll())
            {
                Console.WriteLine(cateogry.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(50, 200))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}