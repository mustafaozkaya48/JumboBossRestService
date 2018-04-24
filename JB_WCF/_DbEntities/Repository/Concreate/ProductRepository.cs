
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
    public class ProductRepository
    {
        private IRepository<Product> _ProductRepository;
        private IUnitOfWork _ProductUnitofWork;
        private DbContext _dbContext;
        public ProductRepository()
        {
            _dbContext = new JumboBossEntities();
            _ProductRepository = new EFRepository<Product>(_dbContext);
            _ProductUnitofWork = new EFUnitOfWork(_dbContext);
        }
        public int AddProduct(Product model,List<Product_Price> price)
        {
            int result=_ProductRepository.Insert(model);
            if (result > 0)
            {
                Product_PriceRepository ppr = new Product_PriceRepository();
                model = _ProductRepository.GetAll(x=>x.ProductName==model.ProductName).FirstOrDefault();
                foreach (Product_Price item in price)
                {
                    item.Product_Id = model.Id;
                    ppr.SetMultipler(item);
                }
                return result;
            }
            else return result;
          
        }
        public Product GetProduct(Product entity)
        {
            return _ProductRepository.GetAll(x=>x.ProductName==entity.ProductName).FirstOrDefault();
        }
        public List<Product> GetGruopbyID_Product(int GroupId)
        {
            return _ProductRepository.GetAll(x=>x.GroupId==GroupId).ToList();
        }
    }
}
