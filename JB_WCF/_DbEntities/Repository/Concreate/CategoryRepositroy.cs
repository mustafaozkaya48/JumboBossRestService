using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
    public class CategoryRepositroy
    {
        
        private IRepository<Category> _CategoryRepository;
        private IUnitOfWork _categoryUnitofWork;
        private DbContext _dbContext;
        public CategoryRepositroy()
        {
            _dbContext = new JumboBossEntities();
            _CategoryRepository = new EFRepository<Category>(_dbContext);
            _categoryUnitofWork = new EFUnitOfWork(_dbContext);
        }
        public List<Category> CategorysList()
        {

            return _CategoryRepository.GetAll().ToList();
        }
       #pragma warning disable 414
        private static bool result;
       #pragma warning restore 414
        public bool AddCategory(Category model)
        {
            result = false;
          
            Category category = _CategoryRepository.GetAll(x => x.CategoryName == model.CategoryName).FirstOrDefault();
            if (category==null)
            {
                _CategoryRepository.Insert(model);
                return result =true;
            }
            else
            {
                return result=false;
            }

           

        }
        
    }
}
