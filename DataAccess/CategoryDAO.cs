using BusinessObjects.DataContext;
using BusinessObjects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            try
            {
                using(var context = new ApplicationDBContext())
                {
                    return context.Categories.ToList();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Something went wrong: {ex.Message}");
            }
        }
    }
}
