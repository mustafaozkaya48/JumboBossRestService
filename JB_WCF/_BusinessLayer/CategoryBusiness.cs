using _DataLayer;
using _DbEntities;
using _DbEntities.Repository.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
   public class CategoryBusiness
    {
        CategoryRepositroy _cr = new CategoryRepositroy();
        public List<CategoryModel> GetListCategory()
        {
            List<CategoryModel> model = new List<CategoryModel>();
            List<Category> list = _cr.CategorysList();
            foreach (var item in list)
            {
                model.Add(new CategoryModel {Id=item.Id,CategoryName=item.CategoryName });
            }


            return model;
        } 
    }
}
