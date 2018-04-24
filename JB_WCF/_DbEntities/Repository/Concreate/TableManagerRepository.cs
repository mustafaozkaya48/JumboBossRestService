
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
    public class TableManagerRepository
    {
        private IRepository<Entity> _EntitiesRepository;
        private IUnitOfWork _EntitiesUnitofWork;
        private DbContext _dbContext;
        public TableManagerRepository()
        {
            _dbContext = new JumboBossEntities();
            _EntitiesRepository = new EFRepository<Entity>(_dbContext);
            _EntitiesUnitofWork = new EFUnitOfWork(_dbContext);
        }

        public bool SetTable(string name)
        {
            if (_EntitiesRepository.GetAll(x => x.Name == name).FirstOrDefault() == null)
            {
                _EntitiesRepository.Insert(new Entity { Name = name, EntitiesName = "Masa" });
                return true;
            }
            else return false;
        }
        public bool UpdateTable(Entity entitiy)
        {
            if (_EntitiesRepository.GetAll(x => x.Name == entitiy.Name).FirstOrDefault() == null)
            {
                _EntitiesRepository.Updete(entitiy);
                return true;
            }
            else return false;
        }
        public void UpdateFullAndTicketId(Entity entitiy)
        {

            Entity entities = new Entity();
            entities = _EntitiesRepository.GetAll(x => x.Name == entitiy.Name).FirstOrDefault();
            entities.IsFull = entitiy.IsFull;
            entities.TicetId = entitiy.TicetId;
            _EntitiesRepository.Updete(entities);
        }

        public List<Entity> GetList()
        {
            return _EntitiesRepository.GetAll().OrderBy(x => x.Name).ToList();

        }


    }
}
