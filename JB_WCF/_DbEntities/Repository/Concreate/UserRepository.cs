
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
     public class UserRepository
    {
        private IRepository<User> _userRepository;
        private IUnitOfWork _userUnitofWork;
        private DbContext _dbContext;
        public UserRepository()
        {
            _dbContext = new JumboBossEntities();
            _userRepository = new EFRepository<User>(_dbContext);
            _userUnitofWork = new EFUnitOfWork(_dbContext);
        }
        public User Login(int passowrd)
        {
            User user = _userRepository.Get(x => x.Passowrd == passowrd);
            return user;
        }
       
    }
}
