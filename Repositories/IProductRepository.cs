using BusinessObjects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetProducts();
        public List<Category> GetCategories();

        public Product GetProductById(int id);
        public void SaveProduct(Product p);
        public void DeleteProduct(Product p);
        public void UpdateProduct(Product p);
    }
}
