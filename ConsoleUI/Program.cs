using Business.concrete;
using DataAccess.concrete.EntitiyFramework;
using DataAccess.concrete.InMemory;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var cateogry in categoryManager.GetAll())
            {
                Console.WriteLine(cateogry.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetail())
            {
                Console.WriteLine(product.ProductName+" / "+product.CategoryName);
            }
        }
    }
}