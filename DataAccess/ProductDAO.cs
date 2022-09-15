using BusinessObjects.DataContext;
using BusinessObjects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            try
            {
                using(var context = new ApplicationDBContext())
                {
                    return context.Products.ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Something went wrong: {ex.Message}");
            }
        }

        public static Product FindProductById(int Id)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    return context.Products.FirstOrDefault(p => p.Id == Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong: {ex.Message}");
            }
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong: {ex.Message}");
            }
        }
        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    context.Products.Update(p);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong: {ex.Message}");
            }
        }
        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new ApplicationDBContext())
                {
                    var p1 = context.Products.FirstOrDefault(pro => pro.Id == p.Id);
                    context.Products.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong: {ex.Message}");
            }
        }

    }
}
