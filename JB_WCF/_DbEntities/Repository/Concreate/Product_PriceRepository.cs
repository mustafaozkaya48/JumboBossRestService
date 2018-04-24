
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{

    public class Product_PriceRepository
    {

        private IRepository<Product_Price> _MultiplerRepository;
        private IUnitOfWork _userUnitofWork;
        private DbContext _dbContext;
        public Product_PriceRepository()
        {
     
            _dbContext = new JumboBossEntities();
            _MultiplerRepository = new EFRepository<Product_Price>(_dbContext);
            _userUnitofWork = new EFUnitOfWork(_dbContext);
        }
        public List<Product_Price> GetMultiplers(Product product)
        { 
            List<Product_Price> list = _MultiplerRepository.GetAll(x => x.Product_Id == product.Id).ToList();
            return list;
        }

        public void SetMultipler(Product_Price model)
        {
                _MultiplerRepository.Insert(model);
        }
    }
}
